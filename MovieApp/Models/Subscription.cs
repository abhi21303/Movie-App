using System;
using System.Collections.Generic;

namespace MovieApp.Models;

public partial class Subscription
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Quality { get; set; } = null!;

    public string Devices { get; set; } = null!;

    public int SimultaneousScreen { get; set; }

    public int DeviceDownload { get; set; }

    public int Price { get; set; }
}
