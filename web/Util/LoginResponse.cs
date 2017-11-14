using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using domaine.entities;

namespace web.Util
{
    public class LoginResponse
    {
        public int Code { get; set; }
        public access_tokens Token { get; set; }

        public string Message { get; set; }
    }
}