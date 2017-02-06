import { Component, OnInit } from '@angular/core';
import { DirectoryListService } from './directory-list.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from '../../http.service';

@Component({
  selector: 'app-directory-list',
  templateUrl: './directory-list.component.html',
  styleUrls: ['./directory-list.component.css'],
  providers: [ DirectoryListService]
})
export class DirectoryListComponent implements OnInit {
// currentId;
directoryDetails: any []= [];
  id: number;
    private sub: any;


  constructor(private httpService: HttpService ,private route: ActivatedRoute,private router: Router, private directoryList: DirectoryListService) { 
   
  }
  
  ngOnInit() {
     this.httpService.ListDirectory()
     .subscribe(
             (data)=>{           
               this.directoryDetails= data;                              
             }
   ); 
  }

  

}
