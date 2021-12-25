import { AddDetallePrestamo } from "./detallePrestamo/add-DetallePrestamo.model";

export interface AddPrestamo {
    interes: number;
    cuotas: number;
    capital: number;
    idPeriodoPago: number;
    fechaCreado: Date;
    fechaCulminacion: Date;
    idUsuarioUtorizador: number;
    idCliente: number;
    detallePrestamos: AddDetallePrestamo[];
}

