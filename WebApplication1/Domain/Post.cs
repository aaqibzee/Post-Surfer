﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Post_Surfer.Domain
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
