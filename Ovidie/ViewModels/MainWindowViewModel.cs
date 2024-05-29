using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Ovidie.EntityModel.SqlServer.Context;
using Ovidie.EntityModel.SqlServer.Entities;
using Ovidie.Events;
using Ovidie.Messages;
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
    
    public MainWindowViewModel()
    {
       
        accounts = dbContext.TComptes.ToList();
        OnSelectedItemChanged = new RelayCommand<SelectionChangedEventArgs>(SelectionChanged);
        NewEntry = ReactiveCommand.Create(OpenEntryDialogInCreationMode);
        ModifyEntry = ReactiveCommand.Create(OpenEntryDialogInModificationMode);
        DeleteEntry = ReactiveCommand.Create(DeleteEntryRequested);

        WeakReferenceMessenger.Default.Register<EntriesDbTableChangedMessage>(this,
        (recipient, message) =>
        {
            SelectedEntry = message.Value;
        });
   
    }

    
    public Interaction<MainWindowViewModel, EntryDialogViewModel?> ShowDialog { get; }

    private void OpenEntryDialogInCreationMode()
    {
        EntryDialogView entryDialogView = new EntryDialogView();
        EntryDialogViewModel entryDialogViewModel = new EntryDialogViewModel(dbContext, SelectedAccount, null);
        entryDialogView.DataContext = entryDialogViewModel;
        entryDialogViewModel.EntityPersisted += OnEntityPersisted;
        entryDialogView.Closed += OnEntryDialogClose;
        var mainWindow = Application.Current?.ApplicationLifetime 
            is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
        entryDialogView.ShowDialog(mainWindow);
    }
    
    private void OpenEntryDialogInModificationMode()
    {
        EntryDialogView entryDialogView = new EntryDialogView();
        EntryDialogViewModel entryDialogViewModel = new EntryDialogViewModel(dbContext, SelectedAccount, SelectedEntry);
        entryDialogView.DataContext = entryDialogViewModel;
        var mainWindow = Application.Current?.ApplicationLifetime 
            is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
        entryDialogViewModel.EntityPersisted += OnEntityPersisted;
        entryDialogView.Closed += OnEntryDialogClose;
        entryDialogView.Show(mainWindow);
    }

    private void OnEntityPersisted(object? sender, EntityEventArgs<TEcriture> entityEventArgs)
    {
        SelectedEntry = entityEventArgs.Entity;
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

        SelectedEntryDataGridItem =
            Entries.FirstOrDefault(item => item.EntryIdentifier == SelectedEntry.EcrPkId);
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