﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoofTwo.DTO
{
    public class Item
    {
        [JsonProperty("dstOffset")]
        public int OffsetForSummer { get; set; }

        [JsonProperty("rawOffset")]
        public int OffsetFromUTC { get; set; }
        public DateTime DateTime { get; set; }
        public string TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
    }
}
