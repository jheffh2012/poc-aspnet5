namespace poc.AspNet5.Ioc.Entities
{
    public class EventoConfirmacao : BaseModel
    {
        public int IdEvento { get; set; }
        public int IdUsuario { get; set; }

        public Evento Evento { get; set; }
        public Usuario Usuario { get; set; }
    }
}
