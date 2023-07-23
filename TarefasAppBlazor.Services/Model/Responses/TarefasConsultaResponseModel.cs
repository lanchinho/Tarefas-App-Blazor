namespace TarefasAppBlazor.Services.Model.Responses
{
    public class TarefasConsultaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? DataInicio { get; set; }
        public string? DataFim { get; set; }
        public string? Categoria { get; set; }
        public string? Descricao { get; set; }
    }
}
