using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecLog.Domain.DTO
{
    public class LogDTO
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Server { get; set; }
        public string Process { get; set; }
        public string Description { get; set; }
    }
}
