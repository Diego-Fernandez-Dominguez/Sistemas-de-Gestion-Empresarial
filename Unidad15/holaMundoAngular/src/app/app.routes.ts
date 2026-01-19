import { Routes } from '@angular/router';
import { FormularioReactivo } from '../app/components/formulario-reactivo/formulario-reactivo';
import { TablaPersonas } from '../app/components/tabla-personas/tabla-personas';


export const routes: Routes = [
  { path: '', redirectTo: 'tabla', pathMatch: 'full' },
  { path: 'tabla', component: TablaPersonas },
  { path: 'formulario-reactivo', component: FormularioReactivo },
  { path: 'listado', component: TablaPersonas } // si quieres el listado separado
];
