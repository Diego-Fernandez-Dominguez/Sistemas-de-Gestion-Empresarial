import { clsPersona } from "../../domain/entities/clsPersona";
import { inject } from "inversify";
import { TYPES } from "../../di/types";
import { IRepositoryPersonas } from "../../domain/interfaces/repositories/IPersonaRepository";
//import {  makeAutoObservable } from "mobx";
import { IPersonaUseCase } from "../../domain/interfaces/useCases/IPersonaUseCase";

export class PeopleListVM {

    private _personasList: clsPersona[] = [];
    private _personaSeleccionada: clsPersona;
   
    constructor(
        @inject(TYPES.IPersonaUseCase)
        private UseCasePersona: IPersonaUseCase
        
    ) {
       
        this._personaSeleccionada = new clsPersona(0,'Fernando','Galiana',new Date("2000-01-01"),"https://media.istockphoto.com/id/183422512/es/foto/manzanas-rojas-frescas-sobre-fondo-blanco.jpg?s=612x612&w=0&k=20&c=N4NDC0ClXKIKow18XJXsWw1aukJGQR9qHq9O0UXqtyI=" , "60147583", 1 );
        //this._personasList = this.UseCasePersona.getListadoPersonas();
        //makeAutoObservable(this);
     
    }

    public get personasList(): clsPersona[] {
        return this._personasList;
    }

    public get personaSeleccionada(): clsPersona {
        return this._personaSeleccionada;
    }

    public set personaSeleccionada(value: clsPersona) {
        this._personaSeleccionada = value;
        //alert(`Persona seleccionada en el VM: ${this._personaSeleccionada.Nombre} ${this._personaSeleccionada.Apellido}`);
     
    }
  }
