import { Component, OnInit } from '@angular/core';
import { TodoTask } from '../task';
import { TodoListService } from '../todo-list.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
  tasks: TodoTask[] = [];

  constructor(private todoListService: TodoListService) {}
  ngOnInit(): void {
    this.showTodoList();
  }

  showTodoList(): void {
    this.todoListService.getTodoList()
    .subscribe(_ => this.tasks = _);
  }

  add(tname: string, tdesc: string): void {
    tname = tname.trim();
    tdesc = tdesc.trim();
    if(!tname || !tdesc) { return; }
    var newTask: TodoTask = {taskId: '0', taskName: tname, taskDesc: tdesc, taskStatus: false};
    this.todoListService.addTask(newTask)
    .subscribe(_ => {
      this.tasks.push(_);
    });
  }

  delete(task: TodoTask): void {
    this.tasks = this.tasks.filter(_ => _ !== task);
    this.todoListService.deleteTask(task).subscribe();
  }
}
