﻿namespace ConsoleLibrary.Entitys
{
    public class GenreBook
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<Book> Books { get; set; }
    }
}