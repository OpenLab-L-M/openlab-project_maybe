import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { GuildService } from './guild.service';


@Component({
  selector: 'app-gulid-details',
  templateUrl: './gulid-details.component.html',
  styleUrls: ['./gulid-details.component.css']
})
export class GulidDetailsComponent implements OnInit {
  guildId!: number;

  guildDetails!: GuildDetailsDTO | null;
  userInfo!: UserInfoDTO;

  constructor(private router: Router, private route: ActivatedRoute, private guildService: GuildService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const idParam = params.get('guildId');

      if (idParam !== null) {
        this.guildId = +idParam;
        this.loadGuildDetails();
      } else {
        console.error('Guild ID is null');
      }
    });
  }

  loadGuildDetails() {
    this.guildService.getGuildDetails(this.guildId!).subscribe(
      data => {
        this.guildDetails = data;
      },
      error => {
        console.error('Error fetching guild details', error);
      }
    );
  }
  joinGuild() {
    //if (this.userInfo.userId !== undefined) {
    this.guildService.joinGuild(this.guildId)
      .subscribe(
        response => {
          console.log(response);
          this.loadGuildDetails();
        },
        error => {
          console.error('Error joining guild', error);
        }
    );
    //}
  }

  leaveGuild() {
      this.guildService.leaveGuild().subscribe(
        response => {
          console.log(response);
          this.loadGuildDetails();
        },
        error => {
          console.error('Error leaving guild', error);
        }
      );
  }

  navigateTo() {
    this.router.navigate(['/app.module']);
  }

}

export interface GuildDetailsDTO {
  id: number;
  guildName: string;
  description: string;
  members: UserInfoDTO[];
}
export interface UserInfoDTO {
  userId: string,
  guildId: number,
  userName: string
}



