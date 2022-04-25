import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-assign-baggage',
  templateUrl: './assign-baggage.component.html',
  styleUrls: ['./assign-baggage.component.css']
})
export class AssignBaggageComponent implements OnInit {
  public form!: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private service: ApiService
    ) { }

  ngOnInit(): void {
    this.form=this.formBuilder.group({
      email: ['', []],
      weight: ['', []],
      color: ['', []]
    })
  }
  getData(){
    console.log(this.form.value);
    this.service.postBaggage(this.form.value).subscribe(resp=>{
      console.log(resp);
      
    })
  }

}
