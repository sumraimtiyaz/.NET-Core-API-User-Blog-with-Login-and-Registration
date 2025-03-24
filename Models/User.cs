using System;
using System.Collections.Generic;

namespace UserBlogAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
