import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { map, Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  public form!: FormGroup;
  
  constructor(private formBuilder: FormBuilder,
    private service: ApiService,
    private router: Router) { 
    
  }
  data:any=[];
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
    console.log(this.data.token);
    console.log(this.data.success);
    console.log(this.data.errors);
    if(this.data.success=="false"){
      this.router.navigate(["/signIn"]);
    }
  }

}
