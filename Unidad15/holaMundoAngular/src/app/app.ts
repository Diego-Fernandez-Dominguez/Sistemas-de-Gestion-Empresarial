import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormularioReactivo } from './components/formulario-reactivo/formulario-reactivo';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';

const routes: Routes = [
  { path: '', redirectTo: 'tabla', pathMatch: 'full' },
  { path: 'tabla', component: TablaPersonas },
  { path: 'formulario-reactivo', component: FormularioReactivo },
  { path: 'listado', component: TablaPersonas } // si quieres el listado separado
];

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {}
