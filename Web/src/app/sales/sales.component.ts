import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
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
  constructor(private service: ApiService) { }
  
  ngOnInit(): void {
    this.sales.splice(0,1);
    this.service.getDeal().subscribe(resp=>{
      console.log(resp.body);
      for (let i in resp.body) {
        if (resp.body[i].deals != 0) {
          this.loadDeals(resp.body[i]);
        }
      }
    })
  }
  loadDeals(_sales: any){
    console.log("LOAD");
    this.sales.push({
      "From": deals.departure,
      "To": deals.arrival,
      "scales":deals.scale,
      "idFlight": deals.id,
      "Discount": deals.deals
    })
    this.add=true;
    
  }

}
