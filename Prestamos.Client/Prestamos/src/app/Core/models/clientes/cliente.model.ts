import { Direccion } from "../direcciones/direccion.model";
import { EstatusCrediticio } from "../estatusCrediticios/estatusCrediticio.model";

export interface Cliente {
    id: number;
    nombres: string;
    apellidos: string;
    cedula: string;
    telefono: string;
    fechaCreado: Date;
    fechaActualizado: Date;
    direccion: Direccion;
    estatusCrediticio: EstatusCrediticio;
}
