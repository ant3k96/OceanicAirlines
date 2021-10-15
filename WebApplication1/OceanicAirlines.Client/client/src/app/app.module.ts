import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatCardModule} from '@angular/material/card'
import {MatTabsModule} from '@angular/material/tabs';
import {MatInputModule} from '@angular/material/input';
import {MatRadioModule} from '@angular/material/radio';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table'

import { AppComponent } from './app.component';
import { CityClient, RouteClient } from './services/services';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { RecordsComponent } from './components/records/records/records.component';
import { BlacklistedComponent } from './components/blacklisted/blacklisted/blacklisted.component';
import { InfoComponent } from './components/info/info/info.component';

@NgModule({
  declarations: [
    AppComponent,
    RecordsComponent,
    BlacklistedComponent,
    InfoComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    MatCardModule,
    MatTabsModule,
    MatInputModule,
    MatRadioModule,
    MatCheckboxModule,
    MatButtonModule,
    ToastrModule.forRoot(),
    MatTableModule
  ],
  providers: [CityClient, RouteClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
