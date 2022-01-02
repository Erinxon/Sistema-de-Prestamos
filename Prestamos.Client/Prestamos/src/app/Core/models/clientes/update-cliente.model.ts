import { Direccion } from "../direcciones/direccion.model";

export interface UpdateCliente {
    nombres: string;
    apellidos: string;
    cedula: string;
    telefono: string;
    direccion: Direccion;
}