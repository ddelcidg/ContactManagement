namespace ContactsService.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid UserId { get; set; } // Relacionar con el usuario autenticado
    }
}
