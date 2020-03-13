using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Rewiews
    {
        public Rewiews()
        {
            InverseAnswerRewiewNavigation = new HashSet<Rewiews>();
        }

        public int Id { get; set; }
        public int PartnerId { get; set; }
        public int? CustomerId { get; set; }
        public string Body { get; set; }
        public int NumbersOfLikes { get; set; }
        public int NumbersOfDislakes { get; set; }
        public int? AnswerRewiew { get; set; }

        public virtual Rewiews AnswerRewiewNavigation { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Partners Partner { get; set; }
        public virtual ICollection<Rewiews> InverseAnswerRewiewNavigation { get; set; }
    }
}
