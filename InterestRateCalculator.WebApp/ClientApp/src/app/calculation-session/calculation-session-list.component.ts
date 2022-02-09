import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { CalculationSession } from '../shared/calculation-session';
import { WebApiService } from '../shared/web-api.service';

@Component({
  templateUrl: './calculation-session-list.component.html',
  styleUrls: ['./calculation-session-list.component.css']
})
export class CalculationSessionListComponent implements OnInit {

  public calculationSessionsList: CalculationSessionsList

  public pageIndex: number = 0;
  public itemCount: number = undefined;
  public pageSize: number = 10;
  public pageNumber: number = 0;

  constructor(private webApi: WebApiService)
  {    
    this.loadGrid();
  }

  ngOnInit() {
    
  }

  loadGrid(): void {
    let params = new HttpParams()
      .set('page', this.pageIndex.toString())
      .set('itemCount', this.pageSize.toString());

    this.webApi.get<CalculationSessionsList>('InterestCalculator', params).subscribe(result => {
      this.calculationSessionsList = result;
      this.itemCount = this.calculationSessionsList.count;
    }, error => console.error(error));
  } 

  public onPaginatorChange(event?: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;

    this.loadGrid();

    return event;
  }
}

interface CalculationSessionsList {
  count: number,
  sessions: CalculationSession[]
}
