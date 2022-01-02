using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prestamos.Infrastructure.ApiResponse;
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
        private readonly IUnitOfWork _unitOfWord;

        public BackgroundServiceCliente(IUnitOfWork unitOfWord)
        {
            this._unitOfWord = unitOfWord;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(VerificarSiElClienteEstaAtrasado, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void VerificarSiElClienteEstaAtrasado(Object state)
        {
            Console.WriteLine("Hola");
            await PrintClientes();
        }

        public void Dispose()
        {
           _timer?.Dispose();
        }

        private async Task PrintClientes()
        {
            var clientes = await _unitOfWord.Clientes.GetAll(new Pagination());
            foreach (var item in clientes)
            {
                Console.WriteLine(item.Nombres);
            }
        }
    }
}
