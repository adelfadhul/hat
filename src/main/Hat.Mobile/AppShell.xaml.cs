using Hat.Views;

namespace Hat;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
       
        Routing.RegisterRoute("productdetails", typeof(ProductDetailsView));

    }
}
