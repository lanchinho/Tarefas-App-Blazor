using TarefasAppBlazor.Services.Model.Requests;
using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Model.Responses;
using TarefasAppBlazor.UI.Helpers;
using Microsoft.AspNetCore.Components;

namespace TarefasAppBlazor.UI.Pages
{
    public partial class Autenticar
    {
        [Inject]
        private AuthenticationHelper AuthenticationHelper { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        //Definindo o modelo de dados do componente
        private AutenticarRequestModel model = new();

        //mensagens
        private string? mensagemProcessamento;
        private string? mensagemSucesso;
        private string? mensagemErro;       

        //fun��o para capturar o SUBMIT do formul�rio
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";
            mensagemSucesso = string.Empty;
            mensagemErro = string.Empty;

            try
            {
                //fazendo a requisi��o para o servi�o de cadastro da API
                var servicesHelper = new ServicesHelper();
                var result = await servicesHelper.Post<AutenticarRequestModel, AutenticarResponseModel>("autenticar", model);
                mensagemSucesso = $"Parab�ns {result.Nome}, autentica��o realizada com sucesso!";
                model = new AutenticarRequestModel(); //limpar formul�rio

                await AuthenticationHelper.SignIn(result);

                NavigationManager.NavigateTo("app/dashboard", true);
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