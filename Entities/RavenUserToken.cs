using Microsoft.AspNetCore.Identity;
using Raven.Imports.Newtonsoft.Json;
using System;

namespace RavenDB.AspNetCore.Identity.Entities
{
    public class RavenUserToken : RavenUserToken<string> { }

    /// <summary>
    ///     Entity type for a user's login (i.e. facebook, google)
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class RavenUserToken<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     The login provider for the login (i.e. facebook, google)
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        ///     Key representing the login for the provider
        /// </summary>
        public string TokenName { get; set; }

        /// <summary>
        ///     Display name for the login
        /// </summary>
        public string TokenValue { get; set; }

        /// <summary>
        ///     User Id for the user who owns this login
        /// </summary>
        public TKey UserId { get; set; }
    }
}