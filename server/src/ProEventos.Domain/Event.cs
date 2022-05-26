using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Event
    {
        public int Id { get; set; }

        public string Local { get; set; }
    
        //? na frente do type = pode ser nula
        public DateTime? DataEvent { get; set; }

        public string Tema { get; set; }

        public int QntPessoas { get; set; }

        public string ImagemURL { get; set; }

        public string Telefone { get; set; }
        
        public string Email { get; set; }
        
        public IEnumerable<Lote> Lote { get; set; }
        public IEnumerable<RedeSocial> RedeSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
        
        
        
        




    }
}