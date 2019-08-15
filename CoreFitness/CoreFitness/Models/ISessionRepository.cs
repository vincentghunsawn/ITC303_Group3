using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFitness.Models
{
    public interface ISessionRepository
    {

        Session GetSession(int id);
        IEnumerable<Session> GetSessions();
        Session Add(Session session);
        Session Update(Session sessionChanges);
        Session Delete(int id);
    }

}
