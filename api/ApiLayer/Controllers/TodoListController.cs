using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using LogicLayer;
using ModelLayer;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        // Dependency Injection
        private readonly ITodoListService _iTodoListService;
        public TodoListController(ITodoListService iTodoListService) => this._iTodoListService = iTodoListService;

        // TODO Change to async (?)
        [HttpGet("ShowTODOList")]
        public async Task<ActionResult<List<TodoTask>>> ShowTODOList() {
            List<TodoTask> TODOList = await _iTodoListService.GetTodoList();
            return StatusCode(200, TODOList);
        }

        [HttpPost("AddTask")]
        public ActionResult<TodoTask> AddTask(TodoTask t) {
            TodoTask task = new TodoTask();
            task = _iTodoListService.AddTask(t.taskName!, t.taskDesc!);
            return StatusCode(201, task);
        }

        [HttpDelete("DeleteTask")]
        public ActionResult<TodoTask> DeleteTask(TodoTask t) {
            TodoTask task = new TodoTask();
            task = _iTodoListService.DeleteTask(t.taskId);
            return StatusCode(200, task);
        }

        [HttpPut("UpdateTaskComplete")]
        public ActionResult<TodoTask> UpdateTaskComplete(TodoTask t) {
            TodoTask task = new TodoTask();
            task = _iTodoListService.UpdateTaskComplete(t.taskId);
            return StatusCode(200, task);
        }

        [HttpPut("UpdateTaskIncomplete")]
        public ActionResult<TodoTask> UpdateTaskIncomplete(TodoTask t) {
            TodoTask task = new TodoTask();
            task = _iTodoListService.UpdateTaskIncomplete(t.taskId);
            return StatusCode(200, task);
        }
    }
}