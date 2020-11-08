using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UFTStest1.Data;
using UFTStest1.Models;

namespace UFTStest1.Controllers
{
    [Route("api/numbertotext")]
    [ApiController]
    public class NumberToTextsController : ControllerBase
    {
        private readonly INumberText _repository;
        /// <summary>
        /// Dependancy injection
        /// </summary>
        /// <param name="repository"></param>
        public NumberToTextsController (INumberText repository)
        {
            _repository = repository;
        }
        
        // Get api/numbertotext/{aNumber}
        [HttpGet("{aNumber}")]
        public ActionResult <NumberText> Get(string aNumber)
        {
            var returnText = _repository.GetTextFromANumber(aNumber);
            return Ok(returnText);
        }
    }
}
