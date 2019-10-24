import { Component, OnInit, Input } from '@angular/core';
import { Employee } from '../models/employee.interface';
import { EmployeeApiService } from '../services/employee-api.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  public employees: Observable<Employee[]>;
  constructor(private employeeApiService: EmployeeApiService) { }

  ngOnInit() {
      this.employees = this.employeeApiService.getEmployees();
  }
}
