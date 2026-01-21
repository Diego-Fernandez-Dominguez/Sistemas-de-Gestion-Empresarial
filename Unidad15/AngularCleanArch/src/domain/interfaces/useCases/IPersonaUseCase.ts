import { clsPersona } from "../../entities/clsPersona";

export interface IPersonaUseCase {
    getListadoPersonas(): Promise<clsPersona[]>;
}
