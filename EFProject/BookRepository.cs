using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject
{
    public class BookRepository
    {
        public Book GetBook(int id, AppContext db)
        {
            Book book = db.Books.Where(x => x.Id == id).FirstOrDefault();
            return book;
        }
        public List<Book> GetAllBooks(AppContext db)
        {
            return db.Books.ToList();
        }
        public void AddBook(Book book, AppContext db)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }
        public void DeleteBook(Book book, AppContext db)
        {
            db.Books.Remove(book);
            db.SaveChanges();
        }
        public List<Book> GetAllBooksByGenge(AppContext db, string genre, int year1, int year2)
        {
            return db.Books.Where(x=>x.Genre==genre && x.Year>year1 && x.Year<year2).ToList();
        }
        public int CountBooksByAutoe(AppContext db, string autor)
        {
            return db.Books.Where(x => x.Autor == autor).Count();
        }
        public int CountBooksByGenre(AppContext db, string genre)
        {
            return db.Books.Where(x => x.Genre == genre).Count();
        }
        public bool HasBooksByAutorAndName(AppContext db, string autor, string name)
        {
            return (db.Books.Where(x => x.Autor == autor && x.Name==name).Count()>0);
        }
        public Book GetNewBook(AppContext db)
        {
            return db.Books.Where(x => x.Year == db.Books.Select(x=>x.Year).Max()).FirstOrDefault();
        }

        public List<Book> GetAllSortBooks(AppContext db)
        {
            return db.Books.OrderBy(x=>x.Name).ToList();
        }
        public List<Book> GetAllSortBooksByYear(AppContext db)
        {
            return db.Books.OrderByDescending(x => x.Year).ToList();
        }
    }
}
