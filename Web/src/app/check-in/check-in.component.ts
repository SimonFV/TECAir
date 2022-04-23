import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';

@Component({
  selector: 'app-check-in',
  templateUrl: './check-in.component.html',
  styleUrls: ['./check-in.component.css']
})
export class CheckInComponent implements OnInit {
  public form!: FormGroup;
  constructor(private formBuilder :FormBuilder) { }

  ngOnInit(): void {
    this.form=this.formBuilder.group({
      Ssn: ['',[]],
      IdFlight: ['', []],
      Seat: ['',[]]
    })
  }

  getData(){
    console.log(this.form.value);
  }

}
