using System;
using System.Collections.Generic;
using System.Text;

namespace Data.CommonEntities
{
    abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
