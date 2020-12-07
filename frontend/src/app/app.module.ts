import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MenuModule } from './menus/menus.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, MenuModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
