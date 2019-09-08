using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceProyecto1.Models
{
    public class Provider
    {
        public Provider()
        {
            this.Id = 0;
            this.Name = "";
            this.Address = "";
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
