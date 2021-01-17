import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

import ArrayStore from 'devextreme/data/array_store';

@Component({
  selector: 'app-all-srw',
  templateUrl: './all-srw.component.html',
  styleUrls: ['./all-srw.component.css']
})
export class AllSrwComponent implements OnInit{
  public SRWArrayStore: ArrayStore;
  public SRWs: SRW[];
  private BaseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   this.BaseUrl = baseUrl;
    }
  ngOnInit(): void {
    this.http.get<SRW[]>(this.BaseUrl + 'SRW').subscribe(result => {
      this.SRWs = result;
    }, error => console.error(error));
    this.SRWArrayStore = new ArrayStore({
      key: "Id",
      data:[{ id: 1, name: "John Doe" }]
    })
    }
}
interface SRW {
   IdSWR: Number,
   NumSRW: string,
   FullNameSRW: string,
   Type: string,
   B_DateTime: string,
   E_DateTime: string,
   NameDirection: string,
   ShortName: string,
   ExecutorName: string
}