import { Injectable } from '@angular/core';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers } from  '@angular/http';
import { Observable} from 'rxjs';
import 'rxjs/Rx';

@Injectable()
export class HttpService {

  constructor(private http : Http) { }

  Login(user: any):Observable <any>
  {
    console.log("From http service",user.userName,user.Password);
    const body = JSON.stringify(user);
    console.log(user)
    const headers = new Headers();
    headers.append('Content-Type','application/json');
    return this.http.post('http://localhost:61441//api/Login', user, { headers:headers})
    .map((response : Response) => response.json());
  }

  ListDirectory():Observable <any>
  { 
     return this.http.get('http://localhost:61441//api/ListDirectory')
     .map((response : Response) => response.json())     
  }

  ListRecord():Observable <any>
  { 
     return this.http.get('http://localhost:61441//api/ListRecord')
     .map((response : Response) => response.json())     
  }

  AddDirectory(directory: any):Observable <any>
  {    
    const headers = new Headers();
    headers.append('Content-Type','application/json'); 
    return this.http.post('http://localhost:61441//api/AddDirectory', directory ,{ headers:headers})
    .map((response : Response) => response.json())
    .catch(this.handleError); 
  }

  AddContact(Contact: any):Observable <any>
  {
    const headers = new Headers();
    headers.append('Content-Type','application/json'); 
    return this.http.post('http://localhost:61441//api/AddRecord', Contact ,{ headers:headers})
    .map((response : Response) => response.json())
    .catch(this.handleError);
  }

  SearchContact(SearchString: any): Observable <any>
  {
    console.log("im in SearchContact"+ SearchString);
    
    const headers = new Headers();
    headers.append('Content-Type','application/json'); 
    return this.http.post('http://localhost:61441//api/SearchRecord', SearchString, { headers:headers})
    .map((response : Response) => response.json())
    .catch(this.handleError); 
  }


  GetDirectoryById(id :any): Observable <any>
  {
    console.log("im in SearchContact"+ id);
    
    const headers = new Headers();
    headers.append('Content-Type','application/json'); 
    return this.http.post('http://localhost:61441//api/GetDirectoryById', id, { headers:headers})
    .map((response : Response) => response.json())
    .catch(this.handleError);  
     
  }

  GetRecordById(id :any): Observable <any>
  {
    console.log("im in SearchContact"+ id);
    
    const headers = new Headers();
    headers.append('Content-Type','application/json'); 
    return this.http.post('http://localhost:61441//api/GetRecordById', id, { headers:headers})
    .map((response : Response) => response.json())
    .catch(this.handleError);  
     
  }
  private handleError(error :any){
    console.log(error);
    return Observable.throw(error.json())
  }
}
