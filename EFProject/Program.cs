namespace EFProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                //// Добавление информации
                //var user1 = new User { Name = "Arthur", Email = "111@mil.ru" };
                //var book1 = new Book { Name = "Азбука", Year= 2000 };
                //db.Users.Add(user1);
                //db.Books.Add(book1);


                db.SaveChanges();
            }
        }
    }
}
