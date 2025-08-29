namespace LAPUsersAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public int? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Nationality { get; set; } = string.Empty;
        public int? Role { get; set; }
        public string? PictureUrl { get; set; } = string.Empty; // Store file path or URL
        public bool? IsDeleted { get; set; } = false;
    }
}
