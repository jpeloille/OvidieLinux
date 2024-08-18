using System.Diagnostics;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ovidie.Models;
using Ovidie.Views;

namespace Ovidie.ViewModels;

public class TiersViewModel : ViewModelBase
{
  

    //public ReactiveCommand<Unit, Unit> OnDataValidation { get; }
    public RelayCommand<Window> OnDataValidation { get; private set; }
    public RelayCommand<Window> OnCancelData { get; private set; }
    //public ReactiveCommand<Unit, Unit> OnCancelData { get; } 
    

    public TiersViewModel()
    {
        //OnDataValidation = ReactiveCommand.Create(ValidateDatas);
        OnDataValidation = new RelayCommand<Window>(ValidateDatas);
        OnCancelData = new RelayCommand<Window>(CancelDatas);
     
    }

    private void CancelDatas(Window? window)
    {
        if (window != null) window.Close();
        Debug.WriteLine("Tiers view closed without persist object.");
    }

    private void ValidateDatas(Window? window)
    {

        if (window != null) window.Close();
        Debug.WriteLine("Tiers view closed as object was persisted too.");
    }
}