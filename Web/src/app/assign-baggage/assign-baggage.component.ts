import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';

@Component({
  selector: 'app-assign-baggage',
  templateUrl: './assign-baggage.component.html',
  styleUrls: ['./assign-baggage.component.css']
})
export class AssignBaggageComponent implements OnInit {
  public form!: FormGroup;
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form=this.formBuilder.group({
      user_ID: ['', []],
      color: ['', []],
      weight: ['', []]
    })
  }
  getData(){
    console.log(this.form.value);
  }

}
