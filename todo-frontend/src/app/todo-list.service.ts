import { Injectable } from '@angular/core';
import { TodoTask } from './task';
import { Observable, Subject, tap } from 'rxjs';
import { HttpClient, HttpHeaders  } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

// TODO Add error handling, logger, etc...
export class TodoListService {

  constructor(private http: HttpClient) { }
  private todoListUrl = 'https://localhost:7059/api/TodoList';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  getTodoList(): Observable<TodoTask[]> {
    const url = `${this.todoListUrl}/ShowTODOList`;
    return this.http.get<TodoTask[]>(url);
  }

  addTask(task: TodoTask): Observable<TodoTask> {
    const url = `${this.todoListUrl}/AddTask`;
    const body = {taskName: task.taskName, taskDesc: task.taskDesc};
    console.log(body);
    return this.http.post<TodoTask>(url, body, this.httpOptions);
  }

  deleteTask(task: TodoTask): Observable<TodoTask> {
    const url = `${this.todoListUrl}/DeleteTask`;
    const body = { taskId: task.taskId };
    return this.http.delete<TodoTask>(url, {body: body});
  }

  updateTaskComplete(task: TodoTask): Observable<TodoTask> {
    const url = `${this.todoListUrl}/UpdateTaskComplete`;
    const body = { taskId: task.taskId };
    return this.http.put<TodoTask>(url, body, this.httpOptions);
  }

  updateTaskIncomplete(task: TodoTask): Observable<TodoTask> {
    const url = `${this.todoListUrl}/UpdateTaskIncomplete`;
    const body = { taskId: task.taskId };
    return this.http.put<TodoTask>(url, body, this.httpOptions);
  }
}
