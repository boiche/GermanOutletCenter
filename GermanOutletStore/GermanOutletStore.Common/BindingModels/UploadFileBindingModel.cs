using Microsoft.AspNetCore.Http;

namespace GermanOutletStore.Common.BindingModels
{
    public class UploadFileBindingModel
    {
        public IFormFile UploadedFile { get; set; }
    }
}
