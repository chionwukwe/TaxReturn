using System;
using System.Collections.Generic;
using TaxReturn.Core;

namespace TaxReturn.Models
{
    public class FileUploadResultsViewModel
    {
        private readonly FileValidationResult _fileValidationResult;
       
        public FileUploadResultsViewModel(FileValidationResult fileValidationResult)
        {
            _fileValidationResult = fileValidationResult;
        }

        public string NumberOfLinesIgnored { get { return String.Concat("Number of Lines Ignored ", _fileValidationResult.NumberOfLinesIgnored.ToString()); } }

        public string NumberOfLinesUploaded { get { return String.Concat("Number of Lines Uploaded", _fileValidationResult.NumberOfLinesUploaded.ToString()); } }

        public Dictionary<int, List<string>> ErrorMessages { get { return _fileValidationResult.ValidationResults; } }

        public bool Valid { get { return _fileValidationResult.NumberOfLinesIgnored == 0; } }
    }
}