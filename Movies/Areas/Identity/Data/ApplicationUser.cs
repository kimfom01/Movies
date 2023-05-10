using Microsoft.AspNetCore.Identity;

namespace Movies.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MoviesUser class
public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

