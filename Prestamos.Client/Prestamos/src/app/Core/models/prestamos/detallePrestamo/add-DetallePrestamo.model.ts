export interface AddDetallePrestamo {
    numeroCuota: number;
    cuotaPagar: number;
    interesPagar: number;
    capitalAmortizado: number;
    idEstatusPrestamo: number;
    pagado: number;
    capitalPendiente: number;
    fechaPago: Date;
}