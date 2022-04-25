import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { ComunicationService } from '../services/comunication/comunication.service';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
  public usr!: FormGroup;//Formulario utilizado para capturar los datos requeridos
  reserve = false;// Flag utilizado por ngIf
  add = false;// Flag utilizado por ngIf
  sales = [{
    "From": "",
    "To": "",
    "scales": [],
    "idFlight": "",
    "Discount": ""
  }];//Lista utilizada para mostrar los datos en la vista
  
  constructor(
    private service: ApiService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.sales.splice(0, 1);
    this.service.getDeal().subscribe(resp => {
      console.log(resp.body);
      for (let i in resp.body) {
        if (resp.body[i].deals != 0) {
          this.loadDeals(resp.body[i]);
        }
      }
    })
    this.usr = this.formBuilder.group({
      email: ['', []],
      idFlight: ['', []],
      seat: ['', []],
      status: ['paid', []]
    });
  }

  //Funcion para cargar las promociones existentes
  loadDeals(deals: any) {
    console.log("LOAD");
    this.sales.push({
      "From": deals.departure,
      "To": deals.arrival,
      "scales": deals.scale,
      "idFlight": deals.id,
      "Discount": deals.deals
    })
    this.add = true;
  }
  //Funcion para realizar la reserva de un vuelo
  reserveFlight(flag: boolean) {
    
    if (this.reserve) {
      this.service.postReserveFlight(this.usr.value).subscribe(resp => {
        if (resp.status == 200) {
          this.alert('Booked!', 'success');
        } else {
        }
      }
      )
    }
    this.reserve = !this.reserve

  }
  //Funcion que introduce una alerta dentro de la vista
  alert(message: string, type: string) {
    const alertPlaceholder = document.getElementById('alertDiv')!
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message +
      '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }
}
