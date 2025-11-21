namespace Bookstore;

public class BookStore(Catalog _catalog)
{
  private readonly Catalog catalog = _catalog;

  public void Rent(string isbn)
  {
    catalog[isbn].Rent();
  }

  public void Return(string isbn)
  {
    catalog[isbn].Return();
  }

  public void SetPrice(string isbn, double price)
  {
    catalog[isbn].Reprice(price);
  }

  public void PrintCatalog()
  {
    foreach (var book in catalog)
    {
      Console.WriteLine(book);
    }
  }
};
