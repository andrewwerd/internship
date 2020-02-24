using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class Review
    {
        public int Id;
        public int PartnerId;
        public int CustomerId;
        public string Text;
        public string Author;
        public int NumbersOfLike;
        public int NumbersOfDislike;
        public DateTime Date;
    }
}