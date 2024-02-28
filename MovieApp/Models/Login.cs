using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models;

public partial class Login
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    
    public string Password { get; set; } = null!;

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = null!;
}