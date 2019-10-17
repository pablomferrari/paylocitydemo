import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee.interface';
import { ActivatedRoute } from '@angular/router';
import { EmployeeApiService } from '../services/employee-api.service';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {

  public employee: Employee;
  constructor(
    private route: ActivatedRoute,
    private employeeApiService: EmployeeApiService) { }

  ngOnInit() {
    this.getEmployee();
  }

  private getEmployee() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.employeeApiService.getEmployee(id).subscribe((e: Employee) => {
      this.employee = e;
    });    
  }

}
