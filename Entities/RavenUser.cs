using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Raven.Imports.Newtonsoft.Json;
using Raven.Client.UniqueConstraints;

namespace RavenDB.AspNetCore.Identity.Entities
{
    public class RavenUser : RavenUser<string>
    {
        public RavenUser()
        {
            Id = $"Users/{Guid.NewGuid()}";
        }

        public RavenUser(string userName) : this()
        {
            UserName = userName;
        }
    }

    public class RavenUser<TKey> where TKey : IEquatable<TKey>
    {
        public RavenUser() { }

        public RavenUser(string userName) : this()
        {
            UserName = userName;
        }

        /// <summary>
        /// Pattern: Users/{guid}
        /// </summary>
        public TKey Id { get; set; }
        public string UserName { get; set; }
        [UniqueConstraint]
        public string NormalizedUserName { get; set; }

        /// <summary>
        ///     Email
        /// </summary>
        public string Email { get; set; }

        [UniqueConstraint]
        public string NormalizedEmail { get; set; }

        /// <summary>
        ///     True if the email is confirmed, default is false
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        ///     The salted/hashed form of the user password
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// A random value that should change whenever a users credentials change (password changed, login removed)
        /// </summary>
        public string SecurityStamp { get; set; }

        /// <summary>
        /// A random value that should change whenever a user is persisted to the store
        /// </summary>
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        ///     PhoneNumber for the user
        /// </summary>
        [UniqueConstraint]
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     True if the phone number is confirmed, default is false
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        ///     Is two factor enabled for the user
        /// </summary>
        public bool TwoFactorEnabled { get; set; }

        /// <summary>
        ///     DateTime in UTC when lockout ends, any time in the past is considered not locked out.
        /// </summary>
        public DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        ///     Is lockout enabled for this user
        /// </summary>
        public bool LockoutEnabled { get; set; }

        /// <summary>
        ///     Used to record failures for the purposes of lockout
        /// </summary>
        public int AccessFailedCount { get; set; }

        public IList<RavenUserRole<TKey>> Roles { get; private set; } = new List<RavenUserRole<TKey>>();
        public IList<RavenUserClaim<TKey>> Claims { get; private set; } = new List<RavenUserClaim<TKey>>();
        public IList<RavenUserLogin<TKey>> Logins { get; private set; } = new List<RavenUserLogin<TKey>>();
        public IList<RavenUserToken<TKey>> Tokens { get; private set; } = new List<RavenUserToken<TKey>>();
    }
}