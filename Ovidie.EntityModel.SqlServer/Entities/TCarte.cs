using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TCarte
{
    public Guid CrtPkId { get; set; }

    public string? CrtType { get; set; }

    public string? CrtNature { get; set; }

    public string? CrtDevise { get; set; }

    public decimal? CrtNumero { get; set; }

    public string? CrtExpire { get; set; }

    public string? CrtEmetteur { get; set; }

    public Guid? CrtFkCpePk { get; set; }

    public string? CrtLibelle { get; set; }

    public bool? CrtScinder { get; set; }
}
