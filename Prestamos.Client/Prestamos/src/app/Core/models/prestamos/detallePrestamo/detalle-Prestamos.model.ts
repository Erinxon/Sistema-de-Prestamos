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
    idEstatusPrestamo: number;
    idPrestamo: number;
    estatusPrestamo: EstatusPrestamo;
}
