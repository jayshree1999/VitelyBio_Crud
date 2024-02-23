using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitely.Core.Entities;


namespace Vitely.Application.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Alphabet only please")]

        [Required]

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Alphabet only please")]

        [Required]

        [DisplayName("Last Name")]

        public string? LastName { get; set; }
        [DisplayName("Department Name")]
        public int DepartmentId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]

        [DisplayName("Salary")]

        public decimal Salary { get; set; }
        [Required]
        [DisplayName("Join Date")]
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }
    }
    
}
