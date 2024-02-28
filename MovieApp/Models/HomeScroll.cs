using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models;

public partial class HomeScroll
{

    public int Id { get; set; }

    public string? Title { get; set; }

    public string? ImgUrl { get; set; }

    public string? MovieUrl { get; set; }
}
