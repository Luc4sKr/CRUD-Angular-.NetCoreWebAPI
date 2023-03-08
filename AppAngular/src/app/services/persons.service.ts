import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../models/person';

const httpOptions = {
  headers: new HttpHeaders({
    "contentType": "application/json"
  })
};

@Injectable({
  providedIn: 'root'
})
export class PersonsService {
  url = "https://localhost:7110/api/Person"

  constructor(private http: HttpClient) { }

  getAll(): Observable<Person[]> {
    return this.http.get<Person[]>(this.url);
  }

  getById(id: number): Observable<Person> {
    const urlAPI = `${this.url}/${id}`;
    return this.http.get<Person>(urlAPI);
  }

  save(person: Person): Observable<any> {
    return this.http.post<Person>(this.url, person, httpOptions);
  }

  update(person: Person): Observable<any> {
    const urlAPI = `${this.url}/${person.id}`;
    return this.http.put<Person>(urlAPI, person, httpOptions);
  }

  delete(id: number): Observable<any> {
    const urlAPI = `${this.url}/${id}`;
    return this.http.delete<number>(urlAPI, httpOptions);
  }
}
