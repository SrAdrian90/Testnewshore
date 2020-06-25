
using NewShore.Controllers.API;
using NewShore.Helpers;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NUnitTest
{
    public class TesApi
    {
        //Prueba simple de la respuesta en false en el caso que no se logre optener respuesta de la consulta.

        [Test()]
        public async Task TestAPI()
        {
            //Arrange          

            byte[] result = null;

            FileHelper _fileHelper = new FileHelper();

            //Act          

            byte[] ResultData = await _fileHelper.ByteTxtPlainAsync();

            //Assert
            Assert.AreEqual(result, ResultData);

        }
    }
}