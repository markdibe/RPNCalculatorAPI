using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RPNCalculatorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ConcurrentStack<int> _stack;
        public CalculatorController()
        {
            _stack = new ConcurrentStack<int>();
        }

        [HttpPost]
        public void Push([FromBody]string input)
        {

        }


        
    }
}
