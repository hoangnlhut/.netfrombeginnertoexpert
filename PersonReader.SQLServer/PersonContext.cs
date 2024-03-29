﻿using Microsoft.EntityFrameworkCore;
using PersonReader.Interface;

namespace PersonReader.SQLServer
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

        public DbSet<Person>? People { get; set; }
    }
}