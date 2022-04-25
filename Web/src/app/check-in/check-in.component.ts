import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { ComunicationService } from '../services/comunication/comunication.service';

@Component({
  selector: 'app-check-in',
  templateUrl: './check-in.component.html',
  styleUrls: ['./check-in.component.css']
})
export class CheckInComponent implements OnInit {
  public form!: FormGroup;
  constructor(
    private formBuilder :FormBuilder,
    private comunication: ComunicationService,
    private service: ApiService
    ) { }
    id: any;
  ngOnInit(): void {
    
    this.comunication.checkIn.subscribe(resp=>{
      this.setFlightId(resp.flightId);
    })
    this.form=this.formBuilder.group({
      Email: ['',[]],
      IdFlight: ['', []],
      Seat: ['',[]]
    })
  }
  setFlightId(i:number){
    console.log(i);
    this.id=i;
    
  }
  
  getData(){
    
    this.IdFlight?.setValue(Number(this.IdFlight?.value));
    console.log(this.form.value);
    this.service.postBook(this.form.value).subscribe(resp=>{
      console.log(resp);
      
    })
  }
  get IdFlight(){
    return this.form.get('IdFlight')
  }

}
