using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserDiagram
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
    }
}
