using System.ComponentModel.DataAnnotations;

namespace TarefasAppBlazor.Services.Model.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição de autenticação de usuários.
    /// </summary>
    public class AutenticarRequestModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Entre com o seu e-mail.", Prompt = "Ex: guicalbuquerque@gmail.com")]
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de e-mail válido.")]
        [Required(ErrorMessage = "Por favor, informe seu e-mail de acesso.")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Entre com a sua senha:")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo 8 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe sua senha de acesso.")]
        public string? Senha { get; set; }
    }
}
