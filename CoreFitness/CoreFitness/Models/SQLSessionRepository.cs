using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public class SQLSessionRepository : ISessionRepository
    {


        private readonly AppDbContext context;
        public SQLSessionRepository(AppDbContext context)
        {

            this.context = context;
        }

        // Add New Session 
        public Session Add(Session session)
        {
            context.Timetable.Add(session);
            context.SaveChanges();
            return session; 
        }

        // Delete Existing Session
        public Session Delete(int id)
        {
            Session session = context.Timetable.Find(id);

            if(session != null)
            {
                context.Timetable.Remove(session);
                context.SaveChanges();
            }

            return session;
        }

        // Get a single Session
        public Session GetSession(int id)
        {
            return context.Timetable.Find(id);
        }

        // Get All Sessions 
        public IEnumerable<Session> GetSessions()
        {
            return context.Timetable;
        }

        // Update a Session 
        public Session Update(Session sessionChanges)
        {
            var session = context.Timetable.Attach(sessionChanges);
            session.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return sessionChanges;
        }
    }
}
