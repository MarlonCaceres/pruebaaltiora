using System;
namespace pruebaaltiora.Models
{
    public class ResponseModel
    {
        public bool status { get; set; }
        public object data { get; set; }
        public int error { get; set; }
        public string message { get; set; }

        public ResponseModel()
        {
            status = false;
            error = 0;
            message = null;
        }

    }

    public class PS_Error
    {
        public int ERROR { get; set; }
        public string MSM { get; set; }

        public PS_Error()
        {

        }
    }
}

