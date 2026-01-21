import { Container } from "inversify";
import "reflect-metadata";
import { IRepositoryPersonas} from "../domain/interfaces/repositories/IPersonaRepository";
import { RepositoryPersonasApi} from "../data/repositories/RepositoryPersonasApi";
//import { PeopleListVM } from "@/app/UI/ViewModels/PeopleListVM";
import { TYPES } from "./types";
import { IPersonaUseCase } from "../domain/interfaces/useCases/IPersonaUseCase";
import { PersonasUseCase } from "../domain/useCases/PersonaUseCase";


const container = new Container();


// Vinculamos la interfaz con su implementación concreta
container.bind<IRepositoryPersonas>(TYPES.IRepositoryPersonas).to(RepositoryPersonasApi);
container.bind<IPersonaUseCase>(TYPES.IPersonaUseCase).to(PersonasUseCase);
export { container };