using Microsoft.AspNetCore.Http;
using NewShore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Helpers
{
    public class FileHelper : IFileHelper
    {
        public async Task<List<string>> ReadFileAsync(IFormFile textFile)
        {
            try
            {
                Stream stream = textFile.OpenReadStream();

                string content;

                using (StreamReader fileReader = new StreamReader(stream, Encoding.UTF8))
                {
                    content = await fileReader.ReadToEndAsync();
                }


                string pattern = @"\r\n";

                List<string> List = System.Text.RegularExpressions.Regex.Split(content, pattern).ToList();


                return List;
            }

            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<string> CreateFiletxt(List<DetailsCustomerViewModel> detailsCustomerViewModels)
        {
            string file = "FileResult.txt";

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\archives", file);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream Filetxt = File.Create(path))
            {
                string document = string.Empty;
                int cont = 0;

                foreach (DetailsCustomerViewModel item in detailsCustomerViewModels)
                {
                    string state = "-->No Existe";

                    if (item.Exist)
                    {
                        state = "--> Existe";
                    }
                    if (cont == 0)
                    {
                        document = $"{item.Name}{state}";
                    }
                    else
                    {
                        document = $"{document}\r\n{item.Name}{state}";
                    }

                    cont++;

                }

                byte[] stream = new UTF8Encoding(true).GetBytes(document);

                await Filetxt.WriteAsync(stream, 0, stream.Length);
            }

            return path;

        }

        public async Task<byte[]> ByteTxtPlain()
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                string file = "FileResult.txt";

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\archives", file);

                StreamReader filetxt = File.OpenText(path);

                await filetxt.BaseStream.CopyToAsync(ms);

                filetxt.Close();

                return ms.ToArray();
            }

            catch (Exception)
            {

                throw;
            }

        }
    }
}
