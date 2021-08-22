using LotteryTicketsV1.DTO;
using LotteryTicketsV1.Exceptions;
using LotteryTicketsV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using LotteryTicketsV1.DataAccess;
using System.Diagnostics;

namespace LotteryTicketsV1.BLL
{
    public class TicketProcessing
    {
        private const int MIN_CHOOSED_NUMBERS_COUNT = 6;
        private const int MAX_CHOOSED_NUMBERS_COUNT = 17;

        private const int MIN_CIRCULATION_NUMBER = 1;
        private const int MAX_CIRCULATION_NUMBER = 65535;

        private DBStore store;

        public TicketProcessing()
        {
            this.store = new DBStore();
        }


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

        private string getAddMySQLString(Ticket ticket)
        {
            StringBuilder stringBuilder = new StringBuilder();
            //"INSERT INTO lotteryticketsdb.tickets(number, circulation, choosed) VALUES ('b7f009b4-0281-11ec-9a03-0242ac130003', 1 , 2)"
            stringBuilder.Append("INSERT INTO ");
            stringBuilder.Append("lotteryticketsdb.tickets(number, circulation, choosed) ");
            stringBuilder.Append("VALUES ");
            stringBuilder.Append("(");
            stringBuilder.Append("'");
            stringBuilder.Append(ticket.number);
            stringBuilder.Append("'");
            stringBuilder.Append(", ");
            stringBuilder.Append(ticket.circulation);
            stringBuilder.Append(", ");
            stringBuilder.Append(ticket.choosedNumbersCount);

            stringBuilder.Append(")");

            Debug.WriteLine(stringBuilder.ToString());

            return stringBuilder.ToString();
        }


        public TicketResponseDTO add(TicketAddReceiveDTO ticketDTO)
        {
            
            this.checkValidForAdd(ticketDTO);

            ticketDTO.number = Guid.NewGuid();

            Ticket ticket = ticketDTO.Adapt<Ticket>();

            this.store.connect();

            //Put to DB

            //string sqlString = this.getAddMySQLString(ticket);

            //this.store.execute(sqlString);

            List<ProcedureParameter> parameters = new List<ProcedureParameter>();
            ProcedureParameter param = new ProcedureParameter();

            param.key = "pNumber";
            param.value = ticket.number.ToString();
            parameters.Add(param);

            param = new ProcedureParameter();
            param.key = "pCirculation";
            param.value = ticket.circulation.ToString();
            parameters.Add(param);

            param = new ProcedureParameter();
            param.key = "pChoosedCount";
            param.value = ticket.choosedNumbersCount.ToString();
            parameters.Add(param);

            param = new ProcedureParameter();
            param.key = "pSelectedNumbers";
            ticket.choosedNumbers.Sort();
            param.value = string.Join(" ", ticket.choosedNumbers);
            parameters.Add(param);

            this.store.executeSP("add_ticket", parameters);

            //Get from DB

            this.store.disconnect();

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

            this.store.connect();

            //this.store.execute(sqlString);

            List<ProcedureParameter> parameters = new List<ProcedureParameter>();
            ProcedureParameter param;


            param = new ProcedureParameter();
            param.key = "pNumber";
            param.value = ticket.number.ToString();
            parameters.Add(param);

            param = new ProcedureParameter();
            param.key = "pCirculation";
            param.value = ticket.circulation.ToString();
            parameters.Add(param);

            param = new ProcedureParameter();
            param.key = "pChoosedCount";
            param.value = ticket.choosedNumbersCount.ToString();
            parameters.Add(param);

            param = new ProcedureParameter();
            param.key = "pSelectedNumbers";
            param.value = string.Join(" ", ticket.choosedNumbers);
            parameters.Add(param);

            this.store.executeSP("edit_ticket", parameters);

            this.store.disconnect();


            TicketResponseDTO ticketResponseDTO = ticket.Adapt<TicketResponseDTO>();

            return ticketResponseDTO;
        }

        #endregion

        #region get methods
        public List<TicketResponseDTO> get()
        {
            List<Ticket> tickets = new List<Ticket>();

            Ticket ticket = new Ticket();

            this.store.connect();
            var reader = this.store.getDataReader("get_all_tickets");

            while (reader.Read())
            {
                ticket = new Ticket();

                ticket.id = Int32.Parse(reader.GetString("id"));

                ticket.number = Guid.Parse(reader.GetString("number"));
                ticket.circulation = Int32.Parse(reader.GetString("circulation"));
                ticket.choosedNumbersCount = Int32.Parse(reader.GetString("choosedCount"));

                var selectedNumbers = reader.GetString("selectedNumbers").Split(" ");

                ticket.choosedNumbers = new List<int>();
                for (var i = 0; i < selectedNumbers.Length; i++)
                {
                    Debug.WriteLine("&&&" + selectedNumbers[i]);

                    var num = selectedNumbers[i];
                    if ((num != null))
                    {
                        ticket.choosedNumbers.Add(Int16.Parse(num));
                    }

                    ticket.choosedNumbers.Sort();
                }

                tickets.Add(ticket);

                ticket = null;
            }

            this.store.disconnect();

            List<TicketResponseDTO> ticketResponseDTO = tickets.Adapt<List<TicketResponseDTO>>();

            return ticketResponseDTO;
        }

        #endregion

        #region delete methods

        public TicketResponseDTO delete(Guid number)
        {
            Ticket ticket = new Ticket();
            this.store.connect();


            List<ProcedureParameter> parameters = new List<ProcedureParameter>();
            ProcedureParameter param;

            param = new ProcedureParameter();
            param.key = "pNumber";
            param.value = number.ToString();
            parameters.Add(param);

            this.store.executeSP("delete_ticket", parameters);

            this.store.disconnect();

            TicketResponseDTO ticketResponseDTO = ticket.Adapt<TicketResponseDTO>();

            return ticketResponseDTO;
        }

        #endregion

    }
}
