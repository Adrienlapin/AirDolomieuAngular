import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VolsService {

  constructor(private http: HttpClient) { }

  getAllVols(): Observable<any>{

    return this.http.get("https://localhost:7114/Vols")
  }

  getVolsbypilote(id : number): Observable<any> {

    return this.http.get("https://localhost:7114/VolbyPilote:" + id.toString())
  }

  getVolsbypiloteEtavion(idpilote: number, idavion : number): Observable<any> {

    return this.http.get("https://localhost:7114/VolbyPiloteEtAvion:" + idpilote.toString() +":" +idavion.toString())
  }

  getVolsbyavion(idavion: number): Observable<any> {

    return this.http.get("https://localhost:7114/VolbyAvion:" + idavion.toString())
  }


}
