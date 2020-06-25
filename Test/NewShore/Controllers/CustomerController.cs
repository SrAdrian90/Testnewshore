using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal;
using NewShore.Helpers;
using NewShore.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace NewShore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IFileHelper _fileHelper;
        private readonly IFilterCustomer _filterCustomer;

        public CustomerController(IFileHelper fileHelper, IFilterCustomer filterCustomer)
        {
            _fileHelper = fileHelper;
            _filterCustomer = filterCustomer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Analyze(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Stream streamRegisterFile = model.RegisteredFile.OpenReadStream();

                    Stream streamContentFile = model.ContenFile.OpenReadStream();

                    List<string> ListRegisters = await _fileHelper.ReadFileAsync(streamRegisterFile);

                    List<string> ListConten = await _fileHelper.ReadFileAsync(streamContentFile);

                    List<DetailsCustomerViewModel> CustomersFilter = await _filterCustomer.FilterCustumerAsync(ListRegisters, ListConten);

                    return View(CustomersFilter.OrderBy(n => n.Name));

                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex);
                }

            }

            return View(model);

        }

    }
}
