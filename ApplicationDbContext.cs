﻿using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Employees> Employees { get; set; }
}