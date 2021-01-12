import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-nir-edit',
  templateUrl: './nir-edit.component.html',
  styleUrls: ['./nir-edit.component.css']
})
export class NirEditComponent implements OnInit {
/**
   NumSRW
 FullNameSRW
 B_DateTime
  E_DateTime
   IdType
 IdDirection
  IdOrganization
 SSheff
  BaseExec
  Phone
  № приказа - OrdNum
  Дата приказа - OrdDate
  № регистрации - NomReg
  Дополнительное финансирование - OtherFin
  BaseSRW
  IDType2
  iTypeSub
  **/



/*
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
*/
  ngOnInit(): void {
  }

  helloWorld() {
    alert('Hello world!');
}
}
