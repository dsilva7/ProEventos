import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: any = [];
  public eventsFiltrados: any = [];

  widthImg: number = 100;
  marginImg: number = 2;
  showImage: boolean = true;
  private _filterList: string = '';

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.eventsFiltrados = this.filterList
      ? this.filtrarEvents(this.filterList)
      : this.events;
  }

  filtrarEvents(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.events.filter(
      (event: { tema: string; local: string }) =>
        event.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        event.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEvents();
  }

  hideImage() {
    this.showImage = !this.showImage;
  }

  public getEvents(): void {
    this.http.get('http://localhost:5001/api/events').subscribe(
      response => {this.events = response;
        this.eventsFiltrados = this.events;
      },
      (error) => console.log(error)
    );
  }
}
