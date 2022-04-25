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
      Gate: ['',[  ]],
      Departure: ['',[]],
      Scale: this.formBuilder.array([]),
      Arrival: ['',[]]
    });
  }

  get Scale(){
    return this.form.get('Scale') as FormArray; 
  }


  getData(){
    for(let stop in this.Scale.value){
      this.Scale.value[stop]=this.Scale.value[stop].Scale;
    }
    
    this.service.postAddFlight(this.form.value).subscribe(resp=>{
      console.log(resp);
      if(resp.status==200){
        this.alert('Flight Registered!','success');
      }else{
        
        
        this.alert(resp.errors, 'danger');
      }
    },err=>{
      console.log(err.error.errors);
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
  alert(message:string, type: string){
    const alertPlaceholder = document.getElementById('alertDiv')!
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message +
      '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }

}
