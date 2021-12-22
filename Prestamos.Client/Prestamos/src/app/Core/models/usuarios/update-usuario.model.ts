import { Direccion } from "../direcciones/direccion.model";

export interface UpdateUsuario {
    nombres: string;
    apellidos: string;
    cedula: string;
    email: string;
    telefono: string;
    idRol: number;
    direccion: Direccion;
}