using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceProyecto1.Models
{
    public class Answer
    {
        public Answer()
        {
            //this.Code = 0 ;
            this.Status = 0;
            this.Code = "";
        }
        public int Status { get; set; }

        // public int Code{ get; set; }

        public string Code { get; set; }
    }
}
