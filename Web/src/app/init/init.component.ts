import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-init',
  templateUrl: './init.component.html',
  styleUrls: ['./init.component.css']
})
export class InitComponent implements OnInit {
  public form!: FormGroup;
  constructor(private formBuilder: FormBuilder) { 
    
  }

  ngOnInit(): void {
    this.form= this.formBuilder.group({
      user_Role: ['',[]],
      user_Name: ['',[]],
      user_Last_Name: ['',[]],
      user_Scn_LastName: ['',[]],
      user_ID: ['',[]],
      user_Uni_ID: this.formBuilder.array([]),
      user_Phone: ['',[]],
      user_Email: ['',[]],
      user_Pass: ['',[]]
      
    });
  }
  getData(){
    console.log(this.form.value);
  }
  get user_Uni_ID(){
    return this.form.get('user_Uni_ID') as FormArray;
  }
  addStudent(){
    const uni_ID_FormGroup= this.formBuilder.group({
      user_Uni_ID: ''
    });
    this.user_Uni_ID.push(uni_ID_FormGroup);
  }
  
  deleteStudent(){
    this.user_Uni_ID.clear();

  }
}
