import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
//---------------REGISTRO------------  

  //Post para registrar un usuario
  postRegister(user: JSON) :Observable<any> {
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Authentication/register', user, { headers: header , observe:'response'});
  }
//Post para ingresar un usuario
  postLogIn(user: JSON): Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Authentication/login', user, { headers: header, observe:'response'});
  }

  //---------------VUELOS------------  

  //Post para añadir un nuevo vuelo
  postAddFlight(flight: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Flights/addFlight', flight, { headers: header, observe:'response'});
  }

//Post para añadir una nueva ruta
  postRoute(route: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Flights/flightsByRoute', route, { headers: header, observe:'response'});
  }

//Put para añadir una oferta a un vuelo
  putDeal(flight: any){
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.put<JSON[]>('http://localhost:5001/Flights/updateDeal', flight, { headers: header, observe:'response'});
  }

  //Get para obtener las ofertas de los vuelos existentes
  getDeal():Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.get<JSON[]>('http://localhost:5001/Flights/flightsDeals', { headers: header, observe:'response'});
  }

  //---------------RESERVA------------  

  //Put para confirmar a un pasajero de un vuelo
  putCheckIn(book: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.put<JSON[]>('http://localhost:5001/Reservations/checkin', book, { headers: header, observe:'response'});
  }

  //Post para reservar un asiento de un vuelo
  postReserveFlight(user: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Reservations/ReserveFlight', user, { headers: header, observe:'response'});
  }
//Post para añadir una maleta a un vuelo y usuario
  postBaggage(bag: JSON):Observable<any>{
    let header = new HttpHeaders().set('Type-contet', 'aplication/json');
    return this.http.post<JSON[]>('http://localhost:5001/Reservations/addBaggage', bag, { headers: header, observe:'response'});
  }

  
  
}
