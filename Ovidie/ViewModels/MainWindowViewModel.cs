using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Ovidie.EntityModel.SqlServer.Context;
using Ovidie.EntityModel.SqlServer.Entities;
using Ovidie.Models;
using Ovidie.Services;
using Ovidie.Views;

namespace Ovidie.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private Window ownerWindow;
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

    private TEcriture _selectedEntry;
    
    public TEcriture SelectedEntry
    {
        get => _selectedEntry;
        set => _selectedEntry = value;
    }
    
    private EntryDataGridItem _selectedEntryDataGridItem;
    public EntryDataGridItem SelectedEntryDataGridItem
    {
        get => _selectedEntryDataGridItem;
        set => this.RaiseAndSetIfChanged(ref _selectedEntryDataGridItem, value);
    }
    
    public ReactiveCommand<Unit, Unit> NewEntry { get; }
    public ReactiveCommand<Unit, Unit> ModifyEntry { get; }
    public ReactiveCommand<Unit, Unit> DeleteEntry { get; }
    public RelayCommand<SelectionChangedEventArgs> OnSelectedItemChanged { get; private set; }
    
    public MainWindowViewModel(Window? window)
    {
       
        accounts = dbContext.TComptes.ToList();
        OnSelectedItemChanged = new RelayCommand<SelectionChangedEventArgs>(SelectionChanged);
        NewEntry = ReactiveCommand.Create(OpenEntryDialogInCreationMode);
        ModifyEntry = ReactiveCommand.Create(OpenEntryDialogInModificationMode);
        DeleteEntry = ReactiveCommand.Create(DeleteEntryRequested);
    }

    private void OpenEntryDialogInCreationMode()
    {
        EntryDialogView entryDialogView = new EntryDialogView();
        entryDialogView.DataContext = new EntryDialogViewModel(dbContext, SelectedAccount, null);
        entryDialogView.Closed += OnEntryDialogClose;
        var mainWindow = Application.Current?.ApplicationLifetime 
            is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
        entryDialogView.ShowDialog(mainWindow);
    }
    
    private void OpenEntryDialogInModificationMode()
    {
        EntryDialogView entryDialogView = new EntryDialogView();
        entryDialogView.DataContext = new EntryDialogViewModel(dbContext, SelectedAccount, SelectedEntry);
        var mainWindow = Application.Current?.ApplicationLifetime 
            is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
        entryDialogView.Closed += OnEntryDialogClose;
        entryDialogView.Show(mainWindow);
    }

    private void DeleteEntryRequested()
    {
        dbContext.Remove(SelectedEntry);
        dbContext.SaveChanges();

        Entries = new ObservableCollection<EntryDataGridItem>(
            _entryDataGridListItemsHelper.GetEntries(SelectedAccount.CpePkCompteId)
                .OrderBy(entry => entry.TransactionDate));
    }

    private void OnEntryDialogClose(object? sender, EventArgs eventArgs)
    {
        Entries = new ObservableCollection<EntryDataGridItem>(
            _entryDataGridListItemsHelper.GetEntries(SelectedAccount.CpePkCompteId)
                .OrderBy(entry => entry.TransactionDate));

        SelectedEntryDataGridItem = Entries.Last();
    }

    private void SelectionChanged(SelectionChangedEventArgs? selectionChangedEventArgs)
    {
        if (selectionChangedEventArgs != null && selectionChangedEventArgs.AddedItems.Count != 0)
        {
            EntryDataGridItem? entryDataGrid 
                = selectionChangedEventArgs.AddedItems[0] as EntryDataGridItem;

            SelectedEntry = dbContext.TEcritures
                .First(entry => entryDataGrid != null && entry.EcrPkId == entryDataGrid.EntryIdentifier);     
        }
    }
    
}