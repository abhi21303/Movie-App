using System;
using System.Collections.Generic;

namespace MovieApp.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string MovieTitle { get; set; } = null!;

    public string MovieCategory { get; set; } = null!;

    public DateOnly MovieDate { get; set; }

    public string MovieBigImg { get; set; } = null!;

    public string MovieSmallImg { get; set; } = null!;

    public string MovieUrl { get; set; } = null!;
}
