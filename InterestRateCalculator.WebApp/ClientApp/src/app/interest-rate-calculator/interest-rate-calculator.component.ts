import { HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { CalculationResult, CalculationSession, WebApiService } from '../shared/web-api.service';

@Component({
  selector: 'app-interest-rate-calculator',
  templateUrl: './interest-rate-calculator.component.html',
  styleUrls: ['./interest-rate-calculator.component.css']
})
export class InterestRateCalculatorComponent implements OnInit {

  public amount: number = 1000;
  public years: number = 4;
  public calculationResults: CalculationResult[];
  public calculationSession: CalculationSession;

  public isSaving: boolean = false;

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

      this.isSaving = true;

      let data = {
        "value": this.amount,
        "years": this.years,
        "results": this.calculationResults
      };

      this.webApi.post<CalculationSession>('InterestCalculator', data).subscribe(result => {
        this.calculationSession = result;
        this.isSaving = false;
      }, error => {
        this.isSaving = false;
        console.error(error);
      });

    }

  }
}


