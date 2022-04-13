import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  public form!: FormGroup;
  constructor(private formBuilder: FormBuilder) { 
    
  }
  ngOnInit(): void {
    this.form= this.formBuilder.group({
      user_Name: ['',[]],
      user_Pass: ['',[]]
    });
  }
  getData(){
    console.log(this.form.value);
  }

}
