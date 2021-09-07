namespace ProjectY.Backend.Data.Entities
{
    /// <summary>
    /// Приложение(объект)
    /// </summary>
    public class Attachment : EntityBase
    {
        /// <summary> Ключ объекта </summary>
        public string Key { get; set; }

        /// <summary> Бакет объекта </summary>
        public string Bucket { get; set; }

        /// <summary> Имя файла </summary>
        public string FileName { get; set; }

        /// <summary> Тип контента </summary>
        public string ContentType { get; set; }

        /// <summary> Размер файла </summary>
        public long FileSize { get; set; }

    }
}
