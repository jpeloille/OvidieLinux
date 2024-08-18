using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TModelsDetail
{
    public Guid MdlDetailsIdentifier { get; set; }

    public Guid? MdlDetailsFkCpePkIdentifier { get; set; }

    public Guid? MdlDetailsFkTerPkIdentifier { get; set; }

    public Guid? MdlDetailsFkMthPkIdentifier { get; set; }

    public decimal? MdlDetailsBalance { get; set; }

    public int? MdlDetailsOrder { get; set; }
}
