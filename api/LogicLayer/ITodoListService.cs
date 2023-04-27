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
        public Task<TodoTask> DeleteTask(Guid tid);
        public Task <TodoTask> UpdateTaskComplete(Guid tid);
        public Task <TodoTask> UpdateTaskIncomplete(Guid tid);
    }
}