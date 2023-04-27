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
        private string jsonDb = "TODOListDatabase.json";
        public async Task<List<TodoTask>> GetTodoList() {
            if(File.Exists(jsonDb)) { // This file is located in the API layer
                using FileStream openStream = File.OpenRead(jsonDb);
                List<TodoTask>? todoTasks = await JsonSerializer.DeserializeAsync<List<TodoTask>>(openStream);
                return todoTasks!;
            } else {
                return new List<TodoTask>();
            }
        }

        public async Task<TodoTask> AddTask(string tname, string tdesc) {
            List<TodoTask>? todoDB;
            if(File.Exists(jsonDb)) {
                using FileStream openStream = File.OpenRead(jsonDb);
                todoDB = await JsonSerializer.DeserializeAsync<List<TodoTask>>(openStream);
            } else {
                todoDB = new List<TodoTask>();
            }

            TodoTask task = new TodoTask(Guid.NewGuid(), tname, tdesc, false);
            todoDB?.Add(task);

            using FileStream createStream = File.Create(jsonDb);
            await JsonSerializer.SerializeAsync(createStream, todoDB);
            await createStream.DisposeAsync();

            return task;
        }

        public async Task<TodoTask> DeleteTask(Guid tid) {
            if(!File.Exists(jsonDb)) {
                return new TodoTask();
            }

            using FileStream openStream = File.OpenRead(jsonDb);
            List<TodoTask>? todoDB = await JsonSerializer.DeserializeAsync<List<TodoTask>>(openStream);
            openStream.Close();
            foreach(TodoTask task in todoDB!) {
                if(task.taskId.Equals(tid)) {
                    todoDB.Remove(task);
                    using FileStream createStream = File.Create(jsonDb);
                    await JsonSerializer.SerializeAsync(createStream, todoDB);
                    await createStream.DisposeAsync();
                    return task;
                }
            }
            
            return new TodoTask();
        }

        public TodoTask UpdateTask(Guid tid, bool tstatus) {
            if(!File.Exists(jsonDb)) {
                return new TodoTask();
            }

            List<TodoTask> todoDB = JsonSerializer.Deserialize<List<TodoTask>>(File.ReadAllText(jsonDb))!;
            foreach(TodoTask task in todoDB) {
                if(task.taskId.Equals(tid)) {
                    task.taskStatus = tstatus;
                    string serializedDb = JsonSerializer.Serialize(todoDB);
                    File.WriteAllText(jsonDb, serializedDb);
                    return task;
                }
            }

            return new TodoTask();
        }
    }
}