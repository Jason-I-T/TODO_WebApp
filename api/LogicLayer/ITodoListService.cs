using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ModelLayer;
using DataLayer;

namespace LogicLayer
{
    public interface ITodoListService
    {
        public Task<List<TodoTask>> GetTodoList();
        public Task<TodoTask> AddTask(string tname, string tdesc);
        public TodoTask DeleteTask(Guid tid);
        public TodoTask UpdateTaskComplete(Guid tid);
        public TodoTask UpdateTaskIncomplete(Guid tid);
    }
}