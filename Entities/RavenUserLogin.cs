using Microsoft.AspNetCore.Identity;
using Raven.Imports.Newtonsoft.Json;
using System;

namespace RavenDB.AspNetCore.Identity.Entities
{
    public class RavenUserLogin : RavenUserLogin<string> { }

    /// <summary>
    ///     Entity type for a user's login (i.e. facebook, google)
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class RavenUserLogin<TKey> where TKey : IEquatable<TKey>
    {
        public string Id { get; set; }

        /// <summary>
        ///     The login provider for the login (i.e. facebook, google)
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        ///     Key representing the login for the provider
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        ///     Display name for the login
        /// </summary>
        public string ProviderDisplayName { get; set; }

        /// <summary>
        ///     User Id for the user who owns this login
        /// </summary>
        public TKey UserId { get; set; }
    }
}