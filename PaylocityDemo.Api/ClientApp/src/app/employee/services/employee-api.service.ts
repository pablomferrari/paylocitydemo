import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.interface';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class EmployeeApiService {


  constructor(private http:HttpClient) {

   }

   public getEmployees(): Observable<Employee[]> {
     return this.http.get<Employee[]>('api/employees');     
   }

   getEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>('api/employees/' + id);
  }
}
