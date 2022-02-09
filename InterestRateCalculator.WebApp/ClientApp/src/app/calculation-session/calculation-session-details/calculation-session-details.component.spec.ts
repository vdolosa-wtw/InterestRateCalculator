import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculationSessionDetailsComponent } from './calculation-session-details.component';

describe('CalculationSessionDetailsComponent', () => {
  let component: CalculationSessionDetailsComponent;
  let fixture: ComponentFixture<CalculationSessionDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalculationSessionDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalculationSessionDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
