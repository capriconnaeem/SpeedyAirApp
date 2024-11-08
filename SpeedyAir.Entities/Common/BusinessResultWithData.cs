using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Entities.Common
{
    public class BusinessResultWithData<T> : BusinessResult
    {
        public T Data { get; set; }
    }
    public class BusinessResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }
        private bool IsSuccess;

        public bool IsSucceeded
        {
            get { return IsSuccess; }
            set { IsSuccess = StatusCode == HttpStatusCode.OK; }
        }

    }
}
