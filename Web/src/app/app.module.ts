import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { InitComponent } from './init/init.component';
import { ReservationsComponent } from './reservations/reservations.component';
import { AirportComponent } from './airport/airport.component';
import { FlightsComponent } from './flights/flights.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { NavClientComponent } from './nav-client/nav-client.component';
import { NavAdminComponent } from './nav-admin/nav-admin.component';
import { SalesComponent } from './sales/sales.component';
import { OpnFlightComponent } from './opn-flight/opn-flight.component';
import { CloseFlightComponent } from './close-flight/close-flight.component';
import { CheckInComponent } from './check-in/check-in.component';
import { AssignBaggageComponent } from './assign-baggage/assign-baggage.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    InitComponent,
    ReservationsComponent,
    AirportComponent,
    FlightsComponent,
    SignInComponent,
    NavClientComponent,
    NavAdminComponent,
    SalesComponent,
    OpnFlightComponent,
    CloseFlightComponent,
    CheckInComponent,
    AssignBaggageComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path: 'flights', component:FlightsComponent},
      {path: 'airport', component: AirportComponent},
      {path: '', component: InitComponent},
      {path: 'reservations', component: ReservationsComponent},
      {path: 'sigIn',component:SignInComponent},
      {path: 'sales',component: SalesComponent},
      {path: 'checkIn', component: CheckInComponent},
      {path: 'assignBaggage',component: AssignBaggageComponent},
      {path: 'opnFlight',component: OpnFlightComponent},
      {path: 'closeFlight', component: CloseFlightComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
