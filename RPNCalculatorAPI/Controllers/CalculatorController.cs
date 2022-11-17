using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPNCalculatorAPI.IServices;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RPNCalculatorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IOperationHandler _operationHander;

        public CalculatorController(IOperationHandler operationHandler)
        {
            _operationHander = operationHandler;
        }

        [HttpPost]
        public ConcurrentStack<int> Push([FromBody] string input)
        {
            var stack = _operationHander.Compute(input);
            return stack;
        }



    }
}
