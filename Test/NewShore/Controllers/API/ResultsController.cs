using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewShore.Helpers;
using NewShore.Models;
using NewShore.Request;


namespace NewShore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IFileHelper _fileHelper;
        private readonly IFilterCustomer _filterCustomer;

        public ResultsController(IFileHelper fileHelper, IFilterCustomer filterCustomer)
        {
            _fileHelper = fileHelper;
            _filterCustomer = filterCustomer;
        }


        [HttpPost]
        [Route("ResultFilter")]
        public async Task<IActionResult> GetResultFilter(ResultFilterRequest resultFilterRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (resultFilterRequest.ContenArray != null && resultFilterRequest.ContenArray.Length > 0 &&
                resultFilterRequest.RegisterArray.Length > 0 && resultFilterRequest != null)
            {

                MemoryStream streamRegisterFile = new MemoryStream(resultFilterRequest.RegisterArray);
                MemoryStream streamContentFile = new MemoryStream(resultFilterRequest.ContenArray);

                List<string> ListRegisters = await _fileHelper.ReadFileAsync(streamRegisterFile);

                List<string> ListConten = await _fileHelper.ReadFileAsync(streamContentFile);

                List<DetailsCustomerViewModel> CustomersFilter = await _filterCustomer.FilterCustumerAsync(ListRegisters, ListConten);

                byte[] resultData = await _fileHelper.ByteTxtPlainAsync();

                return Ok(resultData);

            }


            return BadRequest("Please enter a valid byte set");


        }

    }
}
