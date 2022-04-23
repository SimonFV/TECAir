import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-opn-flight',
  templateUrl: './opn-flight.component.html',
  styleUrls: ['./opn-flight.component.css']
})
export class OpnFlightComponent implements OnInit {
  public form!: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private service: ApiService) { }

  ngOnInit(): void {
    this.form= this.formBuilder.group({
      PlaneId: ['',[  ]],
      Departure: ['',[]],
      Scale: this.formBuilder.array([]),
      Arrival: ['',[]]
    });
  }

  get Scale(){
    return this.form.get('Scale') as FormArray; 
  }


  getData(){
    console.log(this.Scale.value[0].Scale);
    for(let stop in this.Scale.value){
      this.Scale.value[stop]=this.Scale.value[stop].Scale;
    }
    console.log(this.Scale.value[0].Scale);
    
    this.service.postAdd(this.form.value).subscribe(resp=>{
      console.log(resp);
    })
    console.log(this.form.value);
    
  }
  addStop(){
    const stopsFormGroup= this.formBuilder.group({
      Scale: ''
    });
    this.Scale.push(stopsFormGroup);
  }
  deleteStop(i: number){
    this.Scale.removeAt(i);
  }

}
