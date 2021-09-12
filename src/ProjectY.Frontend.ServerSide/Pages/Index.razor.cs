﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using ProjectY.Frontend.Application.Services.FileService;
using ProjectY.Frontend.Application.Services.ShoesService;
using ProjectY.Shared.Contracts.AttachmentsController;
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

        [Inject]
        private IFileService FileService { get; set; }

        /// <summary>
        /// Список обуви
        /// </summary>
        [Parameter]
        public List<ShoesContracts> Shoes { get; set; } = new List<ShoesContracts>();

        private const int rowElementCount = 4;
        private int showedCardCount = 0;

        private string ImageUrl { get; set; }

        /// <summary>
        /// Инициалзация
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await AddRow();
        }

        private async Task AddRow()
        {
            var row = await ShoesService.GetAll($"?$top={rowElementCount}&skip={Shoes.Count}");
            Shoes.AddRange(row);
        }

        private RenderFragment ShowPicture() =>
            builder => builder.AddMarkupContent(1, "<img alt=\"example\" src=\"/images/321.png\"/>");

        private void OnSingleCompleted(UploadInfo fileinfo)
        {
            if (fileinfo.File.State == UploadState.Success)
            {
                fileinfo.File.Url = JsonConvert.DeserializeObject<AttachmentContract>(fileinfo.File.Response).Url;
                ImageUrl = JsonConvert.DeserializeObject<AttachmentContract>(fileinfo.File.Response).Url;
            }
        }

        async Task<bool> HandleRemove(UploadFileItem file)
        {
            return await Task.FromResult(true);
        }

        //private async Task<bool> HandleUpload(IEnumerable<UploadFileItem> files)
        //{
        //    var uploadModel = files
        //        .Select(x => new FileUploadModel { Name = x.FileName, Size = x.Size, Url = x.ObjectURL })
        //        .First();

        //    await FileService.UploadFile(uploadModel);

        //    return await Task.FromResult(false);
        //}

    }
}
