using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessagesServer.Models;



namespace MessagesServer.Controllers
{

    // [ApiController]
    //make it ControllerBase again
    public class MessagesController : Controller
    {

        private readonly MessagesServerContext _db;
        // = new MessagesServerContext();

        public MessagesController(MessagesServerContext db)
        {
            _db = db;
        }


        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get()
        {
            Message newMessage = new Message();
            newMessage.MessageId = 111;
            newMessage.MessageNote = "test";
            newMessage.MessageText = "auto generated";
            newMessage.MessageNumber = 1;

            _db.MessagesTest1.Add(newMessage);
            _db.SaveChanges();

            return _db.MessagesTest1.ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Message message)
        {
            _db.MessagesTest1.Add(message);
            _db.SaveChanges();
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}