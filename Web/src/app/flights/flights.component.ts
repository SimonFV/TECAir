import { Container } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, ElementRef, OnInit, QueryList, Renderer2, ViewChild, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from '../services/userManagment/user.service';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {
  public form!: FormGroup;
  private usrToken: any;
  private usrRole: any;
  show=false;
  constructor(private formBuilder: FormBuilder,
    private usrManagment: UserService) { 
  }
  
  ngOnInit(): void {
    this.usrManagment.trigger.subscribe(data => {
      console.log("RESP");
      
      this.usrInfo(data.tok, data.role);
    });
    this.form = this.formBuilder.group({
      from: ['', []],
      to: ['', []]
    });
  }

  usrInfo(_token: string, _role: string) {

    this.usrRole = _role;
    this.usrToken = _token;

  }
  getData() {
    this.show=!this.show;
    console.log(this.form.value);
  }
  backToSearch(){
    this.show=!this.show;
  }

}
