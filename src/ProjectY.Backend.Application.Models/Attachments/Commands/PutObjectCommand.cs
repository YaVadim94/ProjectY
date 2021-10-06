using System.IO;
using MediatR;

namespace ProjectY.Backend.Application.Models.Attachments.Commands
{
    /// <summary>
    /// Команда для помещения файла в хранилище
    /// </summary>
    public class PutObjectCommand : IRequest<AttachmentDto>
    {
        /// <summary> Ключ объекта </summary>
        public string Key { get; set; }

        /// <summary> Тип контента </summary>
        public string ContentType { get; set; }

        /// <summary> Поток к объекту </summary>
        public Stream InputStream { get; set; }

        /// <summary> Наименование файла </summary>
        public string FileName { get; set; }

        /// <summary> Размер файла </summary>
        public long FileSize { get; set; }
    }
}
