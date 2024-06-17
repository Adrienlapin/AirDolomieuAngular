import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AvionService {


  constructor(private http: HttpClient) {

  }

  getAvion() : Observable<any> {

    return this.http.get("https://localhost:7114/Avion")
  }

}
