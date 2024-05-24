using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Ovidie.ViewModels;
using ReactiveUI;

namespace Ovidie.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        
    }
    
}