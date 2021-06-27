using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ProjectY.Frontend.Models;
using ProjectY.Frontend.Services.TestService;

namespace ProjectY.Frontend.Views.Pages
{
    /// <summary>
    /// Логика главное страницы
    /// </summary>
    public partial class Index : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Inject]
        public ITestService Service { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public Home Home { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public async Task CreateHome()
        {
            await Service.CreateHome(Home);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Home = new Home();
        }
    }
}
