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
  }
  
    getIPAddress()
    {    
      this.http.get("http://api.ipify.org/?format=json").subscribe(async (res:any)=>{
      this.ipAddress = res.ip;
      console.log(await internalIpV4());
    });
  

  }

}
