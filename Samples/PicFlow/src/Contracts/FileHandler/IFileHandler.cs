using System.IO;
using System.Threading.Tasks;

namespace FP.Spartakiade2017.PicFlow.Contracts.FileHandler
{
    public interface IFileHandler
    {
        Task<FileUploadResult> HandleUpload(string fileName, Stream stream);
    }
}
