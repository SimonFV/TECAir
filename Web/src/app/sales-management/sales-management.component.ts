import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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
  "Discount": ""}];
  

  from="";
  to="";
  discount="";
  add=false;
  edit=false;
  constructor(private formBuilder: FormBuilder,
    private salesService: ComunicationService) { }

  ngOnInit(): void {
    this.salesService.sales.emit({
      data: this.sales
    });
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

  }
  addPromo(){
    this.add=true;
    
    this.sales.push(
      {
        "From":this.form.value.From,
        "To": this.form.value.To,
        "idFlight":Number(this.form.value.idFlight) ,
        "Discount": this.form.value.Discount
      }
    )
    console.log(this.sales);
    this.salesService.sales.emit({
      data: this.sales
    });
  }
  deletePromo(i: number){
    this.sales.splice(i,1);
    console.log("DELETE: "+this.sales);
    this.salesService.sales.emit(this.sales);
  }
  editPromo(i:number, flag:boolean){
    if(!flag){
      this.edit=!this.edit;
    }else{
      this.sales[i]=this.temp.value;
      this.edit=!this.edit;
    }
    console.log("EDIT: "+this.sales);
    this.salesService.sales.emit(this.sales);
    
  }

}
