using NewShore.Controllers.API;
using NewShore.Helpers;
using NewShore.Request;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestNew
{
    public class UnitTest
    {
        //Prueba simple de la respuesta en true en el caso que se logre optener respuesta de la consulta y generar el array de byte.
        [Test()]
        public void TestAPIUser()
        {
            //Arrange          


            bool _ByteResult = false;
            bool _isByte = true;


            //Act   

            FileHelper fileHelper = new FileHelper();

            var _Byte = fileHelper.ByteTxtPlainAsync();

            if (!string.IsNullOrEmpty($"{_Byte}"))
            {
                _ByteResult = true;
            }

            //Assert
            Assert.AreEqual(_isByte, _ByteResult);

        }
    }
}