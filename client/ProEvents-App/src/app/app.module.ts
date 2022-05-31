import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventsComponent } from './componentes/events/events.component';
import { SpeakerComponent } from './componentes/speaker/speaker.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './shared/nav/nav.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { EventoService } from './services/evento.service';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { ContatosComponent } from './componentes/contatos/contatos.component';
import { DashboardsComponent } from './componentes/dashboards/dashboards.component';
import { PerfilComponent } from './componentes/user/perfil/perfil.component';
import { TituloComponent } from './shared/titulo/Titulo.component';
import { EventoDetalheComponent } from './componentes/events/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './componentes/events/evento-lista/evento-lista.component';
import { UserComponent } from './componentes/user/user.component';
import { RegistrationComponent } from './componentes/user/registration/registration.component';

@NgModule({
  declarations: [
    AppComponent,
    EventsComponent,
    SpeakerComponent,
    NavComponent,
    DateTimeFormatPipe,
    ContatosComponent,
    DashboardsComponent,
    PerfilComponent,
    TituloComponent,
    EventoDetalheComponent,
    EventoListaComponent,
    UserComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
    }),
    NgxSpinnerModule,
  ],
  providers: [EventoService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
