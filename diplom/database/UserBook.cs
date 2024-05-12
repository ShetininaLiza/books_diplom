using System;
using System.Collections.Generic;

namespace books;

public partial class UserBook
{
    public int? Bookid { get; set; }

    public decimal? RatingUser { get; set; }

    public bool WasResd { get; set; }

    public bool ToRead { get; set; }

    public bool FavoriteBook { get; set; }

    public string? Review { get; set; }

    public int? Userid { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
