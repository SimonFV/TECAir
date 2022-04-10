import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CloseFlightComponent } from './close-flight.component';

describe('CloseFlightComponent', () => {
  let component: CloseFlightComponent;
  let fixture: ComponentFixture<CloseFlightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CloseFlightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CloseFlightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
