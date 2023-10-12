import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  public XpAndGuild: UserInfo;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<UserInfo>(baseUrl + 'user').subscribe(result => {
      this.XpAndGuild = result;
    }, error => console.error(error));
  }
}

interface UserInfo {
  Xp: number;
  Guild: string;
}
