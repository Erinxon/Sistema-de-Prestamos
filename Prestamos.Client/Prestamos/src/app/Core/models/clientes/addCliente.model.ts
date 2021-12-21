import { AddDireccion } from "../direcciones/addDireccion.model";

export interface AddCliente {
    nombres: string;
    apellidos: string;
    cedula: string;
    telefono: string;
    direccion: AddDireccion;
}