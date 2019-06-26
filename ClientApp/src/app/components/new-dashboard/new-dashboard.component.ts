import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-new-dashboard',
  templateUrl: './new-dashboard.component.html',
  styleUrls: ['./new-dashboard.component.css']
})
export class NewDashboardComponent implements OnInit {

  public balls: number = 0;
  public strikes: number = 0;
  public outs: number = 0;

  private readonly minBalls: number = 0;
  private readonly maxBalls: number = 4;
  private readonly minStrikes: number = 0;
  private readonly maxStrikes: number = 3;
  private readonly minOuts: number = 0;
  private readonly maxOuts: number = 3;

  constructor() { }

  ngOnInit() {
  }

  addBall() {
    this.balls++;
    if (this.balls > this.maxBalls) {
      this.balls = this.maxBalls;
    }
  }

  subtractBall() {
    this.balls--;
    if (this.balls < this.minBalls) {
      this.balls = this.minBalls;
    }
  }

  addStrike() {
    this.strikes++;
    if (this.strikes > this.maxStrikes) {
      this.strikes = this.maxStrikes;
    }
  }

  subtractStrike() {
    this.strikes--;
    if (this.strikes < this.minStrikes) {
      this.strikes = this.minStrikes;
    }
  }

  addOut() {
    this.outs++;
    if (this.outs > this.maxOuts) {
      this.outs = this.maxOuts;
    }
  }

  subtractOut() {
    this.outs--;
    if (this.outs < this.minOuts) {
      this.outs = this.minOuts;
    }
  }

  clearAtBat() {
    this.balls = 0;
    this.strikes = 0;
  }

  public clearInning(): void {
    this.balls = 0;
    this.strikes = 0;
    this.outs = 0;
  }

  expandClick() {
    //alert("You clicked expand.");
    console.log("Bye.");
  }

  removeClick() {
    //alert("You clicked remove.");
    console.log("Hi.");
  }
}
