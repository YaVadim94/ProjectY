namespace ProjectY.Frontend.Application.Models.Files
{
    /// <summary>
    /// Модель для загрузки файла
    /// </summary>
    public class FileUploadModel
    {
        /// <summary> Наименование файла </summary>
        public string Name { get; set; }

        /// <summary> Размер файла </summary>
        public long Size { get; set; }

        /// <summary> Адрес файла </summary>
        public string Url { get; set; }
    }
}
