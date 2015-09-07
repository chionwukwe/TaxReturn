using System.IO;

namespace TaxReturn.Core
{
    public interface IUploadFileContentService
    {
        FileValidationResult UploadFile(Stream inputStream);
    }
}
