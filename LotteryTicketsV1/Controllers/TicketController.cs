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
        public  TicketController() 
        {


        }

        [HttpPut("add/")]
        public IActionResult add(TicketAddReceiveDTO ticketDTO)
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

        [HttpPatch("edit/")]
        public IActionResult edit(TicketReceiveDTO ticketDTO)
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

        [HttpGet("get/")]
        public IActionResult get()
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

        [HttpGet("get/{number}")]
        public IActionResult getByNumber(int number)
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

        [HttpDelete("delete/{id}")]
        public IActionResult delete(int id)
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
    }
}
