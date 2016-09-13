using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nancy.Nancy
{
    public class SampleModule :  NancyModule
    {
        public SampleModule()
        {
            Get["/"] = _ => "Hello World!";
        }
    }
}