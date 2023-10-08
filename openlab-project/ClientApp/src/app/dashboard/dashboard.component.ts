import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserEntity } from '../userEntity';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  constructor(private http: HttpClient) {
  }

  text: string = "";
  userEntity: any;

  ngOnInit(){
    this.getUserData();

  }

  getUserData() {
    this.http.get('https://localhost:7133/WeatherForecast/UserData')
      .subscribe(data => {
        console.log(data);
        this.userEntity = data;
      });
  }
}
