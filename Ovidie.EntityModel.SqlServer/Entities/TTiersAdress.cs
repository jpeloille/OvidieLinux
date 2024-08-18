using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TTiersAdress
{
    public Guid TadPkId { get; set; }

    public Guid? TadFkTerPkId { get; set; }

    public string? TadDistrict { get; set; }

    public string? TadAdress { get; set; }

    public string? TadPhone { get; set; }

    public string? TadEmail { get; set; }
}
