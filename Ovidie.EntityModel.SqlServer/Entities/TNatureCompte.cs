using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TNatureCompte
{
    public Guid? NatPkId { get; set; }

    public string? NatLibelle { get; set; }

    public string? NatInformations { get; set; }
}
