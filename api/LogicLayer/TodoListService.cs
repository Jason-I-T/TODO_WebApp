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

        public async Task<List<TodoTask>> GetTodoList() {
            return await this._iTodoListData.GetTodoList();
        }

        public async Task<TodoTask> AddTask(string tname, string tdesc) {
            return await this._iTodoListData.AddTask(tname, tdesc);
        }

        public async Task<TodoTask> DeleteTask(Guid tid) {
            return await this._iTodoListData.DeleteTask(tid);
        }

        public async Task<TodoTask> UpdateTaskComplete(Guid tid) {
            return await this._iTodoListData.UpdateTask(tid, true);
        }

        public async Task<TodoTask> UpdateTaskIncomplete(Guid tid) {
            return await this._iTodoListData.UpdateTask(tid, false);
        }
    }
}