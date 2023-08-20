using System.ComponentModel.DataAnnotations;

namespace TarefasAppBlazor.Services.Model.Requests
{
    public class AlterarSenhaRequestModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Entre com a sua senha atual:")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Por favor, informe uma senha forte (letras maiúsculas, letras minúsculas, números, símbolos e pelo menos 8 caracteres).")]
        [Required(ErrorMessage = "Por favor, informe sua senha de acesso atual.")]
        public string? SenhaAtual { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Entre com a sua nova senha:")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Por favor, informe uma senha forte (letras maiúsculas, letras minúsculas, números, símbolos e pelo menos 8 caracteres).")]
        [Required(ErrorMessage = "Por favor, informe sua nova senha de acesso.")]
        public string? NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a sua nova senha:")]
        [Compare("NovaSenha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme sua nova senha de acesso.")]
        public string? NovaSenhaConfirmacao { get; set; }
    }
}
