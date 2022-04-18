import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { map, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { UserService } from '../services/userManagment/user.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  public form!: FormGroup;
  
  constructor(private formBuilder: FormBuilder,
    private service: ApiService,
    private router: Router,
    private usrManagment: UserService
    ) { 
    
  }
  data:any=[];
  public token: any;
  ngOnInit(): void {
    this.form= this.formBuilder.group({
      Email: ['',[]],
      Password: ['',[]]
    });
  }
  getData(){
    this.service.postLogIn(this.form.value).subscribe(resp=>{
      console.log(resp.status);
      
      if(resp.status!=200){
        console.error("ERROR");
        
      }else{
        this.readResp(resp.body);
      }
      
      
      
    })
    console.log(this.form.value);
    
  }
  readResp(response:any){
    this.data=<JSON>response;
    this.token=this.data.token
    
    if(this.data.role=="Employee"){
      this.usrManagment.trigger.emit({
        tok:this.data.token,
        role: this.data.role
      });
      this.router.navigate(["/airport"]);
    }else{
      this.usrManagment.trigger.emit({
        tok:this.data.token,
        role: this.data.role
      });
      this.router.navigate(["/reservations"]);
    }
  }

}
