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
using TarefasAppBlazor.UI.Helpers;
using TarefasAppBlazor.Services.Model.Responses;
using TarefasAppBlazor.Services.Helpers;

namespace TarefasAppBlazor.UI.Pages.App
{
    public partial class Dashboard
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public AuthenticationHelper AuthenticationHelper { get; set; }

        private IList<DashboardResponseModel> dadosGrafico;
        private string mensagemProcessamento;
        private string mensagemErro;

        protected override async Task OnInitializedAsync()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";
            var usuario = await AuthenticationHelper.GetUser();

            try
            {
                var servicesHelper = new ServicesHelper(usuario.AccessToken);
                dadosGrafico = await servicesHelper.Get<List<DashboardResponseModel>>("dashboard");

                //executar a função js que gera o gráfico
                await JsRuntime.InvokeAsync<object>("createChart", dadosGrafico, "Quantidade de tarefas por categoria", "grafico");
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