using Microsoft.AspNetCore.Identity;

namespace TuitionDb.Areas.Identity.Data;

// Add profile data for application users by adding properties to the TuitionDbUser class

public class TuitionDbUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string StudentSchool { get; set; } 
}
