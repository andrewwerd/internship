using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Reviews
    {
        public Reviews()
        {
            InverseAnswerReviewNavigation = new HashSet<Reviews>();
        }

        public long Id { get; set; }
        public long PartnerId { get; set; }
        public long? CustomerId { get; set; }
        public string Body { get; set; }
        public int NumbersOfLikes { get; set; }
        public int NumbersOfDislakes { get; set; }
        public long? AnswerReview { get; set; }

        public virtual Reviews AnswerReviewNavigation { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Partners Partner { get; set; }
        public virtual ICollection<Reviews> InverseAnswerReviewNavigation { get; set; }
    }
}
