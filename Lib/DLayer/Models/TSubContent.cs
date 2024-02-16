using System;
using System.Collections.Generic;

namespace DLayer.Models;

public partial class TSubContent
{
    public long Id { get; set; }

    public string? Content { get; set; }

    public long? Subject { get; set; }

    public long? Delete { get; set; }
}
