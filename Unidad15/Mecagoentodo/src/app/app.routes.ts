import { Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TablaPersonas } from '../app/components/tabla-personas/tabla-personas';
import { FormularioPersonas } from '../app/components/formulario-personas/formulario-personas/formulario-personas';
import { ListaPersonas } from '../app/components/lista-personas/lista-personas/lista-personas';

export const routes: Routes = [
  { path: '', redirectTo: 'tabla', pathMatch: 'full' },
  { path: 'tabla', component: TablaPersonas },
  { path: 'formulario', component: FormularioPersonas },
  { path: 'listado', component: ListaPersonas },
  { path: '**', redirectTo: 'tabla' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}