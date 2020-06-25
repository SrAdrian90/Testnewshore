using NewShore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewShore.Helpers
{
    public interface IFilterCustomer
    {
        Task<List<DetailsCustomerViewModel>> FilterCustumerAsync(List<string> ListRegisters, List<string> ListConten);

    }
}
