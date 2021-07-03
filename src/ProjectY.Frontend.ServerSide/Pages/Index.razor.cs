﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using Microsoft.AspNetCore.Components;
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

        /// <summary>
        /// 
        /// </summary>
        public ImageLocale Locale = new ImageLocale { Preview = "Preview" };

        /// <summary>
        /// 
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Shoes = (await ShoesService.GetAll()).ToList();
            //Test = builder => builder.AddContent(1, "<img alt=\"example\" src=\"/images/123.jpg\" />");
        }

        /// <summary>
        /// 
        /// </summary>
        public RenderFragment Test { get; set; }
    }
}
