import { Direccion } from "../direcciones/direccion.model";
import { Usuario } from "../usuarios/usuatio.model";

export interface Empresa {
    id: number;
    nombre: string;
    rnc: string;
    telefono: string;
    email: string;
    administrador: Usuario;
    direccion: Direccion;
}