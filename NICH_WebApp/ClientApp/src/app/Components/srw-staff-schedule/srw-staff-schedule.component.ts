import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DxDataGridComponent, DxSelectBoxComponent } from 'devextreme-angular';
import SelectBox from "devextreme/ui/select_box";

@Component({
  selector: 'app-srw-staff-schedule',
  templateUrl: './srw-staff-schedule.component.html',
  styleUrls: ['./srw-staff-schedule.component.css']
})
export class SrwStaffScheduleComponent implements OnInit, AfterViewInit  {
  private sub: any;
  public IdSrw: number;
  public IdDept: number;
  public NumSrw: string;
  public SelectedSRWStaffS: SRWStaffSchedule = new SRWStaffSchedule();
  public data: SRWStaffSchedule[] = [new SRWStaffSchedule()];
   @ViewChild("selectBoxRef", {static: false}) selectBox: DxSelectBoxComponent

  constructor(private route: ActivatedRoute,
              private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string){
    this.sub = this.route.queryParams.subscribe(params => {
    this.IdSrw = +params['idSrw'];
      this.IdDept = +params['idDept'];
      this.NumSrw = params['numSrw'];
     });
     // (+) converts string 'id' to a number
  }

  ngOnInit() {
    let hp = new HttpParams().set("idSrw", this.IdSrw  as unknown as string)
                            .set("idDept", this.IdDept  as unknown as string)
    this.http.get<SRWStaffSchedule[]>(this.baseUrl + 'SRWStaffSchedule', {params: hp})
    .subscribe(result => {
      this.data = result;
      this.SelectedSRWStaffS = this.data[0];
     })
 /*
   this.sub = this.route.paramMap.subscribe(paramMap => {
   this.IdSrw = +paramMap.get('idSrw');
     this.IdDept = +paramMap.get('idDept');
       });
     // (+) converts string 'id' to a number

     this.IdSrw = +this.route.snapshot.paramMap.get('idSrw');
     this.IdDept = +this.route.snapshot.paramMap.get('idDept');
 */
 }
  handleValueChange(e): void
 {
  this.SelectedSRWStaffS = this.data.find((element, index, array)=>
  {
    if(element.IdSnir === e.value)
    return element;
  })}
  ngAfterViewInit(): void {
    // console.log(this.data[0].DateS+",   "+this.selectBox.text +"  "+ this.selectValue);
    // if(this.data.length !== 0)
    // {
    //   console.log(this.data[0].DateS+",   "+this.selectBox.text);
    //   this.selectBox.value = this.data[0].IdSnir;
    //   this.selectBox.text = this.data[0].DateS
    //}
  }
}
function printSrwS(srwS:SRWStaffSchedule):void
{
  console.log("IdSnir = " + srwS.IdSnir + ", | DateS =" + srwS.DateS +
  ", | FOTSm = " + srwS.FOTSm + ", | Fact1 = " + srwS.Fact1 + ", | ISumma = " + srwS.ISumma)
}
export class SRWStaffSchedule {
  IdSnir: number;
  DateS: string;
  NumSRW: string;
  FOTSm: number;
  Fact1: number;
  Fact2: number;
  State: boolean;
  ISumma: number;
  Distr: number;
}
