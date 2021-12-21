import { Direccion } from "../direcciones/direccion.model";
import { Estatus } from "../estatus/estatus.model";
import { EstatusCrediticio } from "../estatusCrediticios/estatusCrediticio.model";

export interface UpdateCliente {
    nombres: string;
    apellidos: string;
    cedula: string;
    telefono: string;
    IdEstatus: number;
    idEstatusCrediticio: number;
    direccion: Direccion;
}