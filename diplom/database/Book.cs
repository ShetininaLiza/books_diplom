using System;
using System.Collections.Generic;

namespace books;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Image { get; set; }

    public int YearOfPublication { get; set; }

    public string? Annotation { get; set; }

    public int? Votes { get; set; }

    public decimal? Rating { get; set; }
}
