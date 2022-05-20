namespace ProEventos.API.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string Local { get; set; }
        
        public string DataEvent { get; set; }
        
        public string Tema { get; set; }

        public int QntPessoas { get; set; }
        
        public string Lote { get; set; }
        
        public string ImagemURL { get; set; }     
        
        
    }
}