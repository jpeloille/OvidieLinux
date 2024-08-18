using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TModePaiement
{
    public Guid MptPkModePaimentId { get; set; }

    public string? MptLibelle { get; set; }

    public bool? MptEstNumerable { get; set; }

    public decimal? MptTailleNumerable { get; set; }

    public bool? MptVerifieNumerable { get; set; }

    public Guid MptFkCpePkCompteId { get; set; }

    public bool? MptIsdebit { get; set; }

    public bool? MptIscredit { get; set; }

    public decimal? MptTransactionDay { get; set; }

    public DateOnly? MptValidityDay { get; set; }

    public bool? MptIsavalaible { get; set; }

    public string? MptCallkey { get; set; }
}
