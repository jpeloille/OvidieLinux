using System.Collections.Generic;
using System.Linq;
using Ovidie.EntityModel.SqlServer.Context;
using Ovidie.EntityModel.SqlServer.Entities;

namespace Ovidie.Services;

public class MethodServices
{
    public List<TModePaiement> GetAccountMethods(TCompte Account, OvidieDbContext dbContext)
    {
        List<TModePaiement> methods = dbContext.TModePaiements
            .Where(method => method.MptFkCpePkCompteId == Account.CpePkCompteId)
            .OrderBy(method => method.MptLibelle)
            .ToList();

        return methods;
    }
}