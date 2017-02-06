import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { LoginService } from './login.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [LoginService]
})
export class LoginComponent implements OnInit {
userName;
Password;
userDetails;
model: any= {};

  constructor(private router: Router, private loginService: LoginService) {

   }
 ngOnInit() {  }

 OnSignIn()
 {
   this.userName= this.model.username; 
this.Password= this.model.password;
   this.loginService.Login(this.userName,this.Password);
 }

 

  

}
