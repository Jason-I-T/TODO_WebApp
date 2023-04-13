using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

// Importing necessary layers
using ModelLayer;

namespace DataLayer
{
    public class TodoListData : ITodoListData
    {
        
        /* Deserialize JSON (database) to List object, return the list.
        If no JSON (database) to deserialize, return empty list.*/
        public List<TodoTask> GetTodoList() {
            if(File.Exists("TODOListDatabase.json")) { // This file is located in the API layer
                return JsonSerializer.Deserialize<List<TodoTask>>(File.ReadAllText("TODOListDatabase.json"))!;
            } else {
                return new List<TodoTask>();
            }
        }
    }
}