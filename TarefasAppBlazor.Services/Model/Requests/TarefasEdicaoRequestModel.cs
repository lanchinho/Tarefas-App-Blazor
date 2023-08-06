using System.ComponentModel.DataAnnotations;

namespace TarefasAppBlazor.Services.Model.Requests
{
    public class TarefasEdicaoRequestModel
    {
        public Guid? Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Entre com o nome da tarefa:")]
        [Required(ErrorMessage = "Por favor, informe o nome da tarefa.")]
        public string? Nome { get; set; }

        [Display(Name = "Data e hora de início:")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Por favor, informe a data de início.")]
        public DateTime? DataInicio { get; set; }

        [Display(Name = "Data e hora de término:")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Por favor, informe a data de término.")]
        public DateTime? DataFim { get; set; }

        [Display(Name = "Selecione a categoria desta tarefa:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Por favor, selecione a categoria.")]
        public string? Categoria { get; set; }

        [Display(Name = "Informe a descrição da tarefa:")]
        [DataType(DataType.MultilineText)]
        public string? Descricao { get; set; }
    }
}
