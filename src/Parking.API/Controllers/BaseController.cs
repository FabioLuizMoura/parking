using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using Parking.API.Models;
using Parking.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.API.Controllers
{
    public class BaseController : Controller
    {
        public async new Task<IActionResult> Response<T>(Task<T> result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    return Ok(new ResponseModel<T>(true, await result));
                }
                catch (Exception ex) { }
            }
            if (notifications.Count() > 0)
                return BadRequest(new ResponseModel<IEnumerable<Notification>>(false, notifications));
            else
            {
                List<Notification> ret = new List<Notification> { new Notification("Interno", "Ocorreu um erro interno.") };
                return BadRequest(new ResponseModel<List<Notification>>(false, ret));
            }
        }
    }
}
