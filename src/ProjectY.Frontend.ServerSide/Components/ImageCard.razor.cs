using Microsoft.AspNetCore.Components;

namespace ProjectY.Frontend.ServerSide.Components
{
    /// <summary>
    /// Карточка с картинкой и подписью
    /// </summary>
    public partial class ImageCard : ComponentBase
    {
        /// <summary>
        /// Картинка
        /// </summary>
        public RenderFragment ImageSource { get; set; } = builder =>
            builder.AddContent(1, "<img alt=\"example\" src=\"/images/123.jpg\" /> ");

        /// <summary>
        /// Описание
        /// </summary>
        [Parameter]
        public string Description { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Parameter]
        public string Name { get; set; }
    }
}
