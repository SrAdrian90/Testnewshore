using Microsoft.AspNetCore.Http;
using NewShore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewShore.Helpers
{
    public interface IFileHelper
    {
        Task<List<string>> ReadFileAsync(Stream textFile);

        Task<string> CreateFiletxtAsync(List<DetailsCustomerViewModel> detailsCustomerViewModels);

        Task<byte[]> ByteTxtPlainAsync();
    }
}
