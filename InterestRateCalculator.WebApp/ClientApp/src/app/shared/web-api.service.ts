import { HttpClient, HttpParams } from '@angular/common/http';
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
    return this.http.get<Type>(this.baseUrl + apiUrl, { params: params} );
  }
}
