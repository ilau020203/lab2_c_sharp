using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    /// <summary>
    /// Class for containing all Magazine metadata, including editors and articles.
    /// </summary>
    class Magazine : Edition, IRateAndCopy, IEnumerable
    {
        /// <summary>
        /// Copy of Magazine instance as Edition.
        /// </summary>
        public Edition AsEdition
        {
            get
            {
                return new Edition(this.Title, this.ReleaseDate, this.Circulation);
            }
        }
        List<Article> _articles;
        List<Person> _editors;
        
        public Frequency Frequency { get; set; }

        /// <summary>
        /// Constructor with all necessary metadata.
        /// </summary>
        /// <param name="title">Title of the Magazine.</param>
        /// <param name="frequency">Frequency of Magazine release rate.</param>
        /// <param name="releaseDate">Release date</param>
        /// <param name="circulation">Number of copies of Magazine</param>
        public Magazine(string title, Frequency frequency, DateTime releaseDate, int circulation) : base(title, releaseDate, circulation)
        {
            this.Frequency = frequency;
            this._articles = new List<Article>();
            this._editors = new List<Person>();
        }

        /// <summary>
        /// Default construcrtor
        /// </summary>
        public Magazine() : this("blank title", Frequency.Weekly, DateTime.Now, 0)
        { }

        /// <summary>
        /// Articles included in current Magazine.
        /// </summary>
        /// <value>New Articles to replace previous article list.</value>
        public List<Article> Articles
        {
            get
            {
                return this._articles;
            }
            set
            {
                //Doesn't leave instance in undefined state. Just cancells the operation.
                List<Article> temp = new List<Article>();
                if (value == null)
                    throw new ArgumentNullException();
                foreach (Article article in value)
                {
                    if (article != null)
                    {
                        temp.Add(article.DeepCopy() as Article);
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }

                this._articles = temp;
            }
        }

        /// <summary>
        /// Articles with rating higher than specified.
        /// </summary>
        /// <param name="rating">Rating to specify.</param>
        public List<Article> ArticlesWithRatingHigherThan(double rating)
        {
            return this._articles
            .Cast<Article>()
            .Where((Article current) => current.Rating >= rating)
            .ToList();
        }

        /// <summary>
        /// Articles which names contain specified substring.
        /// </summary>
        /// <param name="substring">Substring to specify.</param>
        public List<Article> ArticlesWithNameContaining(string substring)
        {
            return this._articles
            .Cast<Article>()
            .Where((Article current) => current.Title.Contains(substring))
            .ToList();
        }

        /// <summary>
        /// Editors of current Magazine.
        /// </summary>
        /// <value>New Editors to replace previous editors list.</value>
        public List<Person> Editors
        {
            get
            {
                return this._editors;
            }
            set
            {
                //Doesn't leave instance in undefined state. Just cancells the operation.
                List<Person> temp = new List<Person>();
                if (value == null)
                    throw new ArgumentNullException();
                foreach (Person author in value)
                {
                    if (author != null)
                    {
                        temp.Add(author.DeepCopy() as Person);
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
                this._editors = temp;
            }
        }

        /// <summary>
        /// Append new editors to previous list.
        /// </summary>
        /// <param name="list">Editors to add.</param>
        public void AddEditors(params Person[] list)
        {
            this._editors.AddRange(list);
        }

        /// <summary>
        /// Total rating of all articles in current Magazine.
        /// </summary>
        public double Rating
        {
            get
            {
                return _articles.Cast<Article>().Aggregate(0.0, (double result, Article next) => result + next.Rating);
            }
        }

        /// <summary>
        /// Average rating of all articles in current Magazine.
        /// </summary>
        public double MeanRating
        {
            get
            {
                return _articles.Count!=0? _articles.Cast<Article>()
                .Select((Article next) => next.Rating)
                .Average():0;
            }
        }
        /// <summary>
        /// Add new Articles to previous list.
        /// </summary>
        /// <param name="list">Articles to add.</param>
        public void AddArticles(params Article[] list)
        {
            this._articles.AddRange(list);
        }

        /// <summary>
        /// Check if specified frequency is equal to current one.
        /// </summary>
        /// <param name="frequency">Frequency to compare.</param>
        public bool this[Frequency frequency] => frequency == this.Frequency;

        /// <summary>
        /// Multiline representation of current Magazine (Be carefull. It could be huge.).
        /// </summary>
        public override string ToString()
        {
            return
            $"Magazine instance: {{{Environment.NewLine}" +
            $"  Name: {this.Title},{Environment.NewLine}" +
            $"  Creation date: {this.ReleaseDate},{Environment.NewLine}" +
            $"  Frequency: {this.Frequency},{Environment.NewLine}" +
            $"  Rating: {this.Rating},{Environment.NewLine}" +
            $"  Authors: [{Environment.NewLine}" +
            String.Join(Environment.NewLine, String.Join(Environment.NewLine, this._editors.Cast<Person>()
                .Select((Person author) => author.ToString()))
            .Split(Environment.NewLine)
            .Select((string nextline) => $"    {nextline}")) + Environment.NewLine +
            $"  ]{Environment.NewLine}" +
            $"  Articles: [{Environment.NewLine}" +
            String.Join(Environment.NewLine, String.Join(Environment.NewLine, this._articles.Cast<Article>()
                .Select((Article article) => article.ToString()))
            .Split(Environment.NewLine)
            .Select((string nextline) => $"    {nextline}")) + Environment.NewLine +
            $"  ]{Environment.NewLine}" +
            $"}}";

        }

        /// <summary>
        /// Represents only Magazine's metadata.
        /// </summary>
        public virtual string ToShortString() => "Name: " + this.Title +
            " " + Frequency.ToString() + " " + ReleaseDate.ToShortDateString()
            + " Circulation:" + Circulation + " Rating:" + Rating;


        /// <summary>
        /// Makes membervise copy of current Magazine and all of it's elements.
        /// </summary>
        public object DeepCopy()
        {
            var temp = new Magazine(this.Title, this.Frequency, this.ReleaseDate, this.Circulation);
            temp.Articles = new List<Article>();
            temp.Articles.AddRange(this._articles);
            temp.Editors = new List<Person>();
            temp.Editors.AddRange(this._editors);
            return temp;
        }

       

        /// <summary>
        /// Represents articles, which authors were included in current Magazine's editors list.
        /// </summary>
        public IEnumerable ArticlesWithAuthorSameAsEditor()
        {
            foreach (Article article in this._articles.Cast<Article>())
            {
                if (this.Editors.Contains(article.Author))//includes
                {
                    yield return article;
                }
            }
            yield break;
        }

        /// <summary>
        /// Represents authors, whose articles didn't get in current Magazine.
        /// </summary>
        public IEnumerable EditorsWithNoArticles()
        {
            foreach (Person author in this._editors.Cast<Person>())
            {
                if (!this.Articles
                .Cast<Article>()
                .Select((Article article) => article.Author)//map
                .Contains(author))//includes
                {
                    yield return author;
                }
            }
            yield break;
        }

        /// <summary>
        /// Helping class to carry data for Article iteration.
        /// </summary>
        public class MagazineEnumerator : IEnumerator
        {
            internal IEnumerator RealEnumerator;

            public object Current
            {
                get => this.RealEnumerator.Current;
            }

            public bool MoveNext()
            {
                return RealEnumerator.MoveNext();
            }

            public void Reset()
            {
                RealEnumerator.Reset();
            }
        }
        /// <summary>
        /// Represents articles, which authors weren't included in current Magazine's editors list.
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator
            {
                RealEnumerator = this._articles
                .Where((Article article) => !this._editors.Contains(article.Author))
                .GetEnumerator()
            };
        }
    }
}
