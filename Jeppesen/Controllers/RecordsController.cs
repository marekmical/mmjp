using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jeppesen.Models;
using Jeppesen.Data;
using Jeppesen.Interfaces;
using System.Net;

namespace Jeppesen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsService _recordsService;
        private readonly IUserService _userService;

        public RecordsController(IRecordsService recordsService, IUserService userService)
        {
            _recordsService = recordsService;
            _userService = userService;
        }
        
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(Boolean), (int)HttpStatusCode.OK)]
        public IActionResult Create(string band, string title, long unitsSold, Genre genre)
        {
            var success = this._recordsService.Create(band, title, unitsSold, genre);

            return Ok(success);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(Record), (int)HttpStatusCode.OK)]
        public IActionResult Read(string band, string title)
        {
            var record = this._recordsService.Read(band, title);

            return Ok(record);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(Boolean), (int)HttpStatusCode.OK)]
        public IActionResult Update(string band, string title, long unitsSold)
        {
            var success = this._recordsService.Update(band, title, unitsSold);

            return Ok(success);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(Boolean), (int)HttpStatusCode.OK)]
        public IActionResult Delete(string band, string title)
        {
            var success = this._recordsService.Delete(band, title);

            return Ok(success);
        }
        
    }
}
