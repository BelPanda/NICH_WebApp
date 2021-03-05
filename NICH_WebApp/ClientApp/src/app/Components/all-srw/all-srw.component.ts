import { HttpClient} from '@angular/common/http';
import { HttpParams} from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import ArrayStore from 'devextreme/data/array_store';
import Button from 'devextreme/ui/button';

@Component({
  selector: 'app-all-srw',
  templateUrl: './all-srw.component.html',
  styleUrls: ['./all-srw.component.css']
})

export class AllSrwComponent implements OnInit {

  public SRWArrayStore: ArrayStore;
  public SRWs: SRW[] = [];
  private BaseUrl: string;
  public isAllChB = false;

  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
   this.BaseUrl = baseUrl;
  }
// , {params: new HttpParams().set("isAll", this.isAllChB as unknown as string)}
  ngOnInit(): void {
    this.GetSrws(this.isAllChB);
  }

   handleRowDblClick(e): void {
   // this.router.navigate(['/srw-staff-schedule',e.key, e.data.IdDept]);
   this.router.navigate(['/srw-staff-schedule']
    , { queryParams: {
      'idSrw': e.key,
      'idDept': e.data.IdDept,
      'numSrw': e.data.NumSRW
    }
   });
  }

  handleValueChange (e) {
    this.GetSrws(e.value);
}
  updateClicked(e) {
    this.GetSrws(this.isAllChB);
  }

  GetSrws (isAll: boolean): void {
    this.http.get<SRW[]>(this.BaseUrl + 'SRW', {params: new HttpParams().set('isAll', isAll as unknown as string)}).subscribe(result => {
      this.SRWs = result;
      this.SRWArrayStore = new ArrayStore({
        key: 'IdSWR',
        data: this.SRWs});
      }, error => console.error(error));
  }
}

export interface SRW {
   IdSWR: number;
   NumSRW: string;
   FullNameSRW: string;
   Type: string;
   B_DateTime: string;
   E_DateTime: string;
   NameDirection: string;
   ShortName: string;
   ExecutorName: string;
   IdDept: number;
}
