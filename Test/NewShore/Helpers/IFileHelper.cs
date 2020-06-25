using Microsoft.AspNetCore.Http;
using NewShore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewShore.Helpers
{
    public interface IFileHelper
    {
        Task<List<string>> ReadFileAsync(IFormFile textFile);

        Task<string> CreateFiletxt(List<DetailsCustomerViewModel> detailsCustomerViewModels);

        Task<byte[]> ByteTxtPlainAsync();
    }
}
