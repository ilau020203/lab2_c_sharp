using System;
using System.Linq;

namespace lab2
{
    /// <summary>
    /// Class for containing Article Metadata and author information/
    /// </summary>
    class Article : IRateAndCopy
    {
        Person _author;
        string _title;
        double _rating;

        /// <summary>
        /// Represents rating of the Article
        /// </summary>
        /// <value>New rating</value>
        /// public double Rating
        public double Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
            }
        }

        /// <summary>
        /// Represents title of the Article
        /// </summary>
        /// <value>New title</value>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// Author of the Article
        /// </summary>
        /// <value>New author</value>
        public Person Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        /// <summary>
        /// Article constructor with author initiation
        /// </summary>
        /// <param name="author">Author of the article</param>
        /// <param name="articleTitle">Title of the Article</param>
        /// <param name="articleRating">Rating of the Article</param>
        public Article(Person author, string articleTitle, double articleRating)
        {
            _author = (Person)author.DeepCopy();
            _title = articleTitle;
            _rating = articleRating;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Article() : this(new Person(), "Article title", 0) { }

        /// <summary>
        /// Multiline String Representation of the Article
        /// </summary>
        public override string ToString()
        {
            return $"Article instance: {{{Environment.NewLine}" +
            $"  Author: {{{Environment.NewLine}" +
            String.Join(Environment.NewLine, this._author
            .ToString()
            .Split(Environment.NewLine)
            .Select((string nextline) => $"    {nextline}")) + Environment.NewLine +
            $"  }}{Environment.NewLine}" +
            $"  Title: {this._title},{Environment.NewLine}" +
            $"  Rating: {this._rating},{Environment.NewLine}" +
            $"}}";
        }

        /// <summary>
        /// Makes copy of object and all of it's content.
        /// </summary>

        public object DeepCopy()
        {
            return new Article
            {
                _author = this._author.DeepCopy() as Person,
                _title = new string(this._title),
                _rating = this._rating
            };
        }
    }
}
