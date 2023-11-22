import { Injectable, OnInit } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { GuildInformation } from '../GuildInformation';
import { User } from '../User';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-guild',
  templateUrl: './guild.component.html',
  styleUrls: ['./guild.component.css']
})


export class GuildComponent implements OnInit {

  users: User[] = [];

  ngOnInit() {
    this.getGuild();
    this.getAllUsers();
  }

  getAllUsers() {
    this.http.get<User[]>("https://localhost:7133/User/getAllUsers").subscribe(data =>
      this.users = data);
  }

  getGuild() {
    this.http.get<GuildInformation[]>("https://localhost:7133/guild").subscribe(result => {
      this.GuildData = result;
    }, error => console.error(error))
  }


  Name: string = "no data";
  Description: string = "no data";
  GuildMaxMembers: number = 0;
  MembersCount: number = 0;

  GuildData: GuildInformation[] = [];

  constructor(
    private http: HttpClient,
    private router: Router,  // Add Router to constructor parameters
    private userService: UserService,

   // @Inject('BASE_URL') baseUrl: string,
 
  ) {
  /*  http.get<GuildInformation[]>(baseUrl + 'guild').subscribe(result => {
      this.GuildData = result;
    }, error => console.error(error));*/
  }

  async onJoinClick(guildId: number, userId: number) {
    await this.userService.updateGuildInformationNumber(guildId, userId, 1);

    // Navigate to GuildDetails after updating information
    this.router.navigate(['/guild-details', guildId]);
  }
}




