using LotteryTicketsV1.DTO;
using LotteryTicketsV1.Exceptions;
using LotteryTicketsV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;


namespace LotteryTicketsV1.BLL
{
    public class TicketProcessing
    {
        public const int MIN_CHOOSED_NUMBERS_COUNT = 6;
        public const int MAX_CHOOSED_NUMBERS_COUNT = 17;

        public const int MIN_CIRCULATION_NUMBER = 1;
        public const int MAX_CIRCULATION_NUMBER = 65535;


        #region add methods
        private void checkValidForAdd(TicketAddReceiveDTO ticketDTO)
        {
            if (ticketDTO.circulation < MIN_CIRCULATION_NUMBER)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("too little circulation number: ");
                errText.Append(ticketDTO.choosedNumbersCount.ToString() + " ");
                errText.Append("allowed range: ");
                errText.Append("(");
                errText.Append(MIN_CIRCULATION_NUMBER);
                errText.Append("; ");
                errText.Append(MAX_CIRCULATION_NUMBER);
                errText.Append(")");

                throw new AddException(errText.ToString());
            }

            if (ticketDTO.circulation < MIN_CIRCULATION_NUMBER)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("too big circulation number: ");
                errText.Append(ticketDTO.choosedNumbersCount.ToString() + " ");
                errText.Append("allowed range: ");
                errText.Append("(");
                errText.Append(MIN_CIRCULATION_NUMBER);
                errText.Append("; ");
                errText.Append(MAX_CIRCULATION_NUMBER);
                errText.Append(")");

                throw new AddException(errText.ToString());
            }

            if (ticketDTO.choosedNumbersCount < MIN_CHOOSED_NUMBERS_COUNT)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("too few choosed numbers: ");
                errText.Append(ticketDTO.choosedNumbersCount.ToString() + " ");
                errText.Append("allowed range: ");
                errText.Append("(");
                errText.Append(MIN_CHOOSED_NUMBERS_COUNT);
                errText.Append("; ");
                errText.Append(MAX_CHOOSED_NUMBERS_COUNT);
                errText.Append(")");

