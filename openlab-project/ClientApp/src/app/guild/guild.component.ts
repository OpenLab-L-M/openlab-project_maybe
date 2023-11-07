import { Component } from '@angular/core';

@Component({
  selector: 'app-guild',
  templateUrl: './guild.component.html',
  styleUrls: ['./guild.component.css']
})
export class GuildComponent {
  public guildInfo!: GuildDTO;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<GuildDTO>(baseUrl + 'guild').subscribe(result => {
      this.guildInfo = result;
    }, error => console.error(error));
  }
}

export interface GuildDTO {
  Name: string,
  Description: string,
  GuildMaxMembers: number,
  GuildMembers: number,
  MembersCount: number,
  GuildInformation: string

}

