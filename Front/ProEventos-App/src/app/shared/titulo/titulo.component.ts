import { Router } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo : string;
  @Input() subtitulo : string = 'Desde 2021'
  @Input() iconclass : string = 'fa fa-user';
  @Input() botaoListar : boolean = false;

  constructor(private router: Router ) {
    this.titulo = '';
   }

  ngOnInit(): void {

  }

  listar(): void{
    this.router.navigate([`/${this.titulo.toLocaleLowerCase()}/lista`])
  }

}
