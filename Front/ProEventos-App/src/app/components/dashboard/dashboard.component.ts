import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import {internalIpV6, internalIpV4} from 'internal-ip';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  @Input() ipAddress: string = '';
  @Input() localAdress: any;
  constructor(private http:HttpClient) { }

  ngOnInit() {
    this.getIPAddress();   
    this.getLocalIPAddress();     
  }
  
  getIPAddress()
  {    
      this.http.get("http://api.ipify.org/?format=json").subscribe(async (res:any)=>{
      this.ipAddress = res.ip;
    });    
  }

  getLocalIPAddress()
  {    
      this.http.get("http://localhost:5000/api/HttpConnection",{responseType: 'text'}).subscribe(async (data:any) => {
      this.localAdress = data;
      console.log(data)
    });    
  }
 

}
