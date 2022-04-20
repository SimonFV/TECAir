import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/userManagment/user.service';

@Component({
  selector: 'app-nav-client',
  templateUrl: './nav-client.component.html',
  styleUrls: ['./nav-client.component.css']
})
export class NavClientComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
}
