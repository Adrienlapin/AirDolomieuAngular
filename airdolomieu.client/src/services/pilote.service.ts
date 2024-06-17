import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PiloteService {

  constructor(private http: HttpClient) { }

  getPilote(): Observable<any> {

    return this.http.get("https://localhost:7114/Pilote")
  }

}
