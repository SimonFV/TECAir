import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  

  postRegister(user: JSON) :Observable<any> {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Authentication/register', user, { headers: header , observe:'response'});
  }
  postLogIn(user: JSON): Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Authentication/login', user, { headers: header, observe:'response'});
  }
  postAdd(flight: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Flights/add', flight, { headers: header, observe:'response'});
  }
  postRoute(route: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Flights/flightsByRoute', route, { headers: header, observe:'response'});
  }
}
