using System;
using System.Collections.Generic;

namespace MovieApp.Models;

public partial class Suggestion
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? ImgUrl { get; set; }

    public string? MovieUrl { get; set; }
}
