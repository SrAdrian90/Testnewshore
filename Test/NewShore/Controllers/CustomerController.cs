using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal;
using NewShore.Helpers;
using NewShore.Models;
using System.Collections.Generic;
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
                    List<string> ListRegisters = await _fileHelper.ReadFileAsync(model.RegisteredFile);

                    List<string> ListConten = await _fileHelper.ReadFileAsync(model.ContenFile);

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


        public async Task<FileContentResult> FileResult()
        {
            try
            {
                var file = await _fileHelper.ByteTxtPlainAsync();

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
