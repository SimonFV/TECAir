import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-init',
  templateUrl: './init.component.html',
  styleUrls: ['./init.component.css']
})
export class InitComponent implements OnInit {
  public form!: FormGroup;
  constructor(private formBuilder: FormBuilder,
    private service: ApiService,
    private router: Router) { 
    
  }
  data:any=[];
  student:boolean=false;
  ngOnInit(): void {
    this.form= this.formBuilder.group({
      //user_Role: ['',[]],
      UserName: ['',[]],
      LastName1: ['',[]],
      LastName2: ['',[]],
      Ssn: ['',[]],
      University: ['',[]],
      //SchoolId: this.formBuilder.array([]),
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
    console.log(this.data.token);
    console.log(this.data.success);
    console.log(this.data.errors);
    if(this.data.success=="false"){
      this.router.navigate([" "]);
    }
  }

  get SchoolId(){
    return this.form.get('SchoolId') as FormArray;
  }
  addStudent(){
    this.student=true;
    const SchoolId_FormGroup= this.formBuilder.group({
      SchoolId: ''
    });
    this.SchoolId.push(SchoolId_FormGroup);
  }
  
  deleteStudent(){
    this.student=false;
    this.SchoolId.clear();
  }
}

