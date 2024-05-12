using System;
using System.Collections.Generic;

namespace books;

public partial class BookGenre
{
    public int Bookid { get; set; }

    public int Genreid { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;
}
