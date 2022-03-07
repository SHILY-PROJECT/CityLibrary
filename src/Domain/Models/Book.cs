﻿namespace Domain.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Genre Genre { get; set; }
    public Author Author { get; set; }
}