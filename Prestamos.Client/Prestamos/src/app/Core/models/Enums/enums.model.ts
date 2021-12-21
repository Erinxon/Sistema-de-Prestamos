export enum RolesUsuario {
  Prestador = 1,
  Cobrador,
}

export enum EstatusClientes {
  Activo = 1,
  Inactivo,
  Eliminado,
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
