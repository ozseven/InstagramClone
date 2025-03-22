using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Friendship:BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
        public virtual User User { get; set; }
        public virtual User Friend { get; set; }
        public RelationShip MyProperty { get; set; }
    }
    public enum RelationShip
    {
        Friend,
        CloseFriend,
        BlockFriend,
        RestrictFriend
    }
}
