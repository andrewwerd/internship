using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.Filial
{
    public class FilialDTO
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public ScheduleDto Schedule { get; set; }
        public string PhoneNumber { get; set; }
        public long PartnerId { get; set; }
    }
}