                throw new AddException(errText.ToString());
            }

            if (ticketDTO.choosedNumbersCount > MAX_CHOOSED_NUMBERS_COUNT)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("too many choosed numbers: ");
                errText.Append(ticketDTO.choosedNumbersCount.ToString() + " ");
                errText.Append("allowed range: ");
                errText.Append("(");
                errText.Append(MIN_CHOOSED_NUMBERS_COUNT);
                errText.Append("; ");
                errText.Append(MAX_CHOOSED_NUMBERS_COUNT);
                errText.Append(")");

                throw new AddException(errText.ToString());
            }

            if (ticketDTO.choosedNumbers == null)
            {
                throw new AddException("no list of choosed numbers");
            }

            if (ticketDTO.choosedNumbers.Count == 0)
            {
                throw new AddException("empty list of choosed numbers: " + ticketDTO.choosedNumbersCount);
            }

            if (ticketDTO.choosedNumbersCount != ticketDTO.choosedNumbers.Count)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("choosedNumberCount ");
                errText.Append("(");
                errText.Append(ticketDTO.choosedNumbersCount);
                errText.Append(") ");
                errText.Append("(");
                errText.Append(ticketDTO.choosedNumbers.Count);
                errText.Append(") ");
                errText.Append(" did not matched:");

                throw new AddException(errText.ToString());
            }

        }

        public TicketResponseDTO add(TicketAddReceiveDTO ticketDTO)
        {
            this.checkValidForAdd(ticketDTO);

            Ticket ticket = ticketDTO.Adapt<Ticket>();

            //Put to DB

            //Get from DB


            TicketResponseDTO ticketResponseDTO = ticket.Adapt<TicketResponseDTO>();

            return ticketResponseDTO;
        }

        #endregion

        #region update methods
        private void checkValidForUpdate(TicketReceiveDTO ticketDTO)
        {
            if (ticketDTO.circulation < MIN_CIRCULATION_NUMBER)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("too little circulation number: ");
                errText.Append(ticketDTO.choosedNumbersCount.ToString() + " ");
                errText.Append("allowed range: ");
                errText.Append("(");
                errText.Append(MIN_CIRCULATION_NUMBER);
                errText.Append("; ");
                errText.Append(MAX_CIRCULATION_NUMBER);
                errText.Append(")");

                throw new AddException(errText.ToString());
            }

            if (ticketDTO.circulation < MIN_CIRCULATION_NUMBER)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("too big circulation number: ");
                errText.Append(ticketDTO.choosedNumbersCount.ToString() + " ");
                errText.Append("allowed range: ");
                errText.Append("(");
                errText.Append(MIN_CIRCULATION_NUMBER);
                errText.Append("; ");
                errText.Append(MAX_CIRCULATION_NUMBER);
                errText.Append(")");

                throw new AddException(errText.ToString());
            }

            if (ticketDTO.choosedNumbersCount < MIN_CHOOSED_NUMBERS_COUNT)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("too few choosed numbers: ");
                errText.Append(ticketDTO.choosedNumbersCount.ToString() + " ");
                errText.Append("allowed range: ");
                errText.Append("(");
                errText.Append(MIN_CHOOSED_NUMBERS_COUNT);
                errText.Append("; ");
                errText.Append(MAX_CHOOSED_NUMBERS_COUNT);
                errText.Append(")");

                throw new AddException(errText.ToString());
            }

            if (ticketDTO.choosedNumbersCount > MAX_CHOOSED_NUMBERS_COUNT)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("too many choosed numbers: ");
                errText.Append(ticketDTO.choosedNumbersCount.ToString() + " ");
                errText.Append("allowed range: ");
                errText.Append("(");
                errText.Append(MIN_CHOOSED_NUMBERS_COUNT);
                errText.Append("; ");
                errText.Append(MAX_CHOOSED_NUMBERS_COUNT);
                errText.Append(")");

                throw new AddException(errText.ToString());
            }

            if (ticketDTO.choosedNumbers == null)
            {
                throw new AddException("no list of choosed numbers");
            }

            if (ticketDTO.choosedNumbers.Count == 0)
            {
                throw new AddException("empty list of choosed numbers: " + ticketDTO.choosedNumbersCount);
            }

            if (ticketDTO.choosedNumbersCount != ticketDTO.choosedNumbers.Count)
            {
                StringBuilder errText = new StringBuilder();
                errText.Append("choosedNumberCount ");
                errText.Append("(");
                errText.Append(ticketDTO.choosedNumbersCount);
                errText.Append(") ");
                errText.Append("(");
                errText.Append(ticketDTO.choosedNumbers.Count);
                errText.Append(") ");
                errText.Append(" did not matched:");

                throw new AddException(errText.ToString());
            }

        }

        public TicketResponseDTO update(TicketReceiveDTO ticketDTO)
        {
            this.checkValidForUpdate(ticketDTO);

            Ticket ticket = ticketDTO.Adapt<Ticket>();

            //update to DB

            //Get from DB


            TicketResponseDTO ticketResponseDTO = ticket.Adapt<TicketResponseDTO>();

            return ticketResponseDTO;
        }

        #endregion

        #region get methods
        public List<TicketResponseDTO> get()
        {
            List<Ticket> tickets = new List<Ticket>();

            //Get all from DB


            List<TicketResponseDTO> ticketResponseDTO = tickets.Adapt<List<TicketResponseDTO>>();

            return ticketResponseDTO;
        }

        #endregion

        #region delete methods
        public TicketResponseDTO delete(Guid number)
        {
            Ticket ticket = new Ticket();

            //Get from DB

            //delete from DB

            TicketResponseDTO ticketResponseDTO = ticket.Adapt<TicketResponseDTO>();

            return ticketResponseDTO;
        }

        #endregion

    }
}
