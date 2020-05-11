using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Review
{
    public class ReviewForAdd
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long PartnerId { get; set; }
        public long? AnswerReviewId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [Range(1,10)]
        public int Score { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Body { get; set; }
    }
}
