using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    /// <summary>
    /// Class for containing single person data.
    /// </summary>
    class Person
    {
        string _name;
        string _surname;
        DateTime _birthday;

        /// <summary>
        /// Constructor with all necessary data< to represent a person.
        /// </summary>
        /// <param name="name">Person's Name.</param>
        /// <param name="surname">Person's Surname/</param>
        /// <param name="birthday">Person's Nirthday/</param>
        public Person(string name, string surname, DateTime birthday)
        {
            this._name = name;
            this._surname = surname;
            this._birthday = birthday;
        }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Person() : this("Obama", "Ivanovich", new DateTime(2000, 1, 1))
        { }

        /// <summary>
        /// Representation of Person's Name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Representation of Person's Surname.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }

        /// <summary>
        /// Representation of Person's Birthday.
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }
        }

        /// <summary>
        /// Representation of Person's birth Year.
        /// </summary>
        /// <value>Changes Person's birth year, bul leaves all other data untouched.</value>
        public int Year
        {
            get
            {
                return Birthday.Year;
            }
            set
            {
                Birthday = new DateTime(value, Birthday.Month, Birthday.Day);
            }
        }

        /// <summary>
        /// Multiline representation of Person.
        /// </summary>
        public override string ToString()
        {
            return $"Pesron instance: {{{Environment.NewLine}" +
                   $"  Name: {this._name},{Environment.NewLine}" +
                   $"  Surname: {this._surname},{Environment.NewLine}" +
                   $"  Birthday: {this._birthday},{Environment.NewLine}" +
                   $"}}";
        }

        /// <summary>
        /// Single line representation of person with no birthday.
        /// </summary>
        /// <returns></returns>
        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }

        /// <summary>
        /// Membervise check for equality of two Persons.
        /// </summary>
        /// <param name="obj">Other Person to check for equality.</param>
        public override bool Equals(object obj)
        {
            
            return obj is Person other &&
            this._name == other._name &&
            this._surname == other._surname &&
            this.Birthday == other._birthday;
        }


        /// <summary>
        /// Calculating Hash code for Person.
        /// Hash codes for Persons with same data are always equal.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this._name.GetHashCode() + this._surname.GetHashCode() + this._birthday.GetHashCode();
        }

        /// <summary>
        /// Makes membervise copy of current Person and all of it's elements.
        /// </summary>
        public virtual object DeepCopy()
        {
            Person temp = new Person
            {
                _name = new string(this._name),
                _surname = new string(this._surname),
                _birthday = this._birthday //struct type
            };
            return temp;
        }

        /// <summary>
        /// Equality operator overriding.
        /// Membervise comparsion of two Editions.
        /// </summary>
        public static bool operator ==(Person left, object right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Unquality operator overriding.
        /// Membervise comparsion of two Editions.
        /// </summary>
        public static bool operator !=(Person left, object right)
        {
            return !left.Equals(right);
        }
    }
}
