using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public class News : Entity<long>
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ShortBody { get; set; }
        public DateTime DateOfCreation { get; set; }
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
    }
}