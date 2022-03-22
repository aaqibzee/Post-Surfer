using System.Collections.Generic;

namespace Post_Surfer.Contract.V1.Response
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; }= new List<ErrorModel>();
    }
}
