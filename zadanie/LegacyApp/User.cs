using System;

namespace LegacyApp
{
    public class User
    {
        private string _firstName;
        public string FirstName 
        { 
            get => _firstName; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or whitespace.");
                }
                _firstName = value;
            }
        }

        private string _lastName;
        public string LastName 
        { 
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or whitespace.");
                }
                _lastName = value;
            } 
        }
        
        private string _email;
        public string Email 
        {
            get => _email;
            set
            {
                if (value.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email cannot be null or whitespace.");
                }
                if (!value.Contains("@") || !value.Contains("."))
                {
                    throw new ArgumentException("Invalid email, @ or '.' missing");
                }
                _email = value;
            } 
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            internal set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Date of birth cannot be in the future.");
                }
                _dateOfBirth = value;
            }
        }

        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
        public Client Client { get; internal set; }
    }
}