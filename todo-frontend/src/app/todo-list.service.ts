import { Injectable } from '@angular/core';
import { TodoTask } from './task';
import { Observable } from 'rxjs';
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
    console.log(task);
    return this.http.post<TodoTask>(url, task, this.httpOptions);
  } 
}
