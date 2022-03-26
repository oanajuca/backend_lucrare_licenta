using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models.Entities
{
    public class ReviewEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Stars { get; set; }
        public int UserId { get; set; }
    }
}
