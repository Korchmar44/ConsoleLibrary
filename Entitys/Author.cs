﻿namespace ConsoleLibrary.Entitys
{
    public class Author
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public List<GenreBook>GenreBooks { get; set; }
    }
}