using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TAbonnement
{
    public Guid AboPkUniqueIdentifier { get; set; }

    public Guid? AboFkTerUniqueIdentifier { get; set; }

    public Guid? AboFkCpeUniqueIdentifier { get; set; }

    public Guid? AboFkMptUniqueIdentifier { get; set; }

    public decimal? AboMontant { get; set; }

    public string? AboRemarques { get; set; }

    public DateOnly? AboDebutPeriode { get; set; }

    public DateOnly? AboFinPeriode { get; set; }

    public bool? AboTaciteReconduction { get; set; }

    public string? AboFrequenceDecaissement { get; set; }

    public bool? AboImpactTauxEndettement { get; set; }

    public bool? AboActif { get; set; }
}
