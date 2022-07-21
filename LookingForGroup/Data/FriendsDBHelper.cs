using LookingForGroup.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace LookingForGroup.Data
{
    /// <summary>
    /// Database access commands to assist in utlizing Tags
    /// </summary>
    public class FriendsDBHelper
    { 
        private readonly LookingForGroupDbContext _context;
        
        public FriendsDBHelper(LookingForGroupDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Searches the user database for a user with given userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>The correspsonding LookingForGroupUser</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public LookingForGroupUser findByUserName(string userName)
        {
            LookingForGroupUser user = _context.LookingForGroupUsers.FirstOrDefault(u => u.UserName == userName);
            
            if (user == null)
            {
                throw new System.ArgumentException("User is not in the database");
            }
            
            return user;
        }

        /// <summary>
        /// Creates a new friend request between two
        /// users and sets their status to pending
        /// </summary>
        /// <param name="newTag">The name of the tag you want to create</param>
        /// 
        public void addFriend(string userName, string friendUserName)
        {
            //find user in the asp net user table by user name
            LookingForGroupUser currentUser = findByUserName(userName);
            LookingForGroupUser UserToFriend = findByUserName(friendUserName);
            
            // If the friend link is not already in the database, add it
            if (!_context.FriendsLists.Any(f => f.AccountId == currentUser.Id && f.FriendId == UserToFriend.Id))
            {
                _context.FriendsLists.Add(new FriendsList()
                {
                    AccountId = currentUser.Id,
                    FriendId = UserToFriend.Id,
                    FriendStatus = "Pending"
                });
                _context.SaveChanges();
            }
        }
            
        //{
        //    if (!_context.Friends.Any(t => t.Friend == newFriend))
        //    {
        //        _context.Friends.Add(new Friend { Friend = newFriend });
        //        _context.SaveChanges();
        //    }
        //}
        public void acceptFriend(LookingForGroupUser user)
        {
            // if the friend is in the database, then set the friend status to accepted
            if (_context.FriendsLists.Any(t => t.FriendId == user.Id))
                {
                _context.FriendsLists.First(t => t.FriendId == user.Id).FriendStatus = "Accepted";
            }
            else
            {
                // if the friend is not in the database, then create a new friend request
                _context.FriendsLists.Add(new FriendsList
                {
                    AccountId = user.Id,
                    FriendId = user.Id,
                    FriendStatus = "Accepted"
                });
            }
        //    Tags? tag = (from FriendsList in _context.FriendsLists
        //                 where FriendsList.Friend == newTag
        //                 select Tags).FirstOrDefault();

        //    if (tag is null)
        //    {
        //        Tags tags = new()
        //        {
        //            TagName = newTag
        //        };
        //        _context.Tags.Add(tags);
        //        _context.SaveChanges();
        //    }
        }

        
        /// <summary>
        /// Gets a list of all tags currently in database
        /// </summary>
        /// <returns>A list of all tags in the database</returns>
        public async Task<List<Tags>> getTagsList()
        {
            return await _context.Tags.ToListAsync();
        }
    }
}
