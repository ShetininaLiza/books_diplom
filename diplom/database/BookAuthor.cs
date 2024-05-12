using System;
using System.Collections.Generic;

namespace books;

public partial class BookAuthor
{
    public int Bookid { get; set; }

    public int Authorid { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;
}
