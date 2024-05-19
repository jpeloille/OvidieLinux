using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.EntityFrameworkCore;
using Ovidie.EntityModel.SqlServer.Context;
using Ovidie.EntityModel.SqlServer.Entities;
using Ovidie.Models;
using Ovidie.Services;
using Ovidie.Views;

namespace Ovidie.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    OvidieDbContext dbContext = new OvidieDbContext();
    private EntryDataGridListItems _entryDataGridListItemsHelper = new EntryDataGridListItems();
        
    public List<TCompte> accounts { get; set; }

    public ObservableCollection<EntryDataGridItem> _entries;
    
    public ObservableCollection<EntryDataGridItem> Entries
    {
        get => _entries;
        set => this.RaiseAndSetIfChanged(ref _entries, value);
    }

    private TCompte _selectedAccount;
    
    public TCompte SelectedAccount
    {
        get
        {
            return _selectedAccount ;
        }
        set
        {
            _selectedAccount = value;

            Entries = new ObservableCollection<EntryDataGridItem>(
                _entryDataGridListItemsHelper.GetEntries(SelectedAccount.CpePkCompteId)
                    .OrderBy(entry => entry.TransactionDate));
        }
    }
    
    public ReactiveCommand<Unit, Unit> OnClick { get; }
    
    public MainWindowViewModel()
    {
        accounts = dbContext.TComptes.ToList();
   
        OnClick = ReactiveCommand.Create(PerformAction);
    }
    
    private void PerformAction()
    {
        TiersView tiersView = new TiersView();
        tiersView.DataContext = new TiersViewModel();
        tiersView.Show();
    }
    

}