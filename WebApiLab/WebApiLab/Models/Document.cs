using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLab.Models
{
    public class Document
    {
        public string Title { get; set; }
        public int? NumberOfPages { get; set; }
        public bool? HasSummary { get; set; }
        public DateTime PublishedFrom { get; set; }
        public double Price { get; set; }
        public string Type { get; set; } //Kan binda till enum
        public List<string> TagList { get; set; }
        public int? Rating { get; set; }
    }
}
