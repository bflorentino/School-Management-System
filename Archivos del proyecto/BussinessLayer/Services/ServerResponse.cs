using System;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class ServerResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}