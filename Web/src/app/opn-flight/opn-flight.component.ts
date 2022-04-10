import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';

@Component({
  selector: 'app-opn-flight',
  templateUrl: './opn-flight.component.html',
  styleUrls: ['./opn-flight.component.css']
})
export class OpnFlightComponent implements OnInit {
  public form!: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form= this.formBuilder.group({
      airplane_ID: ['',[  ]],
      from: ['',[]],
      stops: this.formBuilder.array([]),
      to: ['',[]]
    });
  }

  get stops(){
    return this.form.get('stops') as FormArray; 
  }


  getData(){
    console.log(this.form.value);
    
  }
  addStop(){
    const stopsFormGroup= this.formBuilder.group({
      stop: ''
    });
    this.stops.push(stopsFormGroup);
  }
  deleteStop(i: number){
    this.stops.removeAt(i);
  }

}
