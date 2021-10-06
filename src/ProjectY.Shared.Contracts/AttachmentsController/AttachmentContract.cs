namespace ProjectY.Shared.Contracts.AttachmentsController
{
    /// <summary>
    /// Контракт приложения
    /// </summary>
    public class AttachmentContract
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Адрес </summary>
        public string Url { get; set; }
    }
}
