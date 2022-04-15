import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }


  postRegister(user: JSON){
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    
    return this.http.post('http://localhost:5001/Authentication/register', user, { headers: header });
  }
  postLogIn(user: JSON){
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post('http://localhost:5001/Authentication/login', user, { headers: header });
  }
}
