using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TTier
{
    public Guid TerPkId { get; set; }

    public string TerNom { get; set; } = null!;
}
