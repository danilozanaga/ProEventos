import { Lote } from "./Lote";
import { RedeSocial } from "./RedeSocial";

export interface Evento {
  	id: number;
  	local: string;
  	dataEvento: Date;
  	tema: string;
  	qtdPessoas: number;
  	imagemUrl: string;
  	telefone: string;
  	email: string;
  	lotes: Lote[];
  	redesSociais: RedeSocial[];
  	palestrantesEventos: Evento[];
}
