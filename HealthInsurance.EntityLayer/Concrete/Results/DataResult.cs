﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Abstract.IResults;

namespace HealthInsurance.EntityLayer.Concrete.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool succes, string message) : base(succes, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
