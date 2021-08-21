using LotteryTicketsV1.BLL;
using LotteryTicketsV1.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryTicketsV1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {

        private TicketProcessing ticketProcessing;

        public  TicketController() 
        {
            this.ticketProcessing = new TicketProcessing();

        }

        [HttpPut("add/")]
        public IActionResult add(TicketAddReceiveDTO ticketDTO)
        {
            try
            {
                //throw new Exception("not implemented yet");

                return Ok(this.ticketProcessing.add(ticketDTO));
            } 
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpPatch("edit/")]
        public IActionResult edit(TicketReceiveDTO ticketDTO)
        {
            try
            {
                //throw new Exception("not implemented yet");

                return Ok(this.ticketProcessing.update(ticketDTO));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("get/")]
        public IActionResult get()
        {
            try
            {


                return Ok(this.ticketProcessing.get());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("get/{number}")]
        public IActionResult getByNumber(Guid number)
        {
            try
            {
                //throw new Exception("not implemented yet");
                TicketResponseDTO ticketResponseDTO = new TicketResponseDTO();

                return Ok(ticketResponseDTO);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("delete/{number}")]
        public IActionResult delete(Guid number)
        {
            try
            {
                //throw new Exception("not implemented yet");
                TicketResponseDTO ticketResponseDTO = new TicketResponseDTO();

                return Ok(this.ticketProcessing.delete(number));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
