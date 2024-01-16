import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment.development';
import { User } from '../models/user';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiUrl}/api/user/GetAll`);
  }

  createPost(user: User): Observable<User> {
    return this.http.post<User>(`${environment.apiUrl}/api/user/CreatePost`, user);
  }
}
