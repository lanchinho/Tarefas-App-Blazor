using System.ComponentModel.DataAnnotations;

namespace TarefasAppBlazor.Services.Model.Requests
{
    public class RecuperarSenhaRequestModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Entre com o seu email:", Prompt = "Ex: joaodasilva@gmail.com")]
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email de acesso.")]
        public string? Email { get; set; }
    }
}
