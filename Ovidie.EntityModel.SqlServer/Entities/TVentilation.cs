using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TVentilation
{
    public Guid VtlPkId { get; set; }

    public Guid? VtlFkEcrPkId { get; set; }

    public Guid? VtlFkNmcPkId { get; set; }

    public decimal? VtlMontant { get; set; }

    public bool? VtlIsdebit { get; set; }

    public Guid? VtlFkEcrPkIdentifier { get; set; }

    public Guid? VtlFkCtrPkIdentifier { get; set; }

    public decimal? VtlDebit { get; set; }

    public decimal? VtlCredit { get; set; }
}
