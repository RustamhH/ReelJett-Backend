using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelJett.Domain.DTO
{
    public class UserOperationDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string OperationTime { get; set; }
        public string ProfilePhoto { get; set; }
        public string Content { get; set; }
    }
}
