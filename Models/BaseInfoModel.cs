using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.Models
{
    public class BaseInfoModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Definition { get; set; }
        public bool HasToggle { get; set; }
        public object Tag { get; set; }
        public bool IsEnabled { get; set; } = true;

    }
}
