import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToDo } from './../../services/generated';

@Component({
  selector: 'app-delete-todo-dialog',
  templateUrl: './delete-todo-dialog.component.html',
  styleUrls: ['./delete-todo-dialog.component.css']
})
export class DeleteTodoDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DeleteTodoDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: ToDo) {}

  ngOnInit() {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
