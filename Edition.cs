using System;

namespace lab2
{
    /// <summary>
    /// Class for containing signle Edition metadata.
    /// </summary>
    public class Edition
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
            set => this._releaseDate = value;
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
            if(obj is Edition)
            {
                Edition edition = obj as Edition;

                return  this.Circulation == edition._circulation &&
                           this._releaseDate == edition.ReleaseDate &&
                           this._title == edition._title;
            }
            return false;
           
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
    }
}