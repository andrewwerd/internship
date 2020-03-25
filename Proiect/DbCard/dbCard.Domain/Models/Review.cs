using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain.Models
{
    public class Review:Entity<long>
    {
        public string Body { get; set; }
        public string AuthorName { get; set; }
        public int NumbersOfLike { get; set; }
        public int NumbersOfDislike { get; set; }
        public DateTime Date { get; set; }
        public long? AnswerReview { get; set; }
        public long PartnerId { get; set; }
        public long CustomerId{ get; set; }
        public virtual List<Review> InverseAnswerReviewNavigation { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Partner Partner { get; set; }
        public Review AnswerReviewNavigation { get; set; }
    }
}