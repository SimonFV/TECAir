import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { map, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { UserService } from '../services/userManagment/user.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  public form!: FormGroup;//Formulario utilizado para capturar los datos requeridos
  data:any=[];//Lista utilizada guardar los datos del usuario
  public token: any;//Tocken del usuario

  constructor(private formBuilder: FormBuilder,
    private service: ApiService,
    private router: Router,
    private usrManagment: UserService
    ) { 
    
  }
  
  ngOnInit(): void {
    this.form= this.formBuilder.group({
      Email: ['',[Validators.required, Validators.email]],
      Password: ['',[Validators.required, Validators.minLength(6)]]
    });
  }
  //Funcion para capturar y enviar los datos introducidos en el formulario
  getData(){
    this.service.postLogIn(this.form.value).subscribe(resp=>{
      console.log(resp.status);
      this.readResp(resp.body);
      
    }, err=>{
      for (let e of err.error.errors){
        this.alert(e,'danger')
        console.log(e);
      }
    })
    console.log(this.form.value);
    
  }

    //Funcion para capturar y enviar los datos introducidos en el formulario
  alert(message:string, type: string){
    const alertPlaceholder = document.getElementById('alertDiv')!
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message +
      '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }

  //Funcion para leer la respuesta del API
  readResp(response:any){
    this.data=<JSON>response;
    this.token=this.data.token
    
    this.usrManagment.trigger.emit({
      tok:this.data.token,
      role: this.data.role,
      email: this.form.value.Email
    });
    if(this.data.role=="Employee"){
      this.router.navigate(["/airport"]);
    }else{
      this.router.navigate(["/reservations"]);
    }
    
    
  }

}
