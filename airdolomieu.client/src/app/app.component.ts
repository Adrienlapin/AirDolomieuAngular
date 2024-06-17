import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { AvionService } from '../services/avion.service';
import { PiloteService } from '../services/pilote.service';
import { VolsService } from '../services/vols.service';
import { Pilote } from '../model/Pilote';
import { Avion } from '../model/Avion';
import { Vol } from '../model/Vol';
import { ColDef } from 'ag-grid-community'; // Column Definition Type Interface



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit
{
  public avions: Avion[] = [];
  public pilotes: Pilote[] = [];
  public rowData$: Vol[] = [];

  @ViewChild('selectedavion') selectedavion!: ElementRef;
  @ViewChild('selectedpilote') selectedpilote!: ElementRef;

  colDefs: ColDef[] = [
    { field: "numvol" },
    { field: "nompilote" },
    { field: "nomavion" },
    { field: "villedep" },
    { field: "villearr" },
    { field: "heuredep" },
    { field: "heurearr" }
  ];

  constructor(
    private http: HttpClient,
    private avionservice: AvionService,
    private piloteservice: PiloteService,
    private volsservices: VolsService) {
  }


  ngOnInit() {
    
    this.avionservice.getAvion().subscribe({
      next: (response) => {
        this.avions = response;
        console.log(this.avions[0].nomavion);
      }
  })

    this.piloteservice.getPilote().subscribe({
      next: (response) => {
        this.pilotes = response;
      }
    })

    this.volsservices.getAllVols().subscribe({
      next: (response) => {
        this.rowData$ = response;
        console.log(this.rowData$[0]);

          }
        })
  }

  CheckVols() {
    console.log("selectedpilote : " + this.selectedpilote.nativeElement.value)
    console.log("selectedavion : " + this.selectedavion.nativeElement.value)
    if (this.selectedavion.nativeElement.value == "--Select--") {
      this.volsservices.getVolsbypilote(this.selectedpilote.nativeElement.value).subscribe({
        next: (response) => {
          this.rowData$ = response;
        }
      })
    } else if (this.selectedpilote.nativeElement.value == "--Select--") {
      this.volsservices.getVolsbyavion(this.selectedavion.nativeElement.value).subscribe({
        next: (response) => {
          this.rowData$ = response;
        }
      })
    } else (
      this.volsservices.getVolsbypiloteEtavion(this.selectedpilote.nativeElement.value, this.selectedavion.nativeElement.value).subscribe({
        next: (response) => {
          this.rowData$ = response;
        }
      })
    )
  }              

  title = 'airdolomieu.client';
}
