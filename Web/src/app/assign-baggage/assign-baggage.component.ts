import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-assign-baggage',
  templateUrl: './assign-baggage.component.html',
  styleUrls: ['./assign-baggage.component.css']
})
export class AssignBaggageComponent implements OnInit {
  public form!: FormGroup; //Formulario utilizado para capturar los datos requeridos
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
  //Funcion para capturar y enviar los datos introducidos en el formulario
  getData(){
    console.log(this.form.value);
    this.service.postBaggage(this.form.value).subscribe(resp=>{
      console.log(resp);
      if(resp.status==200){
        this.alert('Registred','success');
      }
    })
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
