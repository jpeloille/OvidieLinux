using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TCompte
{
    public Guid CpePkCompteId { get; set; }

    public string? CpeNumeroCompte { get; set; }

    public string? CpeCodeBanque { get; set; }

    public string? CpeCodeGuichet { get; set; }

    public string? CpeCle { get; set; }

    public decimal? CpeSoldeOuverture { get; set; }

    public decimal? CpeDebitAlerte { get; set; }

    public decimal? CpeMntDecouvertAutorise { get; set; }

    public string? CpeLibelle { get; set; }

    public string? CpeIban { get; set; }

    public string? CpeBic { get; set; }

    public string? CpeDevise { get; set; }

    public string? CpeType { get; set; }

    public decimal? CpeCarteNumero { get; set; }

    public DateOnly? CpeCarteDateprelev { get; set; }

    public bool? CpeEstFavori { get; set; }

    public bool? CpeEstUtilisable { get; set; }

    public bool? CpeAVentiler { get; set; }
}
