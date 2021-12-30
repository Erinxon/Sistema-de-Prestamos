import { Direccion } from "../direcciones/direccion.model";
import { Rol } from "../roles/rol.model";

export interface Usuario {
    id: number;
    nombres: string;
    apellidos: string;
    cedula: string;
    email: string;
    telefono: string;
    fechaCreado: string;
    fechaActualizado: string;
    direccion: Direccion;
    rol: Rol
}

