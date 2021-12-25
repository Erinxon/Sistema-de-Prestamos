import { AddDireccion } from "../direcciones/addDireccion.model";

export interface UpdateEmpresa {
    nombre: string;
    rnc: string;
    telefono: string;
    email: string;
    direccion: AddDireccion;
}
