using System;

namespace RavenDB.AspNetCore.Identity.Entities
{
    /// <summary>
    /// Represents the user's e-mail address. This is stored in a separate document as
    /// we need to ensure the uniqueness of the e-mail address.
    /// </summary>
    /// <remarks>
    /// Storing the e-mail in a separate document to ensure it's uniqueness by the Id of the document
    /// will only work out if the provided IAsyncDocumentSession is configured for optimistic concurrency.
    /// </remarks>
    public class RavenUserEmail
    {
        public RavenUserEmail(string email, string userId)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (userId == null) throw new ArgumentNullException(nameof(userId));

            Id = GenerateKey(email);
            UserId = userId;
            Email = email;
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }

        public ConfirmationRecord ConfirmationRecord { get; private set; }

        internal void SetConfirmed()
        {
            if (ConfirmationRecord == null)
            {
                ConfirmationRecord = new ConfirmationRecord();
            }
        }

        internal void SetUnconfirmed()
        {
            ConfirmationRecord = null;
        }

        internal static string GenerateKey(string email)
        {
            return string.Format(Constants.RavenUserEmailKeyTemplate, email);
        }
    }
}