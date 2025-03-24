﻿using System;
using System.Collections.Generic;

namespace UserBlogAPI.Models;

public partial class Article
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
