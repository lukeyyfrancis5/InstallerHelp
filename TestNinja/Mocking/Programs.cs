﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{   
    class Programs
    {
        public static void Main()
        {
            var service = new VideoService(null);
            var title = service.ReadVideoTitle();
        }
    }
}
