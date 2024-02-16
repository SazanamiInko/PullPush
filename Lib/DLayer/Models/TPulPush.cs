using System;
using System.Collections.Generic;

namespace DLayer.Models;

public partial class TPulPush
{
    public long Id { get; set; }

    public long? Year { get; set; }

    public long? Month { get; set; }

    public long? Day { get; set; }

    public string? Content { get; set; }

    public long? Subject { get; set; }

    public long? Pull { get; set; }

    public long? Push { get; set; }

    public string? Memo { get; set; }

    public string? Label { get; set; }

    public long? FromBank { get; set; }
}
