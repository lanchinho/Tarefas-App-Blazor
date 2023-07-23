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
using TarefasAppBlazor.Services.Model.Responses;
using TarefasAppBlazor.Services.Helpers;

namespace TarefasAppBlazor.UI.Pages
{
    public partial class CriarConta
    {
        //Definindo o modelo de dados do componente
        private CriarContaRequestModel model = new CriarContaRequestModel();
        //mensagens
        private string mensagemProcessamento;
        private string mensagemSucesso;
        private string mensagemErro;
        //função para capturar o SUBMIT do formulário
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";
            //limpar as mensagens
            mensagemSucesso = string.Empty;
            mensagemErro = string.Empty;
            try
            {
                //fazendo a requisição para o serviço de cadastro da API
                var servicesHelper = new ServicesHelper();
                var result = await servicesHelper.Post<CriarContaRequestModel, CriarContaResponseModel>("criarconta", model);
                mensagemSucesso = $"Parabéns {result.Nome}, sua conta de usuário foi cadastrada com sucesso!";
                model = new CriarContaRequestModel();
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