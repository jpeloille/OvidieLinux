using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TTiersFacturette
{
    public Guid TftPkUniqueIdentifier { get; set; }

    public Guid? TftFpkTerPkId { get; set; }

    public string? TftLabel { get; set; }
}
