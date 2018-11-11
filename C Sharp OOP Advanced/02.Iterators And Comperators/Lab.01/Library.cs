using System;
using System.Collections;
using System.Collections.Generic;


public class Library : IEnumerable<Book>
{
    private readonly List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    //Nested Class
    private class LibraryIterator : IEnumerator<Book>
    {
        public Book Current => books[index];

        object IEnumerator.Current => Current;

        private int index;
        private readonly IReadOnlyList<Book> books;
        public LibraryIterator(IReadOnlyList<Book> books)
        {
            this.books = books;
            index = -1;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            return ++index < books?.Count;
        }

        public void Reset()
        {
            //throw new NotSupportedException();
        }
    }
}

