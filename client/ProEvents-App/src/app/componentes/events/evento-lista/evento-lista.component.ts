import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

  modalRef?: BsModalRef;
  public events: Evento[] = [];
  public eventsFiltrados: Evento[] = [];

  public widthImg = 100;
  public marginImg = 2;
  public showImage = true;
  private filterListado = '';

  public get filterList(): string {
    return this.filterListado;
  }

  public set filterList(value: string) {
    this.filterListado = value;
    this.eventsFiltrados = this.filterList
      ? this.filtrarEvents(this.filterList)
      : this.events;
  }

  public filtrarEvents(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.events.filter(
      (event: { tema: string; local: string }) =>
        event.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        event.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  /**
   *
   */
  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) {}

  public ngOnInit(): void {
    this.spinner.hide();
    this.getEvents();
  }

  public hideImage(): void {
    this.showImage = !this.showImage;
  }

  public getEvents(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventosResp: Evento[]) => {
        this.events = eventosResp;
        this.eventsFiltrados = this.events;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregador os Eventos', 'Error!');
      },
      complete: () => this.spinner.hide(),
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Evento foi deletado com Sucesso', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheEvento(id: number): void{
    this.router.navigate([`/eventos/detalhe/${id}`]);
  }

}
