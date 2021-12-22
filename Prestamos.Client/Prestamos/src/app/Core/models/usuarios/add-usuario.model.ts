import { AddDireccion } from "../direcciones/addDireccion.model"

export interface AddUsuario {
    nombres: string;
    apellidos: string;
    cedula: string;
    email: string;
    telefono: string;
    password: string;
    direccion: AddDireccion;
    idRol: number;
}