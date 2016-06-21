﻿using Getticket.Web.API.Attributes;
using Getticket.Web.API.Models;
using Getticket.Web.API.Services;
using Getticket.Web.DAL.Entities;
using Getticket.Web.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Getticket.Web.API.Controllers
{
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        private UserRegistrationService UserRegServ;
        private CredentailsService Credentails;

        public UserController()
        {
            this.UserRegServ = new UserRegistrationService();
            this.Credentails = new CredentailsService();
        }

        //TODO сделать авторизацию
        [HttpPost]
        [Route("")]
       
        public IHttpActionResult GetAll([FromBody] QueryModel<string> model)
        {
            if (!Credentails.IsAuthorized(model.Credentails, AccessRoleType.Admin)) return Unauthorized();


            return Ok<IList<User>>(UserRegServ.GetAll()); 
        }

        [HttpPost]
        [Route("{id}")]
        public IHttpActionResult GetOne(int id, [FromBody] QueryModel<string> model)
        {
            if (!Credentails.IsAuthorized(model.Credentails, AccessRoleType.Admin)) return Unauthorized();


            User user = UserRegServ.GetById(id);
            if (user == null)
            {
                return Json<string>("User with id = " + id + " not found");
            }
            return Ok<User>(user);
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register([FromBody] QueryModel<RegisterUserModel> model)
        {
            if (!Credentails.IsAuthorized(model.Credentails, AccessRoleType.Admin)) return Unauthorized();


            User user = UserRegServ.CreateActiveUser(model.Payload);
            if (user == null)
            {
                return Json<string>("user allready exists");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update([FromBody] QueryModel<UpdateUserModel> model)
        {
            if (!Credentails.IsAuthorized(model.Credentails, AccessRoleType.Admin)) return Unauthorized();


            User user = UserRegServ.UpdateUser(model.Payload);
            if (user == null)
            {
                return Json<string>("User id not found");
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult MarkDeleted(int id, [FromBody] QueryModel<string> model)
        {
            if (!Credentails.IsAuthorized(model.Credentails, AccessRoleType.Admin)) return Unauthorized();



            if (!UserRegServ.MarkDelete(1))
            {
                return Json<string>("User with id = " + id + " not found");
            }

            return Json<string>("User with id = " + id + " deleted");
        }
    }
}
