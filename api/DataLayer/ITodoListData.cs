using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Necessary Layers
using ModelLayer;

namespace DataLayer
{
    public interface ITodoListData
    {
        public Task<List<TodoTask>> GetTodoList();
        public Task<TodoTask> AddTask(string tname, string tdesc);
        public Task<TodoTask> DeleteTask(Guid tid);
        public Task<TodoTask> UpdateTask(Guid tid, bool tstatus);
    }
}