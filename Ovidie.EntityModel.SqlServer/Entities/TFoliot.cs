using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TFoliot
{
    public Guid FltPkId { get; set; }

    public string? FltPiece { get; set; }

    public DateOnly? FltReconciliationDate { get; set; }

    public DateOnly? FltPeriodStart { get; set; }

    public DateOnly? FltPeriodEnd { get; set; }

    public Guid? FltFkCpePkCompteId { get; set; }
}
