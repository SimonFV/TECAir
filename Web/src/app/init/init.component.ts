import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-init',
  templateUrl: './init.component.html',
  styleUrls: ['./init.component.css']
})
export class InitComponent implements OnInit {
  public form!: FormGroup;
  constructor(private formBuilder: FormBuilder,
    private service: ApiService) { 
    
  }

  ngOnInit(): void {
    this.form= this.formBuilder.group({
      //user_Role: ['',[]],
      userName: ['',[]],
      lastName1: ['',[]],
      lastName2: ['',[]],
      ssn: ['',[]],
      university: ['',[]],
      //university: this.formBuilder.array([]),
      //user_Phone: ['',[]],
      email: ['',[]],
      password: ['',[]]
      
    });
  }
  getData(){
    this.service.postRegister(this.form.value).subscribe(resp=>{
      console.log(resp);
      
    })
    //console.log(this.form.value);
  }
  get university(){
    return this.form.get('university') as FormArray;
  }
  addStudent(){
    const uni_ID_FormGroup= this.formBuilder.group({
      university: ''
    });
    this.university.push(uni_ID_FormGroup);
  }
  
  deleteStudent(){
    this.university.clear();

  }
}
