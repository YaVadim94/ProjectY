namespace ProjectY.Backend.Application.Models.Attachments
{
    /// <summary>
    /// Дто приложения(объекта)
    /// </summary>
    public class AttachmentDto
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Ключ объекта </summary>
        public string Key { get; set; }

        /// <summary> Имя файла </summary>
        public string FileName { get; set; }

        /// <summary> Тип контента </summary>
        public string ContentType { get; set; }

        /// <summary> Размер файла </summary>
        public long FileSize { get; set; }

        /// <summary> Адрес объекта </summary>
        public string Url { get; set; }
    }
}
