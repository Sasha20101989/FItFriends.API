namespace FitFriends.Logic.Stores
{
    public record OrderFilter(
        IEnumerable<Guid> Ids,
        IEnumerable<string> Names,
        IEnumerable<DateTime> Dates);
}
