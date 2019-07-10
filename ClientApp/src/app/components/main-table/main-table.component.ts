import { Component, OnInit } from '@angular/core';
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
  public displayedColumnsToDos = ['toDoItem', 'dateAdded'];
  
  public wf: WeatherForecast[];
  public displayedColumnsWeather = ['summary', 'temperatureF'];

  constructor(private sdc: SampleDataClient, private tdc: ToDoClient) {  }

  ngOnInit() {
    this.tdc.get().subscribe(r => {
      this.toDos = r;
    });

    this.sdc.weatherForecasts().subscribe(r => {
      this.wf = r;
    });
    //this.dataSource = new MainTableDataSource(this.paginator, this.sort);
  }
}
