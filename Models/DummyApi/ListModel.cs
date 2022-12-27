using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace helloralph.Models.DummyApi
{
    public class ListModel
    {
        public IEnumerable<UserModel> Data { get; set; }

        public int Total { get; set; }

        public int Page { get; set; }

        public int Limit { get; set; }
    }
}
