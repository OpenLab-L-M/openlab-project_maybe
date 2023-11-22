
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GuildService {
  private baseUrl = 'https://your-api-base-url/api/guild'; // Update with your actual API base URL

  constructor(private http: HttpClient) { }

  getGuildDetails(guildId: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/${guildId}`);
  }
}
