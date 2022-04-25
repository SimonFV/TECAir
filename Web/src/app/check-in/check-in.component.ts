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
  public form!: FormGroup;//Formulario utilizado para capturar los datos requeridos
  constructor(
    private formBuilder :FormBuilder,
    private comunication: ComunicationService,
    private service: ApiService
    ) { }
    id: any;
  ngOnInit(): void {
    this.form=this.formBuilder.group({
      email: ['', []],
      idFlight: ['', []],
      seat: ['', []],
      status: ['checked', []]
    });
  }
  //Funcion para capturar y enviar los datos introducidos en el formulario
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

  //Getter del atributo idFlight del formulario
  get idFlight(){
    return this.form.get('idFlight')
  }

  //Funcion que introduce una alerta dentro de la vista
  alert(message:string, type: string){
    const alertPlaceholder = document.getElementById('alertDiv')!
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message +
      '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }

}
