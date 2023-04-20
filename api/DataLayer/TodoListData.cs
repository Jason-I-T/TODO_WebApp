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
        public List<TodoTask> GetTodoList() {
            if(File.Exists("TODOListDatabase.json")) { // This file is located in the API layer
                return JsonSerializer.Deserialize<List<TodoTask>>(File.ReadAllText("TODOListDatabase.json"))!;
            } else {
                return new List<TodoTask>();
            }
        }

        public TodoTask AddTask(string tname, string tdesc) {
            List<TodoTask> todoDB;
            if(File.Exists("TODOListDatabase.json")) {
                todoDB = JsonSerializer.Deserialize<List<TodoTask>>(File.ReadAllText("TODOListDatabase.json"))!;
            } else {
                todoDB = new List<TodoTask>();
            }

            TodoTask task = new TodoTask(Guid.NewGuid(), tname, tdesc, false);
            todoDB.Add(task);

            string serializedDb = JsonSerializer.Serialize(todoDB);
            File.WriteAllText("TODOListDatabase.json", serializedDb);

            return task;
        }

        public TodoTask DeleteTask(Guid tid) {
            if(!File.Exists("TODOListDatabase.json")) {
                return new TodoTask();
            }

            List<TodoTask> todoDB = JsonSerializer.Deserialize<List<TodoTask>>(File.ReadAllText("TODOListDatabase.json"))!;
            foreach(TodoTask task in todoDB) {
                if(task.taskId.Equals(tid)) {
                    todoDB.Remove(task);
                    string serializedDb = JsonSerializer.Serialize(todoDB);
                    File.WriteAllText("TODOListDatabase.json", serializedDb);
                    return task;
                }
            }
            
            return new TodoTask();
        }

        public TodoTask UpdateTask(Guid tid, bool tstatus) {
            if(!File.Exists("TodoListDatabase.json")) {
                return new TodoTask();
            }

            List<TodoTask> todoDB = JsonSerializer.Deserialize<List<TodoTask>>(File.ReadAllText("TODOListDatabase.json"))!;
            foreach(TodoTask task in todoDB) {
                if(task.taskId.Equals(tid)) {
                    task.taskStatus = tstatus;
                    string serializedDb = JsonSerializer.Serialize(todoDB);
                    File.WriteAllText("TODOListDatabase.json", serializedDb);
                    return task;
                }
            }

            return new TodoTask();
        }
    }
}