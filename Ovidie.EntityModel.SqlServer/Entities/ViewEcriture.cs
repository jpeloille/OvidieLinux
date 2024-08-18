using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class ViewEcriture
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

    public Guid MptPkModePaimentId { get; set; }

    public string? MptLibelle { get; set; }

    public bool? MptEstNumerable { get; set; }

    public decimal? MptTailleNumerable { get; set; }

    public bool? MptVerifieNumerable { get; set; }

    public Guid MptFkCpePkCompteId { get; set; }

    public bool? MptIsdebit { get; set; }

    public Guid TerPkId { get; set; }

    public string? TerNom { get; set; }
}
