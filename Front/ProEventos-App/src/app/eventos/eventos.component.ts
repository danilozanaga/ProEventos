import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements OnInit {

  public eventos: any = [];
  imgWidth: number = 180;
  imgMargin: number = 5;
  exibirImagem: boolean = true;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {

    this.getEventos();
  }

  alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void{
    this.http.get('http://localhost:5000/api/Eventos').subscribe(
      response => this.eventos = response,
      error => console.log(error));
  }


}
