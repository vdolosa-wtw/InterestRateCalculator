import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { CalculationSession } from '../../shared/calculation-session';
import { WebApiService } from '../../shared/web-api.service';

@Component({
  selector: 'app-calculation-session-details',
  templateUrl: './calculation-session-details.component.html',
  styleUrls: ['./calculation-session-details.component.css']
})
export class CalculationSessionDetailsComponent implements OnInit {

  private id: string;

  public calculationSession: CalculationSession = undefined;

  constructor(private route: ActivatedRoute,
                private webApi: WebApiService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');

    this.loadDetails();
  }

  loadDetails(): void {

    this.webApi.get<CalculationSession>(`InterestCalculator/GetById/${this.id}`).subscribe(result => {
      this.calculationSession = result;
    }, error => console.error(error));

  }
}
