namespace Bookstore;

public class Book
{
  // private fields
  private double price;
  private int stock;

  // access to them via properties
  public string Isbn { get; private set; }

  public string Title { get; private set; }

  public string Author { get; private set; }

  public double Price
  {
    get => price;
    private set
    {
      price = value;
      if (value < 0)
      {
        throw new ArgumentOutOfRangeException($"expected {nameof(price)} >= 0, but given: {price}");
      }
    }
  }

  public int Stock
  {
    get => stock;
    private set
    {
      stock = value;
      if (value < 0)
      {
        throw new ArgumentOutOfRangeException($"expected {nameof(stock)} >= 0, but given: {stock}");
      }
    }
  }

  public bool IsAvailable => Stock > 0;

  public void Rent()
  {
    if (!IsAvailable)
    {
      throw new InvalidOperationException("rent a book, but this type of books are out");
    }
    Stock--;
  }

  public void Return()
  {
    Stock++;
  }

  public void Reprice(double newPrice)
  {
    Price = newPrice;
  }

  override public string ToString()
  {
    return $"{Author} - {Title} ({Isbn}) ${Price} [{Stock}]";
  }

  public Book(string isbn, string title, string author, double price, int stock)
  {
    Isbn = isbn;
    Title = title;
    Author = author;
    Price = price;
    Stock = stock;
  }
};
