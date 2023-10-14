using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformBlazor_Template
{
    public class SomeClass
    {
        public event EventHandler<SomeEvent> OnSomeEvent;

        public void InvokeOnSomeEvent()
        {
            OnSomeEvent?.Invoke(null, new SomeEvent
            {
                message = "Hello World"
            });
        }
    }
}
