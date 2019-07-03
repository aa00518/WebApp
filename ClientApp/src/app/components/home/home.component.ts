import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  btnClick() {
    console.log("Yo.");
  }

  private wootClick(): void {
    console.log("Woot! was clicked!");
  }
}
