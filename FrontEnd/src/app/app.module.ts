import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { SidebarMenuComponent } from './sidebar-menu/sidebar-menu.component';
import { LoginComponent } from './login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';


import { LandingContainerComponent } from './landing-container/landing-container.component';
import { ContactListComponent } from './landing-container/contact-list/contact-list.component';
import { AddDirectoryComponent } from './landing-container/add-directory/add-directory.component';
import { AddContactComponent } from './landing-container/add-contact/add-contact.component';
import { SearchContactComponent } from './landing-container/search-contact/search-contact.component';
import { DirectoryListComponent } from './landing-container/directory-list/directory-list.component';
import { HttpService } from './http.service';

export const MENU_ROUTES: Routes = [
  { path: '', component: ContactListComponent },
  { path: 'directory-list', component: DirectoryListComponent },
  //  { path: '', redirectTo: '/contact-list', pathMatch: 'full' },
  { path: 'add-directory', component: AddDirectoryComponent },
  { path: 'add-contact', component: AddContactComponent },
  { path: 'search-contact', component: SearchContactComponent },
  { path: 'add-directory/:id', component: AddDirectoryComponent },
  { path: 'add-contact/:recordid', component: AddContactComponent }

];

const appRoutes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'landing-container', component: LandingContainerComponent, children: MENU_ROUTES },

];


@NgModule({
  declarations: [
    AppComponent,
    SidebarMenuComponent,
    LoginComponent,
    ContactListComponent,
    LandingContainerComponent,
    AddDirectoryComponent,
    AddContactComponent,
    SearchContactComponent,
    DirectoryListComponent,
   
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
