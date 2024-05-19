using System;
using System.Collections.Generic;

namespace Ovidie.EntityModel.SqlServer.Entities;

public partial class TChequier
{
    public Guid ChqPkId { get; set; }

    public DateOnly? ChqDateReception { get; set; }

    public decimal? ChqNumeroPremier { get; set; }

    public decimal? ChqNumeroDernier { get; set; }

    public Guid ChkFkCpePkCompteId { get; set; }
}
