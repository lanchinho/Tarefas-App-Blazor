namespace TarefasAppBlazor.Services.Model.Responses
{
    public class TarefasConsultaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Categoria { get; set; }
        public string? Descricao { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}
