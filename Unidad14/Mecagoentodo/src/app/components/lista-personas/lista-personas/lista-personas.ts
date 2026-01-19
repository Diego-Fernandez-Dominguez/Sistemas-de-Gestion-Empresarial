import { Component } from '@angular/core';

@Component({
  selector: 'app-lista-personas',
  imports: [],
  templateUrl: './lista-personas.html',
  styleUrl: './lista-personas.css',
})

export class ListaPersonas {
  saludar(): void {
    alert('¡Hola! Este es un saludo desde tabla-personas');
  }
}
