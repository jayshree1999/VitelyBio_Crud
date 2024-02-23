using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitely.Application.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Alphabet only please")]

        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}
