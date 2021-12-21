import { HttpClient } from "@angular/common/http";
import { AbstractControl } from "@angular/forms";
import { ValidarCedula } from "./validar-cedula";

export class MyValidations{

    static isCedulaInvalid(control: AbstractControl){
        const validationCedula = new ValidarCedula();
        if(!validationCedula.isValida(control.value)){
            return { isCedulaInvalid: true, actualCedula: control.value}
        }
        return null;
    }
}