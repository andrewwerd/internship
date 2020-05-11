﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Filial
{
    public class ScheduleForAdd
    {
        [Required]
        public string Monday { get; set; }
        [Required]
        public string Tuesday { get; set; }
        [Required]
        public string Wednesday { get; set; }
        [Required]
        public string Thursday { get; set; }
        [Required]
        public string Friday { get; set; }
        [Required]
        public string Saturday { get; set; }
        [Required]
        public string Sunday { get; set; }
        public long FilialId { get; set; }
    }
}