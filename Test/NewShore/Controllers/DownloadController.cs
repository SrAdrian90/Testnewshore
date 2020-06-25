using Microsoft.AspNetCore.Mvc;
using NewShore.Helpers;
using System.Threading.Tasks;

namespace NewShore.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IFileHelper _fileHelper;


        public DownloadController(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        public async Task<FileContentResult> FileResult()
        {
            try
            {
                byte[] file = await _fileHelper.ByteTxtPlainAsync();

                string contentType = "text/html";

                return File(file, contentType, "Result.txt");

            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }

}
