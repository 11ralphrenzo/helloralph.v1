using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.Utilities
{
    public static class DummyAPI
    {
        //App ID
        public static string APP_ID = "62d3e2bc99b47cf0bd7fa5ea";

        // URLs
        public static string BASE_URL = "https://dummyapi.io/data/v1";
        public static string GET_USERS = BASE_URL + "/user";
        public static string GET_USER_BY_ID = GET_USERS + "/";
        public static string CREATE_USER = GET_USERS + "/create";

    }
}
