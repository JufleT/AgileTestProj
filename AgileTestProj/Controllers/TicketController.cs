using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Repository.Abstract.IRepository;
using Agile.Repository.Abstract.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgileTestProj.Controllers
{
    public class TicketController : AgileBaseController
    {
        private readonly ITicketRepository ticketRepository;
           public TicketController(ITicketRepository ticketRepository)
           {
               this.ticketRepository = ticketRepository;
           }

        [HttpPost]
        [Route("ticket")]
        public IActionResult Create(Ticket ticket)
        {

            ticket.TicketId = Guid.NewGuid();
            ticket.TicketStatus = ticket.TicketStatus ?? 0;

            if (ModelState.IsValid) return BadRequest();

            ticketRepository.Create(ticket);

            return Ok(ticket);
          
        }

        [HttpGet]
        [Route("ticket")]
        public IActionResult GetAll()
        {
            var tickets = ticketRepository.Get();

            return Ok(tickets);
        }

        [HttpGet("{id}")]
        [Route("ticket/getbyid")]
        public IActionResult Get(Guid id)
        {
            var ticket = ticketRepository.Get(x=>x.TicketId==id).FirstOrDefault();
            
            return Ok(ticket);// if object is empty it'll be 204 error = NO Content(Tested)
        }

        [HttpPut("{id}")]
        [Route("ticket/update")]
        public IActionResult Update(Guid id, Ticket ticket)
        {
            var ticketDB = ticketRepository.Get(x => x.TicketId == id).FirstOrDefault();
            if (ticketDB == null) return NotFound();

            if (ticket.TicketStatus != null) ticketDB.TicketStatus = ticket.TicketStatus;
            if (ticket.Description != null) ticketDB.Description = ticket.Description;
            if (ticket.Name != null) ticketDB.Name = ticket.Name;

            ticketRepository.Update(ticketDB);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Route("ticket/delete")]
        public IActionResult Delete(Guid id)
        {
            var ticket = ticketRepository.Get(x => x.TicketId == id).FirstOrDefault();
            if (ticket == null) BadRequest();

            ticketRepository.Remove(ticket);

            return Ok();
        }


    }
}