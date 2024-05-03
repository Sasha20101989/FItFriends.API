
namespace FitFriends.Persistence.Entities
{
    public class UserEntity
    {
        public Guid Id { get; internal set; }
        public string UserName { get; internal set; }
        public string PasswordHash { get; internal set; }
        public string Email { get; internal set; }
    }
}
