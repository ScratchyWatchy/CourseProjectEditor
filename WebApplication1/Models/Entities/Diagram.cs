using WebApplication1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
  public class Diagram
  {
    public int Id { get; set; }
    public DiagramEditor User { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime EditeDateTime { get; set; }
  }
}
