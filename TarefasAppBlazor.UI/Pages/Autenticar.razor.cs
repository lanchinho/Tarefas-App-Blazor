using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using TarefasAppBlazor.UI;
using TarefasAppBlazor.UI.Shared;
using TarefasAppBlazor.Services.Model.Requests;
using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Model.Responses;

namespace TarefasAppBlazor.UI.Pages
{
    public partial class Autenticar
    {
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
                model = new AutenticarRequestModel();
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

}