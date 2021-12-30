using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamos.Core.Entities.Enums
{
    public enum RolesUsuario
    {
        Admin = 1, Prestador, Cobrador, 
    }

    public enum EstatuCrediticioCliente
    {
        Libre = 1, CreditosOcupados, Atrasados, PrestamosVencidos
    }

    public enum PeriodoDePagos
    {
        Diario = 1, Semanal, Quincenal, Mensual, Anual
    }

    public enum EstatusPrestamosClientes
    {
        Pendiente = 1, Pagado, Abono, Atraso
    }


}
