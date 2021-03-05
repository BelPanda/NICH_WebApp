import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-nir-edit',
  templateUrl: './nir-edit.component.html',
  styleUrls: ['./nir-edit.component.css']
})
export class NirEditComponent implements OnInit {

  public Classifs: ClassifTypeSrw[] = [];
  public Organizations: Organization[] = [];
  public Finances: Finance[] = [];
  public SRW: ListSRW ;
constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
this.SRW = {} as ListSRW;
}
  ngOnInit(): void {
    this.http.get<ClassifTypeSrw[]>(this.baseUrl + 'SrwContent/TypeSrw').subscribe(result => {
      this.Classifs = result;
    }, error => console.error(error));
    this.http.get<Organization[]>(this.baseUrl + 'SrwContent/Organization').subscribe(result => {
      this.Organizations = result;
    }, error => console.error(error));
    this.http.get<Finance[]>(this.baseUrl + 'SrwContent/Finance').subscribe(result => {
      this.Finances = result;
    }, error => console.error(error));
  }

  saveSRW(srw: ListSRW)
  {
    console.log(srw.NumSRW);
    return this.http.post(this.baseUrl + 'SrwContent/CreateSRW', srw).subscribe(
      (data: ListSRW) => {
      },
      (error) => console.log(error)
    );
  }
}

interface ClassifTypeSrw {
  IdType: number;
  IdBT: number;
  NameBT: string;
  IdTypeSRW: number;
  NameSRW: string;
  Name: string;
}

interface Organization {
 IdOrganization: number;
 FullName: string;
 ShortName: string;
}

interface Finance {
  IdDirection: number;
  NameDirection: string;
}
interface ListSRW {
    IdSWR: number;
    NumSRW: string;
    FullNameSRW: string;
    IdType: number;
    B_DateTime: string;
    E_DateTime: string;
    IdDirection: number;
    IdOrganization: number;
    BaseSRW: string;
    OtherFin: boolean;
    BaseExec: string;
    Phone: string;
    SSheff: string;
    OrdNum: string;
    OrdDate: string;
     NomReg: string;
     iTypeSub : number;
    
}