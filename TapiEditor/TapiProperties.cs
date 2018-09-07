using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapiEditor
{
    public class TapiProperties
    {
        public string User { get; set; }
        public string Password { get; set; }

        public TapiProperties()
        {
            Password = "IDGFCDA";
        }
    }
}
