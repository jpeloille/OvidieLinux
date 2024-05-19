using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TAbonnementRecurence
{
    public Guid AboRecPkIdentifier { get; set; }

    public string AboRecLabel { get; set; } = null!;
}
