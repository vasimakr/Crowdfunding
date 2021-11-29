using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.dto
{

        public class ApiResponse<T>
        {

            public T Data { get; set; }
            public int StatusCode { get; set; }

            public string Description { get; set; }

        }
}