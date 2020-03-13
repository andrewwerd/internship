using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class News
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public byte[] Foto { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ShortBody { get; set; }
        public DateTime DateOfCreation { get; set; }

        public virtual Partners Partner { get; set; }
    }
}
