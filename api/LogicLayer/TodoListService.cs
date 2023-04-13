using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ModelLayer;
using DataLayer;

namespace LogicLayer
{
    public class TodoListService : ITodoListService
    {
        // Dependency Injection
        private readonly ITodoListData _iTodoListData;
        public TodoListService(ITodoListData iTodoListData) => this._iTodoListData = iTodoListData;

        public List<TodoTask> GetTodoList() {
            return this._iTodoListData.GetTodoList();
        }
    }
}