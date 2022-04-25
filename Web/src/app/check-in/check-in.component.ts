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
      email: ['', []],
      idFlight: ['', []],
      seat: ['', []],
      status: ['checked', []]
    });
  }
  setFlightId(i:number){
    console.log(i);
    this.id=i;
    
  }
  
  getData(){
    
    this.idFlight?.setValue(Number(this.idFlight?.value));
    console.log(this.form.value);
    this.service.putCheckIn(this.form.value).subscribe(resp=>{
      console.log(resp);
      if(resp.status==200){
        this.alert('Checked!','success');
      }
    })
  }
  get idFlight(){
    return this.form.get('idFlight')
  }
  alert(message:string, type: string){
    const alertPlaceholder = document.getElementById('alertDiv')!
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message +
      '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }

}
