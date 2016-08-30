using System;
using System.Collections.Generic;

namespace fixCallRoute.Models
{
    public interface IRepository<out T> : IDisposable
    {
        IEnumerable<T> Get();

        T FindById(int id);

    }
}
