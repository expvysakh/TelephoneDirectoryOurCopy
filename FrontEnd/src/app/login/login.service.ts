import { Injectable } from '@angular/core';
import { LoginComponent } from './login.component';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from '../http.service';


@Injectable()
export class LoginService {

  constructor(private router: Router, private httpService: HttpService ) { }
   
  RedirectToHome() {
    console.log("insideRedirectToHome function");
    
    this.router.navigate(['/landing-container']);
  }
  response= { "Isvalid": false};
  Login(userName, Password) {
    this.httpService.Login({"UserName": userName, "Password": Password})
    .subscribe(
         (data)=>{           
               this.response= data; 
               if (data.IsValid==true)
               {                    
                if(confirm(data.ResponseMessage)){
                this.RedirectToHome();}
               }
               else 
               {
                alert(data.ResponseMessage);
               }                              
           }       
   
   );         
    }

  }


