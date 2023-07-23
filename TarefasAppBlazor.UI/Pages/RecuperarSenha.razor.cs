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
using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Model.Requests;
using TarefasAppBlazor.Services.Model.Responses;

namespace TarefasAppBlazor.UI.Pages
{
    public partial class RecuperarSenha
    {
        //Definindo o modelo de dados do componente
        private RecuperarSenhaRequestModel model = new RecuperarSenhaRequestModel();
        //mensagens
        private string? mensagemProcessamento;
        private string? mensagemSucesso;
        private string? mensagemErro;
        //fun��o para capturar o SUBMIT do formul�rio
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";
            //limpar as mensagens
            mensagemSucesso = string.Empty;
            mensagemErro = string.Empty;
            try
            {
                //fazendo a requisi��o para o servi�o de recupera��o de senha da API
                var servicesHelper = new ServicesHelper();
                var result = await servicesHelper.Post<RecuperarSenhaRequestModel, RecuperarSenhaResponseModel>("recuperarsenha", model);
                mensagemSucesso = $"Ol� {result.Nome}, sua solicita��o de recupera��o de senha foi realizada com sucesso. Verifique a caixa de entrada do seu email.";
                model = new RecuperarSenhaRequestModel();
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