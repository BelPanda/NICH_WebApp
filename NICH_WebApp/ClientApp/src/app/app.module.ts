import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { registerLocaleData } from '@angular/common';
import localeRu from '@angular/common/locales/ru';

import { DxButtonModule } from 'devextreme-angular/ui/button';
import { DxSelectBoxModule, DxDataGridModule, DxCheckBoxModule,
        DxTextBoxModule, DxBoxModule, DxTextAreaModule, DxDateBoxModule} from 'devextreme-angular';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NirEditComponent } from './Components/nir-edit/nir-edit.component';
import { AllSrwComponent } from './Components/all-srw/all-srw.component';
import { SrwStaffScheduleComponent } from './Components/srw-staff-schedule/srw-staff-schedule.component';

registerLocaleData(localeRu);

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    NirEditComponent,
    AllSrwComponent,
    SrwStaffScheduleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'nir-edit', component: NirEditComponent },
      { path: 'all-srw', component: AllSrwComponent },
      {path: 'srw-staff-schedule', component: SrwStaffScheduleComponent}
    ]),
    DxButtonModule,
    DxSelectBoxModule,
    DxDataGridModule,
    DxTextBoxModule,
    DxCheckBoxModule,
    DxTextAreaModule,
    DxBoxModule,
    DxDateBoxModule
  ],
  providers: [ { provide: LOCALE_ID, useValue: 'ru' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
