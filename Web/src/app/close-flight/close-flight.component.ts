import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-close-flight',
  templateUrl: './close-flight.component.html',
  styleUrls: ['./close-flight.component.css']
})
export class CloseFlightComponent implements OnInit {
  public form! :FormGroup//Formulario utilizado para capturar los datos requeridos
  constructor(private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.form= this.formBuilder.group({
      IdFlight: ['',[  ]],
      Status: ['',[  ]]
    });
  }
  //Funcion para capturar y enviar los datos introducidos en el formulario
  getData(){
    console.log(this.form.value);
    
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
