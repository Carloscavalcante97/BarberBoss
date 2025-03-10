﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Exception.ExceptionBase
{
    public class NotFoundException : BarberBossException
    {
        public NotFoundException(string message) : base(message)
        {

        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
           return [Message];
        }
    }
}
