namespace DemoMediatR.Users.Queries.GetUserById
{
    public class GetUserByIdResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
    }
}
