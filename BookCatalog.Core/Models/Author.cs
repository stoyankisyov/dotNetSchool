﻿#nullable disable

namespace BookCatalog.Core.Models
{
    public class Author
    {
        private const int nameMaxSymbolCount = 200;
        private string _firstName;
        private string _lastName;

        public DateOnly? BirthDate { get; set; }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length > nameMaxSymbolCount)
                {
                    throw new ArgumentException("First name exceeds 200 symbols.");
                }

                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length > nameMaxSymbolCount)
                {
                    throw new ArgumentException("Last name exceeds 200 symbols.");
                }

                _lastName = value;
            }
        }

        public Author(string firstName, string lastName, DateOnly? birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public override bool Equals(object obj)     
            => obj is Author other ? FirstName == other.FirstName && LastName == other.LastName && BirthDate == other.BirthDate : false;

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, BirthDate);
        }
    }
}
