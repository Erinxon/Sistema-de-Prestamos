using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prestamos.Core.Entities.Enums;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Implementations;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.BackgroundServices
{
    public class BackgroundServiceCliente : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory scopeFactory;
        private readonly IUnitOfWork _unitOfWork;

        public BackgroundServiceCliente(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
            _unitOfWork = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWork>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(VerificarSiElClienteEstaAtrasado, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void VerificarSiElClienteEstaAtrasado(Object state)
        {
            await PrintClientes();
        }

        public void Dispose()
        {
           _timer?.Dispose();
        }

        private async Task PrintClientes()
        {
            try
            {
                var prestamos = await this._unitOfWork.Prestamos.GetPrestamosRetrasados();
                Console.WriteLine(prestamos.Count());
                foreach (var prestamo in prestamos)
                {
                    #region Actualizar estatus detalle prestamos
                    await this._unitOfWork.Prestamos.
                    UpdateEstatusDetallePrestamo(prestamo.Id, EstatusPrestamosClientes.Atraso);
                    await this._unitOfWork.SavechangesAsync();
                    #endregion

                    #region Verificar si el prestamo se venció
                    if (prestamo.FechaPago < prestamo.Prestamo.FechaCulminacion)
                    {
                        #region Actualizar estatus Prestamo si se vencio la fecha de cultminacion
                        await this._unitOfWork.Prestamos.UpdateEstatusPrestamo(prestamo.IdPrestamo, EstatusPrestamosClientes.Atraso);
                        await this._unitOfWork.SavechangesAsync();
                        #endregion

                        #region Actualizar estatus del cliente si se vencio la fecha de cultminacion
                        await this._unitOfWork.Clientes.UpdateEstatus(prestamo.Prestamo.IdCliente, EstatuCrediticioCliente.PrestamosVencidos);
                        await this._unitOfWork.SavechangesAsync();
                        #endregion
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
