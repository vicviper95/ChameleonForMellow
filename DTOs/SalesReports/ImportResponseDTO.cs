using System.Collections.Generic;

namespace Chameleon.DTOs.SalesReports
{
    public class ImportResponseDTO
    {
        public bool errorOnImport { get; set; }
        public List<string> errorMessages { get; set; }
    }
}
