using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPNCalculatorAPI.IServices;
using RPNCalculatorAPI.Models;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RPNCalculatorAPI.Controllers
{
    [Route("rpn/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IOperationHandler _operationHander;

        public CalculatorController(IOperationHandler operationHandler)
        {
            _operationHander = operationHandler;
        }

        [HttpPost]
        public void Push([FromBody] string input, int id)
        {
            _operationHander.Compute(input, id);
        }

        [HttpGet]
        public string[] GetOperands()
        {
            return new AllowedOperands().Operands;
        }

        [HttpDelete]
        public void DeleteStack([FromQuery] int id)
        {
            _operationHander.DeleteStack(id);
        }

        [HttpPost]
        public void CreateStack()
        {
            _operationHander.CreateNew();
        }

        [HttpGet]
        public ConcurrentStack<int> GetStack(int id)
        {
            return _operationHander.GetStack(id);
        }

        [HttpGet]
        public ConcurrentDictionary<int, ConcurrentStack<int>> GetAllStacks()
        {
            return _operationHander.GetDictionary();
        }




    }
}
