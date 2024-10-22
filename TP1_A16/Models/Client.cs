using System;
using System.Collections.Generic;

namespace TP1_A16.Models;

public partial class Client
{
    internal int? id;

    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Courriel { get; set; } = null!;

    public string Telephone { get; set; } = null!;
}
