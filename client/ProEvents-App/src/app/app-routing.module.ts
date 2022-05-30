import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventsComponent } from './componentes/events/events.component';
import { ContatosComponent } from './componentes/contatos/contatos.component';
import { DashboardsComponent } from './componentes/dashboards/dashboards.component';
import { PerfilComponent } from './componentes/perfil/perfil.component';
import { SpeakerComponent } from './componentes/speaker/speaker.component';
import { EventoDetalheComponent } from './componentes/events/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './componentes/events/evento-lista/evento-lista.component';

const routes: Routes = [
  {
    path: 'eventos', component: EventsComponent,
    children: [
      { path: 'detalhe/:id', component: EventoDetalheComponent},
      { path: 'detalhe', component: EventoDetalheComponent},
      { path: 'lista', component: EventoListaComponent},
    ]
},
  { path: 'contatos', component: ContatosComponent},
  { path: 'dashboards', component: DashboardsComponent},
  { path: 'perfil', component: PerfilComponent},
  { path: 'speaker', component: SpeakerComponent},
  { path: '', redirectTo: 'dashboards', pathMatch: 'full'},
  { path: '**', redirectTo: 'dashboards', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
