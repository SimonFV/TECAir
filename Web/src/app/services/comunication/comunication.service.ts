import { EventEmitter, Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ComunicationService {
  @Output() sales: EventEmitter<any>=new EventEmitter();
  @Output() checkIn: EventEmitter<any>=new EventEmitter();
  constructor() { }
}
