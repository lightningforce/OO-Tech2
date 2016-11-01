import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { AppComponent }  from './app.component';
import { RouterModule }   from '@angular/router';
@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'addreserving', component: AddReservingComponent },
      { path: 'showsoldlist', component: ShowSoldListComponent },
      { path: 'showreservingorder', component: ShowReservingOrderComponent },
      { path: '**', component: PageNotFoundComponent }
    ])
  ],
  declarations: [
    AppComponent
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
