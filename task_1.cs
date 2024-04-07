using System;

class Title
{
    private string title;

    public Title(string title)
    {
        this.title = title;
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Title: {title}");
        Console.ResetColor();
    }
}

class Author
{
    private string authorName;

    public Author(string authorName)
    {
        this.authorName = authorName;
    }

    public string AuthorName
    {
        get { return authorName; }
        set { authorName = value; }
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Author: {authorName}");
        Console.ResetColor();
    }
}

class Content
{
    private string content;

    public Content(string content)
    {
        this.content = content;
    }

    public string ContentText
    {
        get { return content; }
        set { content = value; }
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Content: {content}");
        Console.ResetColor();
    }
}

class Book
{
    private readonly Title title;
    private Author author;
    private Content content;

    public Book(string title)
    {
        this.title = new Title(title);
    }

    public Author Author
    {
        get { return author; }
        set { author = value; }
    }

    public Content Content
    {
        get { return content; }
        set { content = value; }
    }

    public void Show()
    {
        title.Show();
        author.Show();
        content.Show();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book("C# book");

        book.Author = new Author("Artem Pavlenko");
        book.Content = new Content("C#- це об'єктно-орiєнтована мова програмування з безпечною системою типiзацiї для платформи .NET.");

        book.Show();

        Console.ReadKey();
    }
}
