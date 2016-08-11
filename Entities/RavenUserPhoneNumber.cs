using System;

namespace RavenDB.AspNetCore.Identity.Entities
{
    public class RavenUserPhoneNumber
    {
        public RavenUserPhoneNumber(string phoneNumber, string userId)
        {
            if (phoneNumber == null) throw new ArgumentNullException(nameof(phoneNumber));

            Id = GenerateKey(phoneNumber);
            UserId = userId;
            PhoneNumber = phoneNumber;
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }

        public ConfirmationRecord ConfirmationRecord { get; set; }

        public void SetConfirmed()
        {
            if (ConfirmationRecord == null)
            {
                ConfirmationRecord = new ConfirmationRecord();
            }
        }

        public void SetUnconfirmed()
        {
            ConfirmationRecord = null;
        }

        internal static string GenerateKey(string phoneNumber)
        {
            return string.Format(Constants.RavenUserPhoneNumberKeyTemplate, phoneNumber);
        }
    }
}