using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ProjectY.Frontend.Application.Brokers.Odata;
using ProjectY.Frontend.Application.Services.ShoesService;
using ProjectY.Shared.Contracts.ShoesController;

namespace ProjectY.Frontend.ServerSide.Pages
{
    /// <summary>
    /// Логика главной страницы
    /// </summary>
    public partial class Index : ComponentBase
    {
        [Inject]
        private IShoesService ShoesService { get; set; }

        /// <summary>
        /// Список обуви
        /// </summary>
        [Parameter]
        public List<ShoesContracts> Shoes { get; set; } = new List<ShoesContracts>();

        private const int rowElementCount = 4;

        /// <summary>
        /// Инициалзация
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await AddRow();
        }

        private async Task AddRow()
        {
            var row = await ShoesService.GetAll($"?$top={rowElementCount}&skip={Shoes.Count}");
            Shoes.AddRange(row);
        }

        private RenderFragment ShowPicture() =>
            builder => builder.AddMarkupContent(1, "<img alt=\"example\" src=\"/images/321.png\"/>");

        private void Test()
        {
            var test = new FilterODataQueryBroker<ShoesContracts>();
            test.GetEqualityQuery(x => x.Name, "ololo");
        }
    }
}
