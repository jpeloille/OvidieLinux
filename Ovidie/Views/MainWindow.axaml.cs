using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Ovidie.ViewModels;
using ReactiveUI;

namespace Ovidie.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        EntriesGrid.SelectionChanged += OnDataGridSelectionChanged;
    }

    private void OnDataGridSelectionChanged(object? sender, SelectionChangedEventArgs args)
    {
        var item = args.AddedItems[0];
        EntriesGrid.ScrollIntoView(item, null);
    }

}