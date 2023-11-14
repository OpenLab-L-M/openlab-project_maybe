import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-gulid-details',
  templateUrl: './gulid-details.component.html',
  styleUrls: ['./gulid-details.component.css']
})
export class GulidDetailsComponent {
  constructor(private router: Router) { }

  navigateTo() {
    this.router.navigate(['/app.module'])
  }
}
