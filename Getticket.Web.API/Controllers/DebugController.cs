using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Repository;

namespace Getticket.Web.API.Controllers
{
    public class DebugController : ApiController
    {
      private UserRepository userRep = new UserRepository();

    }
}
