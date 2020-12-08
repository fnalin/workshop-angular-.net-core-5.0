import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MenuModule } from './menus/menus.module';
import { PageModule } from './pages/page.module';
import { AppRoutingModule } from './app.routing.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, AppRoutingModule, MenuModule, PageModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
