using System;
namespace Post_Surfer.Contract
{
    public class UpdatePostRequest
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public  DateTime Time { get; set; }
    }
}
