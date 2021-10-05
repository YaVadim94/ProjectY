namespace ProjectY.Backend.Application.AmazonS3.Models
{
    /// <summary>
    /// Дто для удаления объекта из хранилица
    /// </summary>
    public class DeleteObjectDto
    {
        /// <summary> Ключ объекта </summary>
        public string Key { get; set; }

        /// <summary> Наименование бакета </summary>
        public string BucketName { get; set; }
    }
}
