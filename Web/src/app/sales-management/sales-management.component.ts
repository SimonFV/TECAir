import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { ComunicationService } from '../services/comunication/comunication.service';

@Component({
  selector: 'app-sales-management',
  templateUrl: './sales-management.component.html',
  styleUrls: ['./sales-management.component.css']
})
export class SalesManagementComponent implements OnInit {
  public form!: FormGroup;//Formulario utilizado para capturar los datos requeridos
  public temp!: FormGroup;//Formulario utilizado para capturar los datos requeridos
  sales=[{"From":"",
  "To": "",
  "idFlight":0 ,
  "scales":[],
  "Discount": ""}];// Lista utilizada para mostrar los datos en la vista
  
  add=false;//Flag utilizado por ngIf
  edit=false;//Flag utilizado por ngIf
  constructor(private formBuilder: FormBuilder,
    private service: ApiService
    ) { }

  ngOnInit(): void {
    this.sales.splice(0,1);
    this.form=this.formBuilder.group({
      From:['',[]],
      To:['',[]],
      idFlight:['',[]],
      Discount:['',[]],
    });
    this.temp=this.formBuilder.group({
      From:['',[]],
      To:['',[]],
      idFlight:['',[]],
      Discount:['',[]],
    });

    this.service.getDeal().subscribe(resp=>{
      console.log(resp.body);
      for (let i in resp.body) {
        if (resp.body[i].deals != 0) {
          this.loadDeals(resp.body[i]);
        }
      }
    })
  }
//Funcion utilizada para cargar las promociones existentes en la vista
  loadDeals(deals:any){
    this.sales.push({
      "From": deals.departure,
      "To": deals.arrival,
      "scales":deals.scale,
      "idFlight": deals.id,
      "Discount": deals.deals
    })
    this.add=true;
    
  }

//Funcion utilizada para añadir y enviar las promociones 
  addPromo(){
    this.sales.push(
      {
        "From":this.form.value.From,
        "To": this.form.value.To,
        "scales":[],
        "idFlight":Number(this.form.value.idFlight) ,
        "Discount": this.form.value.Discount
      }
    )
    this.service.putDeal({
      "idFlight": Number(this.form.value.idFlight),
      "deal":Number(this.form.value.Discount)
    }).subscribe(resp=>{
      console.log(resp);
      
    })
  }
  //Funcion utilizada para eliminar y enviar las promociones 
  deletePromo(i: number){
    
    console.log("DELETE: "+this.sales);
    this.service.putDeal({
      "idFlight":this.sales[i].idFlight,
      "deal":0
    }).subscribe(resp=>{
      console.log(resp);
      
    })
    this.sales.splice(i,1);
  }
  //Funcion utilizada para editar y enviar las promociones 
  editPromo(i:number, flag:boolean){
    if(!flag){
      this.edit=!this.edit;
    }else{
      this.sales[i]=this.form.value;
      this.edit=!this.edit;
    }
    this.service.putDeal({
      "idFlight": Number(this.form.value.idFlight),
      "deal":Number(this.form.value.Discount)
    }).subscribe(resp=>{
      console.log(resp);
    })
    
  }

}
