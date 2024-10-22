using System;
using System.Collections.Generic;

namespace TP1_A16.Models;

public partial class TypeAnimal
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int QuantiteDisponible { get; set; }

    public double PrixAnimal { get; set; }

    public string? ImageUrl { get; set; }

    public string Type { get; set; } = null!;
}
