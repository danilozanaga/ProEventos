import { Component, Inject, OnInit, TemplateRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Evento } from '../../interface/Evento';
import { EventoService } from '../../services/evento.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})

export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public imgWidth: number = 180;
  public imgMargin: number = 5;
  public exibirImagem: boolean = true;
  public _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
      this._filtroLista  = value;
      this.eventosFiltrados = (this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos );
  }

  public filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: {tema: string; local: string}) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void{
    const observer = {
      next: (eventos: Evento[]) => {
        this.eventos = eventos,
        this.eventosFiltrados = eventos
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos!', 'Erro!');
        console.log(error)
      },
      complete: () => this.spinner.hide()
    }
    this.eventoService.getEvento().subscribe(observer);
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O evento foi excluido com sucesso!', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
