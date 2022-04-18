import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { UserService } from '../services/userManagment/user.service';

@Component({
  selector: 'app-init',
  templateUrl: './init.component.html',
  styleUrls: ['./init.component.css']
})
export class InitComponent implements OnInit {
  public form!: FormGroup;
  constructor(private formBuilder: FormBuilder,
    private service: ApiService,
    private router: Router,
    private usrManagment: UserService
    ) { 
    
  }
  public token: any;
  data:any=[];
  student:boolean=false;
  ngOnInit(): void {
    this.form= this.formBuilder.group({
      Role: ['',[]],
      FirstName: ['',[]],
      LastName1: ['',[]],
      LastName2: ['',[]],
      Ssn: ['',[]],
      University: ['',[]],
      SchoolId: ['',[]],
      PhoneNumber: ['',[]],
      Email: ['',[]],
      Password: ['',[]]
      
    });
  }
  getData(){
    
    this.service.postRegister(this.form.value).subscribe(resp=>{
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
        role:this.data
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

  get SchoolId(){
    return this.form.get('SchoolId') //as FormArray;
  }
  get University(){
    return this.form.get('University') 
  }
  addStudent(){
    this.student=true;
  }
  
  deleteStudent(){
    this.student=false;
  }
}

