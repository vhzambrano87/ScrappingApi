using System;
using System.Runtime.Serialization;

namespace ScrappingApi.Model
{
    public class UserRequest
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool active { get; set; }
    }
}
