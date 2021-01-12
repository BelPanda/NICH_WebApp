import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

import ArrayStore from 'devextreme/data/array_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'app-all-srw',
  templateUrl: './all-srw.component.html',
  styleUrls: ['./all-srw.component.css']
})
export class AllSrwComponent {
  public SRWArrayStore: ArrayStore;
  public SRWs: SRW[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SRW[]>(baseUrl + 'SRW').subscribe(result => {
      this.SRWs = result;
    }, error => console.error(error));
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