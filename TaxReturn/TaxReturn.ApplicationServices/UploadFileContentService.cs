using System.Collections.Generic;
using System.IO;
using TaxReturn.Core;
using TaxReturn.Repository.Interfaces;

namespace TaxReturn.ApplicationServices
{
    public class UploadFileContentService : IUploadFileContentService
    {
        private readonly IRepositoryFactory _repositoryFactory;
       
        public UploadFileContentService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public FileValidationResult UploadFile(Stream inputSteam)
        {
            var validationResult = new FileValidationResult();

            using (StreamReader sr = new StreamReader(inputSteam))
            {
                string currentLine;
                var count = 0;
               
                while ((currentLine = sr.ReadLine()) != null)
                {
                   var splitData = currentLine.Split(',');
                    if (splitData.Length < 4)
                    {
                        validationResult.NumberOfLinesIgnored++;
                        validationResult.ValidationResults.Add(count, new List<string>{"Incomplete Data"});
                    }
                    else
                    {
                        if (!RowIsHeadingOfTheFile(splitData))
                        {
                            var accountTransaction = new AccountTransaction(splitData[0], splitData[1], splitData[2],
                                (splitData[3]));

                            if (accountTransaction.Valid())
                            {
                                validationResult.NumberOfLinesUploaded++;
                                using (var context = _repositoryFactory.Create())
                                {
                                    context.Save(accountTransaction);
                                }
                            }
                            else
                            {
                                validationResult.NumberOfLinesIgnored++;
                                validationResult.ValidationResults.Add(count, accountTransaction.ErrorMessages);
                            }
                        }
                    }
                    count++;
                }
            }
            return validationResult;
        }

        private bool RowIsHeadingOfTheFile(string[] row)
        {
            if (row[0].ToLower() == "account" && row[1].ToLower() == "description" && row[2].ToLower() == "currencycode" &&
                row[3].ToLower() == "amount")
                return true;
            return false;
        }
    }
}
