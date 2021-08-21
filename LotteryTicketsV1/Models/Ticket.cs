using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryTicketsV1.Models
{
    public class Ticket
    {
        public int id { get; set; }
        public Guid number { get; set; }
        public int circulation { get; set; }
        public int choosedNumbersCount { get; set; }
        public List<int> choosedNumbers { get; set; }


        public Ticket()
        {

        }
    }
}
