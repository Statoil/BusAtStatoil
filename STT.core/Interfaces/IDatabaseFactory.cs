﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STT.core.Interfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        IDataContext Get();
    }
}
