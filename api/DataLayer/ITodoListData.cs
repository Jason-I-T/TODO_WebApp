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
        public TodoTask AddTask(string tname, string tdesc);
        public TodoTask DeleteTask(Guid tid);
        public TodoTask UpdateTask(Guid tid, bool tstatus);
    }
}