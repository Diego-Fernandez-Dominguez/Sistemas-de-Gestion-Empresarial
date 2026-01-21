import { clsPersona } from "../../entities/clsPersona";

export interface IRepositoryPersonas {
     getListadoCompletoPersonas(): Promise<clsPersona[]>;
}
