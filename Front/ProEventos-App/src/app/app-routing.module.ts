import { EventoListaComponent } from './components/eventos/evento-lista/evento-lista.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { EventosComponent } from './components/eventos/eventos.component';


import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';

const routes: Routes = [
  {path: 'eventos',redirectTo: 'eventos/lista'},
  {
    path: 'eventos', component: EventosComponent,
    children: [
      { path: 'detalhe/:id',component: EventoDetalheComponent },
      { path: 'detalhe',component: EventoDetalheComponent },
      { path: 'lista',component: EventoListaComponent },
    ]
  },
  {path: 'dashboard', component: DashboardComponent},
  {path: 'palestrantes', component: PalestrantesComponent},
  {path: 'perfil', component: PerfilComponent},
  {path: 'contatos', component: ContatosComponent},
  {path: '', redirectTo: 'dashboard',pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard',pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
