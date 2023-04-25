import { Injectable } from '@angular/core';
import { Task } from './task';
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

  getTodoList(): Observable<Task[]> {
    const url = `${this.todoListUrl}/ShowTODOList`;
    return this.http.get<Task[]>(url);
  }
}
