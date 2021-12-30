export enum RolesUsuario {
  Prestador = 1,
  Cobrador,
}

export enum EstatuCrediticioCliente {
  Libre = 1,
  CreditosOcupados,
  Atrasados,
  PrestamosVencidos,
}

export enum PeriodoDePagos {
  Diario = 1,
  Semanal,
  Quincenal,
  Mensual,
  Anual,
}

export enum EstatusPrestamosClientes {
  Pendiente = 1,
  Pagado,
  Abono,
  Atraso,
}
