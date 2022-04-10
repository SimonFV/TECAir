import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignBaggageComponent } from './assign-baggage.component';

describe('AssignBaggageComponent', () => {
  let component: AssignBaggageComponent;
  let fixture: ComponentFixture<AssignBaggageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssignBaggageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignBaggageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
