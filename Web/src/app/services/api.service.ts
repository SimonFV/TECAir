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
  postAddFlight(flight: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Flights/addFlight', flight, { headers: header, observe:'response'});
  }
  postRoute(route: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Flights/flightsByRoute', route, { headers: header, observe:'response'});
  }
  postBook(book: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Reservations/addBook', book, { headers: header, observe:'response'});
  }
  postReserveFlight(user: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Reservations/ReserveFlight', user, { headers: header, observe:'response'});
  }
  postBaggage(bag: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Reservations/ReserveFlight', bag, { headers: header, observe:'response'});
  }
  
}
