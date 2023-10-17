using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformBlazor_Template
{
    public class Reverso
    {
        public event EventHandler<ReversoArgs> OnTextProcessed;
        public EventCallback<ReversoArgs> OnTextChanged;

        public Reverso()
        {
            OnTextChanged = new EventCallback<ReversoArgs>(null, (ReversoArgs args) => {
                string tmp = args.text;
                tmp = new string(tmp.Reverse().ToArray());

                OnTextProcessed?.Invoke(this, new ReversoArgs
                {
                    text = tmp
                });
            });
        }
    }
}
