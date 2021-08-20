using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryTicketsV1.DTO
{
    public class TicketDTO
    {
        public int id { get; set; }
        public int number { get; set; }
        public int circulation { get; set; }
        public int choosedNumbersCount { get; set; }
        public List<int> choosedNumbers { get; set; }


        public TicketDTO()
        {

        }
    }

    public class TicketAddReceiveDTO
    {
        public int number { get; set; }
        public int circulation { get; set; }
        public int choosedNumbersCount { get; set; }
        public List<int> choosedNumbers { get; set; }


        public TicketAddReceiveDTO()
        {

        }
    }

    public class TicketReceiveDTO
    {
        public int id { get; set; }
        public int number { get; set; }
        public int circulation { get; set; }
        public int choosedNumbersCount { get; set; }
        public List<int> choosedNumbers { get; set; }


        public TicketReceiveDTO()
        {

        }
    }

    public class TicketResponseDTO
    {
        public int id { get; set; }
        public int number { get; set; }
        public int circulation { get; set; }
        public int choosedNumbersCount { get; set; }
        public List<int> choosedNumbers { get; set; }


        public TicketResponseDTO()
        {

        }
    }

}
