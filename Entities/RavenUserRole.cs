using System;
using System.Security.Claims;
using Raven.Imports.Newtonsoft.Json;

namespace RavenDB.AspNetCore.Identity.Entities
{
    public class RavenUserRole : RavenUserRole<string> { }

    /// <summary>
    ///     EntityType that represents a user belonging to a role
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class RavenUserRole<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     UserId for the user that is in the role
        /// </summary>
        public TKey UserId { get; set; }

        /// <summary>
        ///     RoleId for the role
        /// </summary>
        public TKey RoleId { get; set; }
    }
}