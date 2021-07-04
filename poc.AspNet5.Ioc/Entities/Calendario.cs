using System.Collections.Generic;

namespace poc.AspNet5.Ioc.Entities
{
    public class Calendario : BaseModel
    {
        public string Nome { get; set; }
        public int IdEquipe { get; set; }
        public Equipe Equipe { get; set; }

        public ICollection<Evento> Eventos { get; set; }
    }
}
