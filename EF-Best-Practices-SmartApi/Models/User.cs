namespace EF_Best_Practices_SmartApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public List<Order> Orders { get; set; } = new();
    }
}
