﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Application.Logging
{
    public interface IExceptionLogger
    {
        void Log(Exception ex);
    }
}
