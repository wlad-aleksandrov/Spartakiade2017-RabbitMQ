using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace StartupApp.Modules
{
    public class ContactModule : NancyModule
    {
        public ContactModule()
        {
            Get["/Contact"] = args => View["Contact"];
        }
    }
}
