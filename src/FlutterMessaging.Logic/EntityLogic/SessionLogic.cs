using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class SessionLogic(IBaseRepository<Session> sessionRepository) : BaseLogic<Session>(sessionRepository)
    {

    }
}
