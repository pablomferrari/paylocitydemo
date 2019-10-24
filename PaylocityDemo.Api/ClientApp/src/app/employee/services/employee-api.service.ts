import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.interface';
import { Paycheck } from '../models';

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

  updateEmployee(employee: Employee): Observable<Employee> {
    return this.http.put<Employee>('api/employees/' + employee.id, employee);
  }

  addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>('api/employees/', employee);
  }

  getPaycheck(id: number): Observable<Paycheck> {
    return this.http.get<Paycheck>('api/employees/paycheck/' + id);
  }
}
