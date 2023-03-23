using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject
{
    public class UserRepository
    {
        public User GetUser(int id, AppContext db)
        {
            User user = db.Users.Where(x=>x.Id==id).FirstOrDefault();
            return user;
        }
        public List<User> GetAllUsers(AppContext db)
        {
            return db.Users.ToList();
        }
        public void AddUser(User user, AppContext db)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void DeleteUser(User user, AppContext db)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public bool HasBooksInUser(AppContext db, Book book, User user)
        {
            return (db.Users.Where(x =>x == user && x.booksUser.Contains(book)).Count() > 0);
        }
        public int CountBooksInUser(AppContext db, User user)
        {
            return db.Users.Where(x => x == user).Select(x=>x.booksUser).ToList().Count;
        }


    }
}
