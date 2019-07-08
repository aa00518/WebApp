import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MainTableDataSource } from './main-table-datasource';
import { SampleDataClient, WeatherForecast, ToDoClient, ToDo } from '../../services/generated';

@Component({
  selector: 'app-main-table',
  templateUrl: './main-table.component.html',
  styleUrls: ['./main-table.component.css'],
})
export class MainTableComponent implements OnInit {
  
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  public dataSource: MainTableDataSource;
  public wf: WeatherForecast[];
  public displayedColumns = ['id', 'name'];
  public displayedColumnsWeather = ['summary', 'temperatureF'];
  public displayedColumnsToDos = ['toDoItem', 'dateAdded'];
  public toDos: ToDo[];

  constructor(private sdc: SampleDataClient, private tdc: ToDoClient) {  }

  ngOnInit() {
    this.dataSource = new MainTableDataSource(this.paginator, this.sort);
    this.sdc.weatherForecasts().subscribe(r => {
      setTimeout(() => {
        this.wf = r;
      }, 1000);
    });
    this.tdc.get().subscribe(r => {
      setTimeout(() => {
        this.toDos = r;
      }, 1500);
    });
  }
}
