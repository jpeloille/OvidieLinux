using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TCentre
{
    public Guid CtrIdentifier { get; set; }

    public string? CtrLabel { get; set; }

    public string? CtrCode { get; set; }
}
