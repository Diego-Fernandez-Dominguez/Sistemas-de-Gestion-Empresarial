import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { FormularioPersonas } from './components/formulario-personas/formulario-personas/formulario-personas';
import { ListaPersonas } from './components/lista-personas/lista-personas/lista-personas';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonas, FormularioPersonas, ListaPersonas],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Mecagoentodo');
}
