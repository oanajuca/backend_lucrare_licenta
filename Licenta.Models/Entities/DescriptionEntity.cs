using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models.Entities
{
    public class DescriptionEntity
    {
        public int Id { get; set; }
        public string Steps { get; set; }
        public string Indications { get; set; }
        public string Equipment { get; set; }
        public string Observations { get; set; }
        public int TrailId { get; set; }
        public string ShortDescription { get; set; }
    }
}
