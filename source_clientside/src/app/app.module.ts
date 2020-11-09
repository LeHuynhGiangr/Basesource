import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginModule } from './login/login.module';
import { MainModule } from './main/main.module';
import { GeneralModule } from './general/general.module';
import { AdminModule } from './admin/admin.module';
import { _404Module } from './404/404.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    MainModule,
    GeneralModule,
    AdminModule,
    _404Module,

  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

