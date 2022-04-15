import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  public form!: FormGroup;
  constructor(private formBuilder: FormBuilder,
    private service: ApiService) { 
    
  }
  ngOnInit(): void {
    this.form= this.formBuilder.group({
      Email: ['',[]],
      Password: ['',[]]
    });
  }
  getData(){
    this.service.postLogIn(this.form.value).subscribe(resp=>{
      console.log(resp);
      
    })
    console.log(this.form.value);
  }

}
