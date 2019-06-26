import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MainTableDataSource } from './main-table-datasource';
import { SampleDataClient, WeatherForecast, DownloadLogClient, DownloadLog } from '../../services/generated';

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
  public downloadLog: DownloadLog[];
  public displayedColumns = ['id', 'name'];
  public displayedColumnsWeather = ['summary', 'temperatureF'];
  public displayedColumnsDL = ['tableName', 'comparisonType', 'startDT', 'resultCode', 'resultText', 'detailText'];

  constructor(private sdc: SampleDataClient, private dlc: DownloadLogClient) {  }

  ngOnInit() {
    this.dataSource = new MainTableDataSource(this.paginator, this.sort);
    this.sdc.weatherForecasts().subscribe(r => {
      this.wf = r;
      //console.log(this.wf);
    });
    this.dlc.getFRRep().subscribe(r => {
      this.downloadLog = r;
    });
  }
}
