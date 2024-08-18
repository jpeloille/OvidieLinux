using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TNature
{
    public Guid NatIdentifier { get; set; }

    public string? NatClasse { get; set; }

    public string? NatLibelle { get; set; }
}
