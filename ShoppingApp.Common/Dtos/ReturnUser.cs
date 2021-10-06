using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Common.Dtos
{
    public class ReturnUser
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
        public bool isValid { get; set; }
    }
}
