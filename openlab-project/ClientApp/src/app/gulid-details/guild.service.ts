
import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GuildService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getGuildDetails(guildId: number): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'guild/' + guildId);
  }
}
