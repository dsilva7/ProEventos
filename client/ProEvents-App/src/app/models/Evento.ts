import { Lote } from './Lote';
import { Palestrante } from './Palestrante';
import { RedeSocial } from './RedeSocial';

export interface Evento {
  id: number;
  local: string;
  dataEvent?: Date;
  tema: string;
  qntPessoas: number;
  imagemURL: string;
  telefone: string;
  email: string;
  lote: Lote[];
  redeSociais: RedeSocial[];
  palestrantesEventos: Palestrante[];
}
