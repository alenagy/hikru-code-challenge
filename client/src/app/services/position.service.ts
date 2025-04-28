import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Position {
  id: string;
  title: string;
  description: string;
  location: string;
  status: string;
  recruiterId: string;
  departmentId: string;
  budget: number;
  closingDate?: Date;
}

@Injectable({
  providedIn: 'root'
})
export class PositionService {
  private readonly apiUrl = 'https://localhost:7252/api/Positions'; // Change if needed

  constructor(private http: HttpClient) { }

  getAll(): Observable<Position[]> {
    return this.http.get<Position[]>(this.apiUrl);
  }

  getById(id: string): Observable<Position> {
    return this.http.get<Position>(`${this.apiUrl}/${id}`);
  }

  create(position: Partial<Position>): Observable<string> {
    return this.http.post<string>(this.apiUrl, position);
  }

  update(id: string, position: Partial<Position>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, position);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
