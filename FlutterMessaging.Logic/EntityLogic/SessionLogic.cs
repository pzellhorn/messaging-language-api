using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class SessionLogic(IBaseRepository<Session> sessionRepository) : BaseLogic<Session>(sessionRepository)
    {

    }
}
