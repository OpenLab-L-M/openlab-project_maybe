

import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { GuildInformation } from '../GuildInformation';
import { User } from '../User';

@Component({
  selector: 'app-gulid-details',
  templateUrl: './gulid-details.component.html',
  styleUrls: ['./gulid-details.component.css']
})
export class GulidDetailsComponent {

  users: User[] =[];

  constructor(private router: Router,
    private http: HttpClient
  ) { }

  navigateTo() {
    this.router.navigate(['/app.module'])
  }

 
  ngOnInit() {
  
    this.getAllUsers();
  }

  getAllUsers() {
    this.http.get<User[]>("https://localhost:7133/User/getAllUsers").subscribe(data =>
      this.users = data);
  }

}



