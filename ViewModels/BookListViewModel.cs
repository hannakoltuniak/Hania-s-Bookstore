﻿using HaniasBookstore.Models;

namespace HaniasBookstore.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books {get;}
        public string? CurrentGenre { get;}

        public BookListViewModel(IEnumerable<Book> books, string? currentGenre)
        {
            Books = books;
            CurrentGenre = currentGenre;    
        }
    }
}
