using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }

        public static IRepo<Author, int, Author> AuthorData()
        {
            return new AuthorRepo();
        }

        public static IRepo<Book, int, Book> BookData()
        {
            return new BookRepo();
        }

        public static IRepo<Review, int, Review> ReviewData()
        {
            return new ReviewRepo();
        }

        public static IRepo<ReviewVote, int, ReviewVote> ReviewVoteData()
        {
            return new ReviewVoteRepo();
        }
    }
}
