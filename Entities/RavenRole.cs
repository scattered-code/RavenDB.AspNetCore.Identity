using System;
using System.Collections.Generic;

namespace RavenDB.AspNetCore.Identity.Entities
{
    /// <summary>
    /// The default implementation of <see cref="RavenRole{TKey}"/> which uses a string as the primary key.
    /// </summary>
    public class RavenRole : RavenRole<string>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RavenRole"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public RavenRole()
        {
            Id = $"Roles/{Guid.NewGuid()}";
        }

        /// <summary>
        /// Initializes a new instance of <see cref="RavenRole"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public RavenRole(string roleName)
        {
            Id = $"Roles/{roleName}";
            Name = roleName;
        }
    }

    /// <summary>
    /// Represents a role in the identity system
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the role.</typeparam>
    public class RavenRole<TKey> : RavenRole<TKey, RavenUserRole<TKey>, RavenRoleClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
    }

    /// <summary>
    /// Represents a role in the identity system
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the role.</typeparam>
    /// <typeparam name="TUserRole">The type used for user roles.</typeparam>
    /// <typeparam name="TRoleClaim">The type used for role claims.</typeparam>
    public class RavenRole<TKey, TUserRole, TRoleClaim>
        where TKey : IEquatable<TKey>
        where TUserRole : RavenUserRole<TKey>
        where TRoleClaim : RavenRoleClaim<TKey>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RavenRole{TKey}"/>.
        /// </summary>
        public RavenRole() { }

        /// <summary>
        /// Initializes a new instance of <see cref="RavenRole{TKey}"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        public RavenRole(string roleName) : this()
        {
            Name = roleName;
        }

        /// <summary>
        /// Navigation property for the users in this role.
        /// </summary>
        public IList<TUserRole> Users { get; } = new List<TUserRole>();

        /// <summary>
        /// Navigation property for claims in this role.
        /// </summary>
        public IList<TRoleClaim> Claims { get; } = new List<TRoleClaim>();

        /// <summary>
        /// Gets or sets the primary key for this role.
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the name for this role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the normalized name for this role.
        /// </summary>
        public string NormalizedName { get; set; }

        /// <summary>
        /// A random value that should change whenever a role is persisted to the store
        /// </summary>
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Returns the name of the role.
        /// </summary>
        /// <returns>The name of the role.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}