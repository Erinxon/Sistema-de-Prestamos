import { EstatusPrestamo } from "../../estatusPrestamos/estatusPrestamo.model";

export interface DetallePrestamo {
    id: number;
    numeroCuota: number;
    cuotaPagar: number;
    interesPagar: number;
    capitalAmortizado: number;
    pagado: number;
    capitalPendiente: number;
    fechaPago: Date;
    estatusPrestamo: EstatusPrestamo;
}
