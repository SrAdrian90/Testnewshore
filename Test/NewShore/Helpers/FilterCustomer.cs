using NewShore.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NewShore.Helpers
{
    public class FilterCustomer : IFilterCustomer
    {
        private readonly IFileHelper _fileHelper;

        public FilterCustomer(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        public async Task<List<DetailsCustomerViewModel>> FilterCustumerAsync(List<string> ListRegisters, List<string> ListConten)
        {

            bool ConfirmRange = false;

            string file = "FileResult.txt";

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\archives", file);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            List<QuantityLetter> ListLetters = new List<QuantityLetter>();

            List<DetailsCustomerViewModel> CustomerOk = new List<DetailsCustomerViewModel>();

            foreach (string letter in ListConten)
            {
                if (!ListLetters.Exists(l => l.Letter == letter))
                {
                    ListLetters.Add(new QuantityLetter
                    {
                        Letter = letter,
                        Quantity = 1
                    });
                }
                else
                {
                    QuantityLetter LetterExit = ListLetters.Where(l => l.Letter == letter).FirstOrDefault();
                    LetterExit.Quantity += 1;
                }
            }


            for (int i = 0; i < ListRegisters.Count; i++)
            {
                string nameClientGenerate = string.Empty;

                List<WordGeneric> wordGeneric = new List<WordGeneric>();

                int LenghtName = ListRegisters[i].Length;


                for (int k = 0; k < LenghtName; k++)
                {
                    string LetterinPosition = ListRegisters[i].Substring(k, 1);

                    for (int j = 0; j < ListLetters.Count; j++)
                    {
                        if (ListLetters[j].Quantity != 0)
                        {

                            if (LetterinPosition == ListLetters[j].Letter)
                            {
                                wordGeneric.Add(new WordGeneric
                                {
                                    Letter = ListLetters[j].Letter,
                                    Position = k

                                });

                                if (wordGeneric.Count == ListRegisters[i].Length)
                                {
                                    ListLetters[j].Quantity = ListLetters[j].Quantity - 1;
                                }
                            }
                        }
                    }
                }


                for (int u = 0; u < wordGeneric.Count; u++)
                {
                    if (wordGeneric[u].Position == u)
                    {
                        ConfirmRange = true;
                    }
                    else
                    {
                        ConfirmRange = false;
                    }
                }


                if (ConfirmRange)
                {

                    foreach (WordGeneric word in wordGeneric.OrderBy(p => p.Position))
                    {
                        nameClientGenerate = nameClientGenerate.Insert(word.Position, word.Letter);
                    }

                    bool ValidateCustumer = ListRegisters.Exists(c => c == nameClientGenerate);

                    if (ValidateCustumer)
                    {
                        DetailsCustomerViewModel custumer = new DetailsCustomerViewModel
                        {
                            Name = nameClientGenerate,
                            Exist = true

                        };

                        CustomerOk.Add(custumer);
                    }
                }
            }


            foreach (string Register in ListRegisters)
            {
                if (!CustomerOk.Exists(n => n.Name == Register))
                {
                    DetailsCustomerViewModel customerX = new DetailsCustomerViewModel
                    {
                        Exist = false,
                        Name = Register
                    };
                    CustomerOk.Add(customerX);
                }
            }

            //To Create .Txt

            var patch = await _fileHelper.CreateFiletxt(CustomerOk);

            return CustomerOk;

        }
        public class QuantityLetter
        {
            public string Letter { get; set; }

            public int Quantity { get; set; }

        }

        public class WordGeneric
        {
            public string Letter { get; set; }
            public int Position { get; set; }
        }
    }
}
