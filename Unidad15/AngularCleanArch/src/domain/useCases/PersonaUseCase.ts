import { injectable, inject } from "inversify";
import { TYPES } from "../../di/types";
import { IRepositoryPersonas } from "../interfaces/repositories/IPersonaRepository";
import { clsPersona } from "../entities/clsPersona";
import { IPersonaUseCase } from "../interfaces/useCases/IPersonaUseCase";

@injectable()
export class PersonasUseCase implements IPersonaUseCase {
    constructor(
        @inject(TYPES.IRepositoryPersonas)
        private repositoryPersonas: IRepositoryPersonas
    ) {}

    getListadoPersonas(): Promise<clsPersona[]> {
        return this.repositoryPersonas.getListadoCompletoPersonas();
    }
}
