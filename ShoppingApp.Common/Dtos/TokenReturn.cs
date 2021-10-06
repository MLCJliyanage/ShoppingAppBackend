using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Common.Dtos
{
    public class TokenReturn
    {
        public int id { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
}
