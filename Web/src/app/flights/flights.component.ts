import { Container } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, ElementRef, OnInit, QueryList, Renderer2, ViewChild, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { ComunicationService } from '../services/comunication/comunication.service';
import { UserService } from '../services/userManagment/user.service';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {
  public form!: FormGroup;
  public usr!: FormGroup;
  private usrToken: any;
  private usrRole: any;
  private usrEmail: any;
  show=false;
  reserve=false;
  flights=[{"departure":"",
            "arrival":"",
            "scales":[],
            "Plane":"",
            "Schedule": "",
            "ID":0
          }];
  constructor(private formBuilder: FormBuilder,
    private usrManagment: UserService,
    private service: ApiService,
    private comunication: ComunicationService,
    private router: Router
    ) { 
  }
  
  ngOnInit(): void {
    this.flights.splice(0,1);
    this.usrManagment.trigger.subscribe(data => {
      console.log(data);
      
      this.usrInfo(data.tok, data.role,data.email);
    });
    this.form = this.formBuilder.group({
      Departure: ['', []],
      Arrival: ['', []]
    });
    this.usr = this.formBuilder.group({
      email: ['', []],
      idFlight: ['', []],
      seat: ['', []],
      status: ['paid', []]
    });
  }

  usrInfo(_token: string, _role: string, _email:string) {

    this.usrRole = _role;
    this.usrToken = _token;
    this.usrEmail=_email;
    console.log(this.usrEmail);
    

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
      },err=>{
        console.log(err);
        
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
       "scales":data[i].scale,
       "Plane":data[i].model,
       "Schedule":data[i].schedule,
       "ID":data[i].id
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
  reserveFlight(flag:boolean){
    if(!flag){
      this.service.postReserveFlight(this.usr.value).subscribe(resp=>{
        if(resp.status==200){
          this.alert('Booked!','success');
        }else{

        }
      })
    }
    this.reserve=!this.reserve;
  }

}