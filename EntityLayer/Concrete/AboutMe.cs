using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AboutMe
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string MyName { get; set; }

        [StringLength(30)]
        public string MyLastName { get; set; }

        [StringLength(30)]
        public string MyUniversity {get; set;}

        [StringLength(30)]
        public string propertyone { get; set; }

        [StringLength(30)]
        public string propertytwo { get; set; }

        [StringLength(30)]
        public string propertythree { get; set; }

        [StringLength(30)]
        public string propertyfour { get; set; }
    }
}
