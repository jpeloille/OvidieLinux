using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class VVentilation
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

    public Guid CtrIdentifier { get; set; }

    public string? CtrLabel { get; set; }

    public string? CtrCode { get; set; }
}
