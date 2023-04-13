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
        public List<TodoTask> GetTodoList();
    }
}