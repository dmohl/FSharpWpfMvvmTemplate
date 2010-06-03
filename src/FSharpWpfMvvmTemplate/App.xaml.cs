using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using FSharpWpfMvvmTemplate.ViewModel;
using System;

namespace FSharpWpfMvvmTemplate
{
    public partial class App
    {
        static App()
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow();

            // Create the ViewModel to which 
            // the main window binds.
            var path = "Data/customers.xml";
            var viewModel = new MainWindowViewModel(path);

            // When the ViewModel asks to be closed, 
            // close the window.
            EventHandler handler = null;
            handler = delegate
            {
                viewModel.RequestClose -= handler;
                window.Close();
            };
            viewModel.RequestClose += handler;

            // Allow all controls in the window to 
            // bind to the ViewModel by setting the 
            // DataContext, which propagates down 
            // the element tree.
            window.DataContext = viewModel;

            window.Show();
        }
    }
}