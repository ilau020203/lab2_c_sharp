using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace lab2
{
    /// <summary>
    /// Class for containing signle Edition metadata.
    /// </summary>
    [Serializable]
    public class Edition : IComparable, IComparer<Edition> , INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor with all necessary parameters.
        /// </summary>
        /// <param name="title">Title of the Edition.</param>
        /// <param name="releaseDate">Release date of the Edition.</param>
        /// <param name="circulation">Number of copies of the Edition.</param>
        protected internal Edition(string title, DateTime releaseDate, int circulation)
        {
            this._title = title;
            this._releaseDate = releaseDate;
            this._circulation = circulation;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected Edition() : this("blank title", DateTime.Now, 0) { }
        public event PropertyChangedEventHandler PropertyChanged;
        protected string _title;
        protected DateTime _releaseDate;
        protected int _circulation;


        /// <summary>
        /// Represents Title of the Edition.
        /// </summary>
        /// <value>New Title for the Edition.</value>
        public string Title
        {
            get => this._title;
            set => this._title = value;
        }

        /// <summary>
        /// Release date of the Edition.
        /// </summary>
        /// <value>New Edition release date.</value>
        public DateTime ReleaseDate
        {
            get => this._releaseDate;
            set 
            {
                this._releaseDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));
            }
        }

        /// <summary>
        /// Number of copies of the Edition.
        /// </summary>
        /// <value>New number of copies. Should be positive.</value>
        /// <exception cref="ArgumentOutOfRangeException">Raises exception if argument was less than zero.</exception>
        public int Circulation
        {
            get
            {
                return this._circulation;
            }
            set
            {
                if (value >= 0)
                {
                    this._circulation = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Circulation"));
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Circulation",
                    value,
                    $"Circulation cannot be less than zero.");
                }
            }
        }

        /// <summary>
        /// Membervise comparsion of two Editions.
        /// </summary>
        /// <param name="obj">Other object to compare.</param>

        public override bool Equals(object obj)
        {
            return obj is Edition other &&
           this.Circulation == other._circulation &&
           this._releaseDate == other.ReleaseDate &&
           this._title == other._title;

        }

        /// <summary>
        /// Equality operator overriding.
        /// Membervise comparsion of two Editions.
        /// </summary>
        public static bool operator ==(Edition left, object right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Unequality operator overriding.
        /// Membervise comparsion of two Editions.
        /// </summary>
        public static bool operator !=(Edition left, object right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Default hash overriding.
        /// Hash codes of equal Editions is also equal.
        /// </summary>

        public override int GetHashCode()
        {
            return this._circulation.GetHashCode() +
            this._title.GetHashCode() +
            this._releaseDate.GetHashCode();
        }





        /// <summary>
        /// Multiline String representation of Edition.
        /// </summary>
        public override string ToString()
        {
            return $"Edition instance: {{{Environment.NewLine}" +
            $"  Title: {this._title},{Environment.NewLine}" +
            $"  Release date: {this._releaseDate},{Environment.NewLine}" +
            $"  Circulation: {this._circulation} copies,{Environment.NewLine}" +
            $"}}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (obj is Edition otherEdition)
                return this._title.CompareTo(otherEdition._title);
            else
                throw new ArgumentException("Object is not a Edition");
        }

        public int Compare(Edition x, Edition y)
        {
            return x._releaseDate.CompareTo(y._releaseDate);
        }

    }

    class CirculationComparer : IComparer<Edition>
    {
        public int Compare(Edition p, Edition q)
        {
            return p.Circulation.CompareTo(q.Circulation);
        }
    }
}