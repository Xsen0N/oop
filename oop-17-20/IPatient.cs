﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public interface IPatient
    {
        IPatient Clone();
        void GetInfo();
    }
}
