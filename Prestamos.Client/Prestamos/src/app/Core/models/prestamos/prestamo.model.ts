import { Cliente } from "../clientes/cliente.model";
import { EstatusPrestamo } from "../estatusPrestamos/estatusPrestamo.model";
import { PeriodoPago } from "../periodosPagos/periodoPago.model";
import { Usuario } from "../usuarios/usuatio.model";
import { DetallePrestamo } from "./detallePrestamo/detalle-Prestamos.model";

export interface Prestamo {
    id: number;
    interes: number;
    Cuotas: number;
    capital: number;
    fechaCreado: Date;
    fechaCulminacion: Date;
    estatusPrestamo: EstatusPrestamo;
    periodoPago: PeriodoPago;
    usuarioUtorizador: Usuario;
    cliente: Cliente;
    detallePrestamo: DetallePrestamo[];
}
