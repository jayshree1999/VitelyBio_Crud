﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitely.Core.Entities
{
    [Table("Department")]

    public class Department
    {
        [Key]
        public int DepartmentId{ get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}
