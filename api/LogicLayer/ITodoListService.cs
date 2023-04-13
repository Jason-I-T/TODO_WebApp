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
        public List<TodoTask> GetTodoList();
    }
}