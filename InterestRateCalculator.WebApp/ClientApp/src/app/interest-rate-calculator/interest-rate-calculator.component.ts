import { HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { WebApiService } from '../shared/web-api.service';

@Component({
  selector: 'app-interest-rate-calculator',
  templateUrl: './interest-rate-calculator.component.html',
  styleUrls: ['./interest-rate-calculator.component.css']
})
export class InterestRateCalculatorComponent implements OnInit {

  public amount: number = 1000;
  public years: number = 4;
  public calculationResults: CalculationResult[];

  constructor(private webApi: WebApiService, @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
  }

  onCalculate(): void {

    let params = new HttpParams()
          .set('value', this.amount.toString())
          .set('years', this.years.toString());

    this.webApi.get<CalculationResult[]>('CalculateInterest', params).subscribe(result => {
      this.calculationResults = result;
    }, error => console.error(error));    
  }

  onSaveResults(): void {

    if (confirm("Are you sure you want to save this computation results?")) {
      console.log("saved!");
    } else {
      console.log("not saved!");
    }
  }
}

interface CalculationResult {
  year: number,
  currentValue: number,
  interestRate: number,
  futureValue: number
}
