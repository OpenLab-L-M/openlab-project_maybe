
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { GuildService } from './guild.service'; 
import { UserInfo } from '../dashboard/dashboard.component';

@Component({
  selector: 'app-gulid-details',
  templateUrl: './gulid-details.component.html',
  styleUrls: ['./gulid-details.component.css']
})
export class GulidDetailsComponent implements OnInit {
  guildId: number | null = null;

  guildDetails!: GuildDetailsDTO | null;

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

  navigateTo() {
    this.router.navigate(['/app.module']);
  }
  
}

export interface GuildDetailsDTO {
  id: number;
  guildName: string;
  description: string;
  members: UserInfo[];
}
