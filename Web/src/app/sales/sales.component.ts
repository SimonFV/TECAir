import { Component, OnInit } from '@angular/core';
import { ComunicationService } from '../services/comunication/comunication.service';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
  sales=[{"From":"",
  "To": "",
  "Discount": ""}];
  /*{"From": "SJO", "To": "CUN", "Discount": "32" },
  {"From": "SJO", "To": "NYC", "Discount": "5" },
  { "From": "CUN", "To": "NYC", "Discount": "15"}*/
  constructor(private salesService: ComunicationService) { }
  
  ngOnInit(): void {
    this.sales.splice(0,1);
    /*this.salesService.sales.subscribe(resp=>{
      console.log("CLI");
      loadPromos(resp)
    })*/
  }
  loadPromos(_sales: Array<any>){
    console.log("LOAD");
    /*
    this.sales=_sales;
    console.log(this.sales);*/
    
  }

}
