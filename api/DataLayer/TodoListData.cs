using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Importing necessary layers
using ModelLayer;

namespace DataLayer
{
    public class TodoListData : ITodoListData
    {
        // TODO Get TODO List...
        /*
            Deserialize JSON to List object, return the list.
            If no JSON to deserialize, return empty list.
        */
        public List<TodoTask> GetTodoList() {
            return null!;
        }
    }
}