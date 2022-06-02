import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  @Input() ipAddress: string = '';
  @Input() localAdress: any;
  @Input() localhost: any;
  constructor(private http:HttpClient) { }

  ngOnInit() {
    this.getIPAddress();   
    this.getLocalIPAddress();   
    this.getHostName();  
  }
  
  getIPAddress()
  {    
      this.http.get("http://api.ipify.org/?format=json").subscribe(async (res:any)=>{
      this.ipAddress = res.ip;
    });    
  }

  getLocalIPAddress()
  {    
      this.http.get("http://localhost:5000/api/HttpConnection/getlocalip",{responseType: 'text'}).subscribe(async (data:any) => {
      this.localAdress = data;
      console.log(data)
    });    
  }
 
  getHostName()
  {    
      this.http.get("http://localhost:5000/api/HttpConnection/getlocalhost",{responseType: 'text'}).subscribe(async (data:any) => {
      this.localhost = data;
      console.log(data)
    });    
  }


}
