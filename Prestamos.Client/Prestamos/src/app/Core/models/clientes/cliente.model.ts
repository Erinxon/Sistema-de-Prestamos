import { Direccion } from "../direcciones/direccion.model";
import { EstatuCrediticioCliente, EstatusClientes } from "../Enums/enums.model";
import { Estatus } from "../estatus/estatus.model";
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
    estatus: Estatus;
    estatusCrediticio: EstatusCrediticio;
}
