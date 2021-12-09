using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorySystem.Models
{
    public class CustomActionResult
    {
        public int Status { get; set; } = 0;
        public bool IsSuccess { get; set; }
        public string Msg { get; set; } = "失败";
        public object Datas { get; set; }
    }
}
