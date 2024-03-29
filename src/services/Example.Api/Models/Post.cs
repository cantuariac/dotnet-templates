﻿using Core.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Api.Models
{
    public class Post : Entity<Guid>
    {
        public string Title { get; set; }
    }

    public class PostMapping : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne<User>().WithMany();
        }
    }
}
