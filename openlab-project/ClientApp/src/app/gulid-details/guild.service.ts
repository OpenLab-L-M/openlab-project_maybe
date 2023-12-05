
import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GuildDetailsDTO, UserInfoDTO } from '../gulid-details/gulid-details.component';

@Injectable({
  providedIn: 'root'
})
export class GuildService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  joinGuild(guildId: number): Observable<GuildDetailsDTO> {
    const url = `${this.baseUrl}guild/join`;
    return this.http.post<GuildDetailsDTO>(url, guildId);
  }

  leaveGuild(): Observable<GuildDetailsDTO> {
    const url = `${this.baseUrl}guild/leave`;
    return this.http.get<GuildDetailsDTO>(url);
  }

  getGuildDetails(guildId: number): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'guild/' + guildId);
  }
}
