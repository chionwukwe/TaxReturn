using System.Collections.Generic;
using System.Linq;

namespace TaxReturn.Core
{
    public class FileValidationResult
    {
        public FileValidationResult()
        {
            ValidationResults = new Dictionary<int, List<string>>();
        }

        public int NumberOfLinesUploaded { get; set; }
        public int NumberOfLinesIgnored { get; set; }

        public Dictionary<int,List<string>> ValidationResults { get; set; }

        public bool Valid { get { return !ValidationResults.Any(); } }
    }
}
