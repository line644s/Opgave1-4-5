using System;
using ModelLib.Exceptions;

namespace ModelLib
{
    public class Bog
    {
        private string _title;
        private string _forfatter;
        private int _sidetal;
        private string _isbn13;

        public Bog(string title, string forfatter, int sidetal, string isbn13)
        {
            Title = title;
            Forfatter = forfatter;
            Sidetal = sidetal;
            Isbn13 = isbn13;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == null)
                {
                    throw  new  ExceptionEmpty("Titlen må ikke være tom");
                }
                if (value.Length >= 2)
                {
                    _title = value;
                }
                else
                {
                    throw new ExceptionTooSmall("Title skal være minium 2 charakter lang");
                }
            }
        }

        public string Forfatter
        {
            get { return _forfatter;}
            set { _forfatter = value; }
        }

        public int Sidetal
        {
            get { return _sidetal; }
            set
            {
                if (value >= 10)
                {
                    if (value <= 1000)
                    {
                        _sidetal = value;
                    }
                    else
                    {
                        throw new ExceptionTooBig("Sidetal skal være mindre end el 1000");
                    }
                }
                else
                {
                    throw new ExceptionTooSmall("Sidetal skal være større end el 10");
                }
            }
        }

        public string Isbn13
        {
            get { return _isbn13; }
            set
            {
                if (value == null)
                {
                    throw new ExceptionEmpty("Isbn13 må ikke være tom");
                }

                if (value.Length < 13)
                {
                    throw new ExceptionTooSmall("Isbn13 er for kort, det skal være 13 karakter langt");
                }
                else if (value.Length > 13)
                {
                    throw new ExceptionTooBig("Isbn13 er for langt, det skal være 13 karakter langt");
                }
                else
                {
                    _isbn13 = value;
                }

            }
        }

        public override string ToString()
        {
            return $"Title: {Title}, Forfatter: {Forfatter}, Sidetal: {Sidetal}, isbn13: {Isbn13}";
        }
    }
}
