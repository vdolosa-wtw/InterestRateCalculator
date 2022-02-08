import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculationSessionComponent } from './calculation-session.component';

describe('CalculationSessionComponent', () => {
  let component: CalculationSessionComponent;
  let fixture: ComponentFixture<CalculationSessionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalculationSessionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalculationSessionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
