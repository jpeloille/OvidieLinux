using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Ovidie.EntityModel.SqlServer.Entities;

namespace Ovidie.Views;

public partial class EntryDialogView : Window
{
    public TEcriture result { get; set; }
    public EntryDialogView()
    {
        InitializeComponent();

        result = new TEcriture();
        result.EcrDebit = 2001;
    }
    
}