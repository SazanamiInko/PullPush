using System;
using System.Collections.Generic;

namespace DLayer.Models;

public partial class MSubject
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? PullPushKbn { get; set; }

    public long? TaxTargetFlg { get; set; }

    public long? EnableFlg { get; set; }

    public long? DeleteFlg { get; set; }
}
