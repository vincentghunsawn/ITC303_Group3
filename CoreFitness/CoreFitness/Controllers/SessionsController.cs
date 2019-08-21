using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreFitness.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreFitness.Controllers
{
    [Authorize(Roles = "admin")]
    public class SessionsController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
       
        public SessionsController(ISessionRepository sessionRepository ) 
        {
            _sessionRepository = sessionRepository;
        }


        // Get a list of all sessions
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _sessionRepository.GetSessions();
            return View(model);
        }

        public ViewResult Create()
        {
            return View();
        }

        // Add a session 
        [HttpPost]
        public IActionResult Create(Session model)
        {

            if (ModelState.IsValid)
            {
                Session newSession = new Session
                {
                    ClassName = model.ClassName,
                    InstructorName = model.InstructorName,
                    SessionTime = model.SessionTime
                };


                _sessionRepository.Add(newSession);

                return RedirectToAction("index");
            }

            return View();

        }

        // Fetch current session values
        [HttpGet]
        public ViewResult Edit (int id)
        {
            Session session = _sessionRepository.GetSession(id);

            Session sessionModel = new Session
            {
                Id = session.Id,
                ClassName = session.ClassName,
                InstructorName = session.InstructorName,
                SessionTime = session.SessionTime
                
            };

            return View(sessionModel);
        }

        // Edit a session 
        [HttpPost]
        public IActionResult Edit(Session model)
        {
            if(ModelState.IsValid)
            {
                Session session = _sessionRepository.GetSession(model.Id);
                session.ClassName = model.ClassName;
                session.InstructorName = model.InstructorName;
                session.SessionTime = model.SessionTime;


                _sessionRepository.Update(session);
                return RedirectToAction("index");
            }

            return View();

        }

        // Delete a session
        public IActionResult Delete(int id)
        {
            _sessionRepository.Delete(id);

            return RedirectToAction("index");

        }


    }
}
