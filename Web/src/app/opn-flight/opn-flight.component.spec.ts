import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpnFlightComponent } from './opn-flight.component';

describe('OpnFlightComponent', () => {
  let component: OpnFlightComponent;
  let fixture: ComponentFixture<OpnFlightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpnFlightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OpnFlightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
