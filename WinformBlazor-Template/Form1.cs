using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace WinformBlazor_Template
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();

#if (DEBUG)
            // Show developer tools by pressing Ctrl + Shift + I
            services.AddBlazorWebViewDeveloperTools();
            services.AddLogging();
#endif
            // Used for demonstrating how the UI can subscribe to events invoked by the back-end.
            var someClass = new SomeClass();

            blazorWebView.HostPage = "wwwroot\\index.html";
            blazorWebView.Services = services.BuildServiceProvider();            
            blazorWebView.RootComponents.Add<Counter>("#app", 
                new Dictionary<string, object?>() 
                {
                    { "someClass", someClass },
                    { "callback", new EventCallback(null, () => {
                        someClass.InvokeOnSomeEvent();
                    })}
                
                });
        }
    }
}