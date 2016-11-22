using System;
using System.Collections.Generic;


namespace net1
{
    interface IAccount<T>
        where T : IComponent
    {
        void SetComponent(T component);
        List<T> ReturnObject();
    }
}
