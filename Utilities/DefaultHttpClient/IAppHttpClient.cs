using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace helloralph.Utilities.DefaultHttpClient
{
    public interface IAppHttpClient
    {
        public HttpClient Default { get; }
        public HttpClient DummyApi { get; }
        public JsonSerializerOptions DefaultSerializerOptions { get; }

    }
}
