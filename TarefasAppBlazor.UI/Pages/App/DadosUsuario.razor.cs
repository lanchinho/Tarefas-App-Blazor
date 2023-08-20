using Microsoft.AspNetCore.Components;
using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Model.Requests;
using TarefasAppBlazor.Services.Model.Responses;
using TarefasAppBlazor.UI.Helpers;

namespace TarefasAppBlazor.UI.Pages.App
{
    public partial class DadosUsuario
    {
        [Inject]
        public AuthenticationHelper AuthenticationHelper { get; set; }

        private AutenticarResponseModel usuario = new();
        private AlterarSenhaRequestModel model = new();

        private string mensagemProcessamento;
        private string mensagemSucesso;
        private string mensagemErro;

        protected override async Task OnInitializedAsync()
        {
            usuario = await AuthenticationHelper.GetUser();
        }

        //método para capturar o Submit do formulário
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";
            mensagemSucesso = string.Empty;
            mensagemErro = string.Empty;

            try
            {
                var servicesHelper = new ServicesHelper(usuario.AccessToken);
                await servicesHelper.Post<AlterarSenhaRequestModel, AlterarSenhaResponseModel>("alterarsenha", model);

                mensagemSucesso = "Senha de acesso atualizada com sucesso.";
                model = new();
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
            }
            finally
            {
                mensagemProcessamento = string.Empty;
            }
        }
    }
}