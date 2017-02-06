import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { HttpService } from '../../http.service';
@Component({
  selector: 'app-search-contact',
  templateUrl: './search-contact.component.html',
  styleUrls: ['./search-contact.component.css']
})
export class SearchContactComponent implements OnInit {
searchBy;
isValid;
SearchResult: any[]=[];
searchcontact;
searchname;
searchnumber;
  constructor(private httpService: HttpService) { }
  ngOnInit() 
  { 
     this.isValid= false;
  }

  searchContact(form: NgForm) {
    console.log("im in SearchContact" + form.value);
    var Contact;
    if(this.searchcontact== "searchbyname")
    {
    Contact= {
             "SearchString": form.value.searchname,
             "SearchBy": 1
    };      
    }

    if(this.searchcontact== "searchbynum")
    {
    Contact= {
             "SearchString":  form.value.searchnumber,
             "SearchBy": 0
    };      
    }
    
    this.httpService.SearchContact(Contact)
    .subscribe(
         (data)=>{   
                    this.isValid= true;         
                    console.log(data);   
                    this.SearchResult= data;                                      
                 });   
  }

  

}
