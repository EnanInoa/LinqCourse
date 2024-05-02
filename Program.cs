LinqQueries query = new();

var booksCollection = query.FullBookCollection();

// printAll(booksCollection);
// PrintByYear(2000);
// PrintByPagesAndWords(250, "In Action");

#region  Practica animales
List<Animal> animales = [];
animales.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
animales.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
animales.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
animales.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
animales.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
animales.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
animales.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
animales.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
animales.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });


void GetAnimalsByColorAndFirstWord(string Color)
{
    List<char> vowels = ['a', 'e', 'i', 'o', 'u'];
    var anim = animales?.Where(x => x.Color.ToLower() == Color.ToLower() && vowels.Contains(x.Nombre.ToLower().FirstOrDefault())).ToList();
}
// GetAnimalsByColorAndFirstWord("verde");
#endregion
#region Practica libro
void printAll(IEnumerable<Book>? list)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 11}\n", "Titulo", "N. Páginas", "Fecha Pub");

    if (!(list?.Count() > 0)) return;
    foreach (var item in list) Console.WriteLine("{0, -70} {1, 7} {2, 11}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());

}


void PrintByYear(int year) => booksCollection.Where(x => x.PublishedDate.Year > 2000).ToList().ForEach(Console.WriteLine);
void PrintByPagesAndWords(int pages, string filterWord) => printAll(booksCollection?.Where(x => x.PageCount > 250 && x.Title is string t && t.Contains(filterWord)));


#region all y any
bool everyBookHasStatus() => booksCollection.All(x => !string.IsNullOrWhiteSpace(x.Status));
bool IsAnyBookFromYear(int year) => booksCollection.Any(x => x.PublishedDate.Year == year);
// Console.WriteLine(IsAnyBookFromYear(2005));

#endregion


#region contains
IEnumerable<Book> booksOf(string Subject) => booksCollection?.Where(x => x.Categories.Contains(Subject)).ToList();
// printAll(booksOf("Python"));
#endregion


#region orderBY
IEnumerable<Book> OrderByPagesDesc() => booksCollection?.OrderByDescending(x => x.PageCount).ToList();
// printAll(OrderByPagesDesc());
#endregion


#region skip y take
IEnumerable<Book> getFirstBooksInCategory(int qty, string category) => booksCollection?.Where(x => x.Categories.Contains(category)).OrderByDescending(x => x.PublishedDate).Take(qty).ToList();

IEnumerable<Book> skipBooksWithPages(int pos, int pages) => booksCollection?.Where(x => x.PageCount > pages).OrderByDescending(x => x.PageCount).Skip(pos).Take(2).ToList();
printAll(skipBooksWithPages(2, 400));
#endregion


#region select
IEnumerable<Book> SelectTitleAndPages(int qty) => booksCollection?.Take(qty).Select(x => new Book(){ Title = x.Title, PageCount = x.PageCount } ).ToList();

printAll(SelectTitleAndPages(3));
#endregion


#region count & LongCount
int CountByBookPages() => booksCollection.Count(x => x.PageCount >= 200 && x.PageCount <= 500);

Console.WriteLine(CountByBookPages());
#endregion`


#region min & max
DateTime MinPublicDate() => booksCollection.Min(x => x.PublishedDate);

Console.WriteLine(MinPublicDate());

int MaxPageCount() => booksCollection.Max(x => x.PageCount);

Console.WriteLine(MaxPageCount());
#endregion

public class Animal  
{
    public string Nombre { get; set; }
    public string Color { get; set; }
}


#endregion