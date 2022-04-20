import { Component, OnInit, Output } from '@angular/core';
import { UserService } from '../services/userManagment/user.service';

@Component({
  selector: 'app-airport',
  templateUrl: './airport.component.html',
  styleUrls: ['./airport.component.css']
})
export class AirportComponent implements OnInit {

  constructor(private usrManagment: UserService) { }
 
  private token:any;
  private role: string | undefined;
  ngOnInit(): void {
  }

}
