﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQL
{
    internal interface IQueryPart
    {
        string Translate();

    }
}