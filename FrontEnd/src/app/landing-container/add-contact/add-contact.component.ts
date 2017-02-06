import { Component, OnInit, DoCheck } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { HttpService } from '../../http.service';
@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit, DoCheck {
  DirectoryList: any[]= [];
  Directory;
  FirstName;
  LastName;
  TelephoneNumber;
  Address;
  DirectoryId;
  itemid;
  sub: any;
  RecordId;
  Recordid;
  constructor(private httpService: HttpService, private route: ActivatedRoute ) { }

  ngOnInit() 
  {
     this.httpService.ListDirectory()
     .subscribe(
       (data)=> {
         this.DirectoryList= data;
       }
     );
        console.log("im in do chect:")
            this.sub = this.route.params.subscribe(params => {
            this.Recordid = +params['recordid']; // (+) converts string 'id' to a number
            
            if(this.Recordid>0){
              console.log("inside GetDirectoryById");
             var d= {"Name": null,"RecordId": this.Recordid}; 
            this.httpService.GetRecordById(d)
            .subscribe(
             (data)=>{           
                 this.FirstName= data.FirstName;
                 this.LastName= data.LastName;
                 this.TelephoneNumber= data.TelephoneNumber
                 this.Address= data.Address;
                 this.Directory= data.DirectoryList.Name;       
                 console.log("inside GetDirectoryById"+ this.Recordid);                      
                 }       
   );      
           }
            
            console.log("im in do chect:")
    });


  }
  ngDoCheck(){
                      
            } 

  submitContact(form: NgForm){
    console.log("im in submit:")
    this.FirstName= form.value.firstname;
    this.LastName= form.value.lastname;
    this.TelephoneNumber= form.value.telephone;
    this.Address= form.value.address;
    this.DirectoryId= this.Directory;
    this.RecordId= this.Recordid;
    console.log("inside submit:"+ this.Directory);
    console.log("inside submit:"+ this.RecordId);
    
    var Contact= {"FirstName":this.FirstName, "LastName":this.LastName,
                  "TelephoneNumber":this.TelephoneNumber, "Address": this.Address, 
                  "DirectoryId": this.DirectoryId, "RecordId": this.RecordId
                 };
    this.httpService.AddContact(Contact)
    .subscribe(
         (data)=>{            
                alert(data.ResponseMessage)                             
                 }         
   );  
  }

}
