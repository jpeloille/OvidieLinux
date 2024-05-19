using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TEcriture
{
    public Guid EcrPkId { get; set; }

    public DateTime? EcrDate { get; set; }

    public DateTime? EcrDateValeur { get; set; }

    public decimal? EcrNumero { get; set; }

    public decimal? EcrMontant { get; set; }

    public string? EcrLabel { get; set; }

    public string? EcrRemarque { get; set; }

    public bool? EcrPointee { get; set; }

    public DateTime? EcrDatePointee { get; set; }

    public Guid? EcrFkCpePkCompteId { get; set; }

    public Guid? EcrFkMptPkModePaiementId { get; set; }

    public Guid? EcrFlPkTiersId { get; set; }

    public decimal? EcrNumReleve { get; set; }

    public bool? EcrIsdebit { get; set; }

    public string? EcrFkCtrCode { get; set; }

    public bool? EcrIsrecurrent { get; set; }

    public bool? EcrIsdebtratio { get; set; }

    public decimal? EcrDebit { get; set; }

    public decimal? EcrCredit { get; set; }

    public decimal? EcrMontantDevise { get; set; }

    public decimal? EcrTauxChange { get; set; }

    public string? EcrDevise { get; set; }

    public int? EcrPointageMethode { get; set; }

    public string? EcrLettrage { get; set; }

    public decimal? EcrBalance { get; set; }

    public Guid? EcrFkCrtPk { get; set; }

    public string? EcrFkTerLabel { get; set; }
}
