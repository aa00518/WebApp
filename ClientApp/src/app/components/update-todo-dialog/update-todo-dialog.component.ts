import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToDo } from './../../services/generated';

@Component({
  selector: 'app-update-todo-dialog',
  templateUrl: './update-todo-dialog.component.html',
  styleUrls: ['./update-todo-dialog.component.css']
})
export class UpdateTodoDialogComponent implements OnInit {

  public addToDoForm = new FormGroup({
    toDoControl: new FormControl('', [Validators.required])//,
    //dateAddedControl: new FormControl('', [Validators.required])
  });

  constructor(public dialogRef: MatDialogRef<UpdateTodoDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: ToDo) { }

  ngOnInit() {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(event) {
    event.currentTarget.reset();
  }

  public clearToDo(): void {

  }
}
