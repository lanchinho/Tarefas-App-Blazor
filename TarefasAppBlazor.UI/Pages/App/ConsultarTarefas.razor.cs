using Microsoft.AspNetCore.Components;
using TarefasAppBlazor.UI.Helpers;
using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Model.Responses;

namespace TarefasAppBlazor.UI.Pages.App
{
	public partial class ConsultarTarefas
	{
		[Inject]
		AuthenticationHelper AuthenticationHelper { get; set; }

		private List<TarefasConsultaResponseModel> model = new();

		//mensagens
		private string? mensagemProcessamento;
		private string? mensagemErro;

		protected override async Task OnInitializedAsync()
		{
			try
			{
				mensagemProcessamento = "Processando, por favor aguarde...";

				var user = await AuthenticationHelper.GetUser();

				var servicesHelper = new ServicesHelper(user.AccessToken);
				model.AddRange(await servicesHelper.Get<List<TarefasConsultaResponseModel>>("tarefas"));
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


