using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using EasyNetQ;
using FP.Spartakiade2017.PicFlow.Contracts.Messages;

namespace FP.Spartakiade2017.PicFlow.WebApp.Modules
{
    public class AuthenticationRepository
    {
        private readonly ConcurrentDictionary<Guid, AuthUser> userSessions = new ConcurrentDictionary<Guid, AuthUser>();

        public AuthenticationRepository()
        {
            // TODO: Subscribe für Authentication-Anfragen


            // Anfragen müssen als UserSession gespeichert werden

            // var authUser = new AuthUser();
            // userSessions.AddOrUpdate(Id, authUser, (guid, user) => authUser);

            // Subscribe für Authentication Rückmeldung 

            // Rückmeldungen als UserSession speichern

            //var authUser = new AuthUser
            //{
            //    Id
            //    User 
            //    IsValid =
            //};
            //userSessions.AddOrUpdate(response.Id, authUser, (guid, user) => authUser);

        }

        public Task SendAuthorizationRequest(Guid sessionId, string userName, string passwordBase64)
        {
            // TODO:  Anfragen zur Authorization senden

            return null;
        }

        public AuthUser GetAuthUserBySessionId(Guid sessionId)
        {
            if (!userSessions.ContainsKey(sessionId))
                return null;
            return userSessions[sessionId];
        }

        public void DeleteSession(Guid sessionId)
        {
            if (userSessions.ContainsKey(sessionId))
            {
                userSessions.Remove(sessionId);
            }
        }
    }
}
