import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { CalculationSession, WebApiService } from '../shared/web-api.service';

@Component({
  selector: 'app-calculation-session',
  templateUrl: './calculation-session.component.html',
  styleUrls: ['./calculation-session.component.css']
})
export class CalculationSessionComponent implements OnInit {

  public calculationSessionsList: CalculationSessionsList

  public pageSize: number = 10;
  public pageNumber: number = 0;

  constructor(@Inject('BASE_URL') baseUrl: string,
    webApi: WebApiService)
  {
    webApi.get<CalculationSessionsList>('InterestCalculator').subscribe(result => {
      this.calculationSessionsList = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface CalculationSessionsList {
  count: number,
  sessions: CalculationSession[]
}
