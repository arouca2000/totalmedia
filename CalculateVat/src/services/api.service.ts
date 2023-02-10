import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { Country } from 'src/model/country';
import { CountryVat } from 'src/model/countryvat';
import { CalcRequest } from 'src/model/calcRequest';

const apiGetCountriesUrl = 'https://localhost:7163/api/Countries/GetCountries';
const apiGetVatsByCountryIdUrl = 'https://localhost:7163/api/CountriesVats/GetVatsByCountryId';
const apiCalculateUrl = 'https://localhost:7163/api/Calculate/Calc';
var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getCountries (): Observable<Country[]> {
    return this.http.get<Country[]>(apiGetCountriesUrl, httpOptions)
      .pipe(
        tap(
          {
            next: (data) => {console.log(data)},
            error: (error) => {console.log(error)}
          }
        )
      );
  }

  getVatsByCountryId (id: number): Observable<CountryVat[]> {
    const url = `${apiGetVatsByCountryIdUrl}/${id}`;
    return this.http.get<CountryVat[]>(url, httpOptions)
      .pipe(
        tap(
          {
            next: (data) => {console.log(data)},
            error: (error) => {console.log(error)}
          }
        )
      );
  }

  calculate (Calc: any): Observable<CalcRequest> {
    if (Calc.netAmount == ''){
      Calc.netAmount = null;
    }
    if (Calc.vatAmount == ''){
      Calc.vatAmount = null;
    }
    if (Calc.grossAmount == ''){
      Calc.grossAmount = null;
    }
    return this.http.post<CalcRequest>(apiCalculateUrl, Calc, httpOptions)
    .pipe(
      tap(
        {
          next: (data) => {console.log(data)},
          error: (error) => {console.log(error)}
        }
      )
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

}
