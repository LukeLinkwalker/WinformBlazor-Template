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
            var reverso = new Reverso();

            blazorWebView.HostPage = "wwwroot\\index.html";
            blazorWebView.Services = services.BuildServiceProvider();            
            blazorWebView.RootComponents.Add<ReversoView>("#app", 
                new Dictionary<string, object?>() 
                {
                    { "reverso", reverso }                
                });
        }
    }
}