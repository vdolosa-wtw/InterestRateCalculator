import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WebApiService {

  private baseUrl;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  get<Type>(apiUrl: string, params?:HttpParams) {
    return this.http.get<Type>(this.baseUrl + apiUrl, { params: params } );
  }

  post<Type>(apiUrl: string, body: any) {
    return this.http.post<Type>(this.baseUrl + apiUrl, body);
  }
}
