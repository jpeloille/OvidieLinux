using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ovidie.EntityModel.SqlServer.Context;
using Ovidie.EntityModel.SqlServer.Entities;

namespace Ovidie.Services;

public class EntryDataGridListItems
{
    OvidieDbContext dbContext = new OvidieDbContext();
    
    private List<TEcriture> _entries;
    private List<TTier> _payees;
    private List<TModePaiement> _methods;
    private List<EntryDataGridItem> _entryDataGridItems;

    public List<EntryDataGridItem> GetEntries(Guid AccountIdentifier)
    {
            _entries = dbContext.TEcritures
                .Where(entry => entry.EcrFkCpePkCompteId == AccountIdentifier)
                .OrderBy(entry=>entry.EcrDate)
                .ToList();

            _methods = dbContext.TModePaiements
                .Where(method => method.MptFkCpePkCompteId == AccountIdentifier)
                .ToList();

            _payees = dbContext.TTiers.ToList();
   
        
        EntryDataGridItem item;
        
        _entryDataGridItems = new List<EntryDataGridItem>();

        decimal? Balance = dbContext.TComptes
            .Where(account => account.CpePkCompteId == AccountIdentifier)
            .FirstOrDefault()
            .CpeSoldeOuverture;
            
        foreach (var entry in _entries)
        {
            item = new EntryDataGridItem();
            item.AccountIdentifier = AccountIdentifier;
            item.PayeeIdentifier = entry.EcrFlPkTiersId;
            item.MethodIdentifier = entry.EcrFkMptPkModePaiementId;
            
            item.TransactionDate = new DateOnly(
                entry.EcrDate.Value.Date.Year,
                entry.EcrDate.Value.Date.Month,
                entry.EcrDate.Value.Date.Day);
            
            item.MethodLabel = _methods
                .FirstOrDefault(method => method.MptPkModePaimentId == entry.EcrFkMptPkModePaiementId)!
                .MptLibelle;
            item.CheckNumber = entry.EcrNumero;
            item.PayeeLabel = _payees
                .FirstOrDefault(payee => payee.TerPkId == entry.EcrFlPkTiersId)!
                .TerNom;
            item.Debt = entry.EcrDebit;
            Balance -= entry.EcrDebit;
            
            item.Credit = entry.EcrCredit;
            Balance += entry.EcrCredit;
            
            item.Balance = Balance;
            _entryDataGridItems.Add(item);
        }
        
        return _entryDataGridItems;
    }
}