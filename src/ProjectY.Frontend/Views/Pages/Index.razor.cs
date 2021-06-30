using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ProjectY.Frontend.Application.Services.ShoesService;

namespace ProjectY.Frontend.Views.Pages
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
        public IEnumerable<object> Shoes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

        }
    }
}
