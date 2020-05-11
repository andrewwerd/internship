using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Review
{
    public class ReviewDto
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public int NumbersOfLike { get; set; }
        public int NumbersOfDislike { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public long PartnerId { get; set; }
        public long CustomerId { get; set; }
        public long? AnswerReviewId { get; set; }
    }
}
