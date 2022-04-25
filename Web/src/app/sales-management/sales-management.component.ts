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
  public form!: FormGroup;
  public temp!: FormGroup;
  sales=[{"From":"",
  "To": "",
  "idFlight":0 ,
  "scales":[],
  "Discount": ""}];
  

  from="";
  to="";
  discount="";
  add=false;
  edit=false;
  constructor(private formBuilder: FormBuilder,
    private service: ApiService
    ) { }

  ngOnInit(): void {
    this.deletePromo(0);
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
  deletePromo(i: number){
    this.sales.splice(i,1);
    console.log("DELETE: "+this.sales);
  }
  editPromo(i:number, flag:boolean){
    if(!flag){
      this.edit=!this.edit;
    }else{
      this.sales[i]=this.temp.value;
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
