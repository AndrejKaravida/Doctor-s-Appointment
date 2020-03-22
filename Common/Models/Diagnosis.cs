using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } 
    }
}
