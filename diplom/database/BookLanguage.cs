using System;
using System.Collections.Generic;

namespace books;

public partial class BookLanguage
{
    public int Bookid { get; set; }

    public int Languageid { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}
