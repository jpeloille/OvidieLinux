using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TModele
{
    public Guid MdlIdentifier { get; set; }

    public string? MdlLabel { get; set; }

    public Guid? MdlFkCpePkIdentigier { get; set; }
}
