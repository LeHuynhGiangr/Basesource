﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
