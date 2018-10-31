# AspNet.Core RavenDB Identity Provider
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fops-ai%2FRavenDB.AspNetCore.Identity.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2Fops-ai%2FRavenDB.AspNetCore.Identity?ref=badge_shield)


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
	
## Version 2.0.0
* Updated RavenDB nuget packages to 3.5.5-patch-35243
* Upgraded to .net standard 2.0
	
## Version 1.0.6
* Updated RavenDB nuget packages to 3.5.0-rc-35169
* Added target for .NETFramework 4.5.1
	
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





## License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fops-ai%2FRavenDB.AspNetCore.Identity.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Fops-ai%2FRavenDB.AspNetCore.Identity?ref=badge_large)