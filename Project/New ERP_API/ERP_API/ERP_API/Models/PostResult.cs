using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class PostResult
    {
        public string errorMessge { get; set; }
        public bool isSuccess { get; set; }

        public PostResult( string errorMessage)
        {
            this.isSuccess = false;
            this.errorMessge = errorMessage;
        }
        public PostResult(bool status)
        {
            this.isSuccess = status;
            this.errorMessge = "";
        }
    }
}
