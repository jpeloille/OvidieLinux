using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Azure.Identity;
using CommunityToolkit.Mvvm.Input;
using Ovidie.EntityModel.SqlServer.Context;
using Ovidie.EntityModel.SqlServer.Entities;
using Ovidie.Services;
using ReactiveUI;

namespace Ovidie.ViewModels;

public class EntryDialogViewModel : ViewModelBase
{
    private bool isInCreationMode = false;

    private OvidieDbContext _dbContext;
    
    private MethodServices _methodServices = new MethodServices();
    
    private ObservableCollection<TModePaiement>? _methods;
    public ObservableCollection<TModePaiement>? Methods
    {
        get => _methods;
        set => this.RaiseAndSetIfChanged(ref _methods, value);
    }

    private TModePaiement _selectedMethod;
    public TModePaiement SelectedMethod
    {
        get => _selectedMethod;
        set => this.RaiseAndSetIfChanged(ref _selectedMethod, value);
    }
    
    private ObservableCollection<TTier>? _payees;
    public ObservableCollection<TTier>? Payees
    {
        get => _payees;
        set => this.RaiseAndSetIfChanged(ref _payees, value);
    }

    private List<string> _payeesLabel;

    public List<string> PayeesLabels
    {
        get => _payeesLabel;
        set => this.RaiseAndSetIfChanged(ref _payeesLabel, value);
    }

    private TTier _selectedPayee;
    public TTier SelectedPayee
    {
        get => _selectedPayee;
        set => this.RaiseAndSetIfChanged(ref _selectedPayee, value);
    }

    private TCompte _selectedAccount;

    private TEcriture _entry;
    
    public TEcriture Entry
    {
        get => _entry;
        set => this.RaiseAndSetIfChanged(ref _entry, value);
    }

    public static TEcriture result;
    public RelayCommand<Window> OnSaveDataRequested { get; private set; }
    
    public RelayCommand<Window> OnCancelDataRequested { get; private set; }
    
    public RelayCommand<SelectionChangedEventArgs> OnPayeeSelectedItemChanged { get; private set; }

    //Constructor:
    public EntryDialogViewModel(OvidieDbContext dbContext, TCompte selectedAccount, TEcriture entry)
    {
        _dbContext = dbContext;
        OnSaveDataRequested = new RelayCommand<Window>(SaveDatas);
        OnCancelDataRequested = new RelayCommand<Window>(CancelDatas);
        OnPayeeSelectedItemChanged = new RelayCommand<SelectionChangedEventArgs>(SelectedPayeeChanged);
        _selectedAccount = selectedAccount;
        
        RefreshMethodsComboBoxItems();
        RefreshPayeesComboBoxItems();
        RefreshPayeesLabelsList();

        if (entry != null)
        {
            Entry = entry;
            isInCreationMode = false;
        }
        else
        {
            Entry = new TEcriture();
            Entry.EcrFkCpePkCompteId = _selectedAccount.CpePkCompteId;
            isInCreationMode = true;
        }
           
        SelectedMethod = _dbContext.TModePaiements
            .FirstOrDefault(method => method.MptPkModePaimentId == Entry.EcrFkMptPkModePaiementId);
        
        SelectedPayee = _dbContext.TTiers
            .FirstOrDefault(payee => payee.TerPkId == Entry.EcrFlPkTiersId);
    }

    private void SelectedPayeeChanged(SelectionChangedEventArgs? args)
    {
        SelectedPayee = _dbContext.TTiers
            .FirstOrDefault(payee => payee.TerNom == args.AddedItems[0]);
    }

    private void RefreshMethodsComboBoxItems()
    {
        Methods = new ObservableCollection<TModePaiement>(
            _methodServices.GetAccountMethods(_selectedAccount, _dbContext));
    }
    
    private void RefreshPayeesComboBoxItems()
    {
        Payees = new ObservableCollection<TTier>(
            _dbContext.TTiers);
    }

    private void RefreshPayeesLabelsList()
    {
        PayeesLabels = new List<string>();
        foreach (var payee in Payees)
        {
            PayeesLabels.Add(payee.TerNom);
        }
    }
        
    private void SaveDatas(Window? window)
    {
        
        Entry.EcrFlPkTiersId = SelectedPayee.TerPkId;
        Entry.EcrFkMptPkModePaiementId = SelectedMethod.MptPkModePaimentId;

        if (isInCreationMode != true)
        {
            _dbContext.TEcritures.Update(Entry);
            _dbContext.SaveChanges();
        }
        else
        {
            Entry.EcrPkId = Guid.NewGuid();
            _dbContext.TEcritures.Add(Entry);
            _dbContext.SaveChanges();    
        }

        result = Entry;
        
        if (window != null) window.Close();        
    }

    private void CancelDatas(Window? window)
    {
        if (window != null) window.Close();
    }

}