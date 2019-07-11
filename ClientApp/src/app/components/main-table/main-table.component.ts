import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
//import { MatPaginator } from '@angular/material/paginator';
//import { MatSort } from '@angular/material/sort';
//import { MainTableDataSource } from './main-table-datasource';
import { SampleDataClient, WeatherForecast, ToDoClient, ToDo } from '../../services/generated';

@Component({
  selector: 'app-main-table',
  templateUrl: './main-table.component.html',
  styleUrls: ['./main-table.component.css'],
})
export class MainTableComponent implements OnInit {
  
  //@ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  //@ViewChild(MatSort, { static: true }) sort: MatSort;
  
  //public dataSource: MainTableDataSource;
  //public displayedColumns = ['id', 'name'];
  
  public toDos: ToDo[];
  public displayedColumnsToDos = ['id', 'toDoItem', 'dateAdded'];
  
  public wf: WeatherForecast[];
  public displayedColumnsWeather = ['summary', 'temperatureF'];

  constructor(private sdc: SampleDataClient, private tdc: ToDoClient, private sb: MatSnackBar) {  }

  ngOnInit() {
    this.tdc.get().subscribe(r => {
      this.toDos = r;
    });

    this.sdc.weatherForecasts().subscribe(r => {
      this.wf = r;
    });
    //this.dataSource = new MainTableDataSource(this.paginator, this.sort);
  }

  public deleteToDo(id: number): void {
    let toDo: ToDo = new ToDo();
    toDo.id = id;
    this.tdc.deleteToDo(toDo).subscribe(() => {
      this.tdc.get().subscribe(r => {
        this.toDos = r;
        this.sb.open("Item deleted.", "Deleted", { duration: 2000 });
      });
    });
  }
}
