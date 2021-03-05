import { Component } from '@angular/core';
import ruMessages from "devextreme/localization/messages/ru.json";
import { locale, loadMessages } from "devextreme/localization";

import "devextreme/localization/globalize/number";
import "devextreme/localization/globalize/date";
import "devextreme/localization/globalize/currency";
import "devextreme/localization/globalize/message";

import supplemental from "devextreme-cldr-data/supplemental.json";
import ruCldrData from "devextreme-cldr-data/ru.json"; 
import Globalize from "globalize";
 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor() {
    Globalize.load(supplemental, ruCldrData);
    Globalize.loadMessages(ruMessages);
    Globalize.locale('ru');
    loadMessages(ruMessages);
   
}
}
