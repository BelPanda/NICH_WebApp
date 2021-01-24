import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

import ArrayStore from 'devextreme/data/array_store';
import Button from "devextreme/ui/button";

@Component({
  selector: 'app-all-srw',
  templateUrl: './all-srw.component.html',
  styleUrls: ['./all-srw.component.css']
})
export class AllSrwComponent implements OnInit{
  public SRWArrayStore: ArrayStore;
  public SRWs: SRW[] = [];
  private BaseUrl: string;
  public isAllChB: boolean = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   this.BaseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.http.get<SRW[]>(this.BaseUrl + 'SRW', {params: new HttpParams().set("isAll", this.isAllChB as unknown as string)}).subscribe(result => {
      this.SRWs = result;
      this.SRWArrayStore = new ArrayStore({
        key: "IdSWR",
        data: this.SRWs
      })
    }, error => console.error(error));
    
  }

  handleValueChange (e) {
    
    console.log("CheckBox");
  }
  updateClicked(e)
  {
    console.log("Button");
  }
}

export interface SRW {
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