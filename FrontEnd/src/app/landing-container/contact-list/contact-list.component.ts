import { Component, OnInit } from '@angular/core';
import { ContactListService } from './contact-list.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from '../../http.service';


@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css'],
    providers: [ ContactListService]

})
export class ContactListComponent implements OnInit {

  contactDetails: any []= [];
  id: number;
    private sub: any;

  constructor(private httpService: HttpService, private route: ActivatedRoute,private router: Router, private contactList: ContactListService) { }

  ngOnInit() {
    this.httpService.ListRecord()
     .subscribe(
             (data)=>{           
               this.contactDetails= data;                              
             }
   ); 
  }

}
