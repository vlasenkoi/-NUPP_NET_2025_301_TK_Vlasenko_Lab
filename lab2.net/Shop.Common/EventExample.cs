using System;

namespace Shop.Common
{
    public delegate void Notify();

    public class EventExample
    {
        public event Notify OnCreate;

        public void Create()
        {
            OnCreate?.Invoke();
        }
    }
}