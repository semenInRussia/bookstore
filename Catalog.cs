using System.Collections;

namespace Bookstore;

public class Catalog : IReadOnlyCollection<Book>
{
  private readonly Dictionary<string, Book> _items = [];
  private readonly List<string> _order = [];

  public void Add(Book b)
  {
    if (Contains(b.Isbn))
    {
      return;
    }
    _items[b.Isbn] = b;
    _order.Add(b.Isbn);
  }

  public void Remove(string isbn)
  {
    _items.Remove(isbn);
    _order.Remove(isbn);
  }

  public bool Contains(string isbn)
  {
    return _items.ContainsKey(isbn);
  }

  public int Count => _order.Count;

  public IEnumerator<Book> GetEnumerator()
  {
    return _order.Select(isbn => this[isbn]).GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }

  public Book this[string isbn]
  {
    get
    {
      if (!Contains(isbn))
      {
        throw new KeyNotFoundException($"can't find a book with given isbn: {isbn}");
      }
      return _items[isbn];
    }
  }

  public Book this[int j]
  {
    get
    {
      if (j < 0 || j >= _order.Count)
      {
        throw new IndexOutOfRangeException($"index out of range: {j}");
      }
      return this[_order[j]];
    }
  }

  public Book this[(string, int) authorAndIdx]
  {
    get
    {
      var (author, j) = authorAndIdx;
      var books = this.Where(b => b.Author == author);
      if (j < 0 || books.Count() <= j)
      {
        throw new IndexOutOfRangeException($"can't find {j}th book of author: {books.Count()} books was found");
      }
      return books.ElementAt(j);
    }
  }
}
