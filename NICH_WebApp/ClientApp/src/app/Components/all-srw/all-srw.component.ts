import { HttpClient} from '@angular/common/http';
import { HttpParams} from '@angular/common/http';
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
//, {params: new HttpParams().set("isAll", this.isAllChB as unknown as string)}
  ngOnInit(): void {
    this.GetSrws(this.isAllChB);
  }

  handleValueChange (e) {
// this.isAllChB
    this.GetSrws(e.value);
}
  updateClicked(e)
  {
    this.GetSrws(this.isAllChB);
  }

  GetSrws (isAll: boolean):void {
    this.http.get<SRW[]>(this.BaseUrl + 'SRW',{params: new HttpParams().set("isAll", isAll as unknown as string)}).subscribe(result => {
      this.SRWs = result; 
      this.SRWArrayStore = new ArrayStore({
        key: "IdSWR",
        data: this.SRWs})
      },error => console.error(error));
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