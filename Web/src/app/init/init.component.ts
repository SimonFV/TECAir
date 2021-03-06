import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { UserService } from '../services/userManagment/user.service';

@Component({
  selector: 'app-init',
  templateUrl: './init.component.html',
  styleUrls: ['./init.component.css']
})
export class InitComponent implements OnInit {
  public form!: FormGroup;//Formulario utilizado para capturar los datos requeridos
  constructor(private formBuilder: FormBuilder,
    private service: ApiService,
    private router: Router,
    private usrManagment: UserService
    ) { 
    
  }
  
  public token: any;//Tocken del usuario actual
  data:any=[];//Lista utilizada para enviar los datos del usuario
  student:boolean=false;//Flag para saber si el usuario actual es un estudiante
  ngOnInit(): void {
    this.form= this.formBuilder.group({
      FirstName: ['',[Validators.required]],
      LastName1: ['',[Validators.required]],
      LastName2: ['',[Validators.required]],
      Email: ['',[Validators.required, Validators.email]],
      Password: ['',[Validators.required, Validators.minLength(6)]],
      Ssn: ['',[Validators.required]],
      PhoneNumber: ['',[Validators.required]],
      SchoolId: ['',[]],
      University: ['',[]],
      Role: ['',[Validators.required]]
      
    });
    
  }
  //Funcion para capturar y enviar los datos introducidos en el formulario
  getData(){
    if(this.form.value.Role!="Student"){
      this.form.value.SchoolId=null;
      this.form.value.University=null
    }
    this.service.postRegister(this.form.value).subscribe(resp=>{
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
  
//Funcion que introduce una alerta dentro de la vista
  alert(message:string, type: string){
    const alertPlaceholder = document.getElementById('alertDiv')!
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message +
      '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'
    alertPlaceholder.appendChild(wrapper)
  }

  //Funcion utilizada para leer la respuesta del API
  readResp(response:any){
    this.data=<JSON>response;
    this.token=this.data.token
    this.usrManagment.trigger.emit({
      tok:this.data.token,
      role:this.data.role,
      email:this.form.value.Email
    });
    if(this.data.role=="Employee"){
      this.router.navigate(["/airport"]);
    }else{
      this.router.navigate(["/reservations"]);
    }
    
  }

//Funciones para a??adir y eliminar los campos del formulario dedicados a estudiantes
  addStudent(){
    this.student=true;
  }
  deleteStudent(){
    this.student=false;
  }
//Gatters de los atributos del formulario
  get SchoolId(){
    return this.form.get('SchoolId') ;
  }
  get University(){
    return this.form.get('University') 
  }
  get Role(){
    return this.form.get('Role') 
  }
}

