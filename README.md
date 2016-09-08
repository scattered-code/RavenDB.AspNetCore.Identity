# AspNet.Core RavenDB Identity Provider
================
Fully asynchronous, ASP.NET Core Identity provider for RavenDB 3.5.

## Getting Started
Using AspNet.Core RavenDB Identity Provider port is pretty straight forward.
Install the [RavenDB.AspNetCore.Identity](https://www.nuget.org/packages/RavenDB.AspNetCore.Identity) library through [NuGet](https://nuget.org).

    Install-Package RavenDB.AspNetCore.Identity

Usage:

```csharp
public IServiceProvider ConfigureServices(IServiceCollection services)
{
	...
	
	services.AddIdentity<ApplicationUser, RavenRole>();
	services.AddScoped<IUserStore<ApplicationUser>, RavenUserStore<ApplicationUser, RavenRole>>();
	services.AddScoped<IRoleStore<RavenRole>, RavenUserStore<ApplicationUser, RavenRole>>();
            
	services.AddIdentity<ApplicationUser, RavenRole>().AddDefaultTokenProviders();
	
	...
}
```

```csharp
	public class ApplicationUser : RavenUser
    {
        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }

		//extend as needed with your own properties
	}
```
	
## Version 1.0.5
* Fixed issue with roles being incorrectly returned
	
## Version 1.0.4
* Added value injector to update user object
	
## Version 1.0.3
* Fixed bug in updating user

## Version 1.0.2
* Restructured storage of Roles in user object, please note this is a breaking change if you're using version 1.0.1, you'll need to patch the existing users in your database:
	1. to only store the role id instead of the role object
	2. removed user id from RavenUserToken, RavenUserClaim and RavenUserLogin

## Version 1.0.1
* Created RavenDB Identity Provider for AspNet Core based on the AspNet Core Identity implementation, particularly I modified the InMemoryStore from the AspNet Core Identity test below to work with RavenDB
	https://github.com/aspnet/Identity/blob/ec4c08d11a00ec9b4dd8c22ef13a4950cb70901e/test/Microsoft.AspNetCore.Identity.InMemory.Test/InMemoryStore.cs



