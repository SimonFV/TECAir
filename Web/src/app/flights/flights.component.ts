import { Container } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, ElementRef, OnInit, QueryList, Renderer2, ViewChild, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../services/api.service';
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
  flights=[{"departure":"",
            "arrival":"",
            "scales":[]}]
  constructor(private formBuilder: FormBuilder,
    private usrManagment: UserService,
    private service: ApiService) { 
  }
  
  ngOnInit(): void {
    this.flights.splice(0,1);
    this.usrManagment.trigger.subscribe(data => {
      
      this.usrInfo(data.tok, data.role);
    });
    this.form = this.formBuilder.group({
      Departure: ['', []],
      Arrival: ['', []]
    });
  }

  usrInfo(_token: string, _role: string) {

    this.usrRole = _role;
    this.usrToken = _token;

  }
  getData(flag: boolean) {
    if(flag){
      this.service.postRoute(this.form.value).subscribe(resp => {
        console.log(resp.body);
        if(resp.body.length==0){
          this.alert('No flights found','danger');
        }else{
          console.log(resp.body[0].departure);
          this.insertData(resp.body);
          this.show=!this.show;
        }
      })
    }else{
      this.flights.splice(0,this.flights.length);
      this.show=!this.show;
    }
    
    console.log(this.form.value);
  }
  insertData(data:Array<any>){
   for (let i in data) {
     this.flights.push({
       "departure": data[i].departure,
       "arrival": data[i].arrival,
       "scales":data[i].scale
     })
   }
    console.log(this.flights);
    
  }
  alert(message:string, type: string){
    const alertPlaceholder = document.getElementById('alertDiv')!
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message +
      '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }

}