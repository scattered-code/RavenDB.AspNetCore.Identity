using System;
using System.Security.Claims;
using Raven.Imports.Newtonsoft.Json;

namespace RavenDB.AspNetCore.Identity.Entities
{
    public class RavenUserClaim : RavenUserClaim<string> { }

    /// <summary>
    ///     EntityType that represents one specific user claim
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class RavenUserClaim<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Claim type
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        ///     Claim value
        /// </summary>
        public string ClaimValue { get; set; }
    }
}