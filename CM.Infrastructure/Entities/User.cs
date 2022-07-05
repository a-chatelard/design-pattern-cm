using CM.Infrastructure.Entities.Base;

namespace CM.Infrastructure.Entities;

public class User : Entity
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }

    public UserRole Role { get; set; }

    public List<Contract> Contracts { get; set; } = new();

    public User(string firstname, string lastname, DateTime birthDate, string email)
    {
        Firstname = firstname;
        Lastname = lastname;
        BirthDate = birthDate;
        Email = email;
    }
}