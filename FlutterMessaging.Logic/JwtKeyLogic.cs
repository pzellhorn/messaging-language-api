using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic
{ 
    public class JwtKeyLogic(IBaseRepository<JwtKey> jwtKeyRepository) : BaseLogic<JwtKey>(jwtKeyRepository)
    {

    }
}
