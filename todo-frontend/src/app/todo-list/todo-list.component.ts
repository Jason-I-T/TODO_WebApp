import { Component, OnInit } from '@angular/core';
import { Task } from '../task';
import { TodoListService } from '../todo-list.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
  tasks: Task[] = [];

  constructor(private todoListService: TodoListService) {}
  ngOnInit(): void {
    this.showTodoList();
  }

  showTodoList(): void {
    this.todoListService.getTodoList()
    .subscribe(_ => this.tasks = _);
  }
}
