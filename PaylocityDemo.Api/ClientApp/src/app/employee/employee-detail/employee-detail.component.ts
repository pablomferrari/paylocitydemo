import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee.interface';
import { ActivatedRoute } from '@angular/router';
import { EmployeeApiService } from '../services/employee-api.service';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { take } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Dependent } from './components/dependent/models';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css'],
  providers: [Location, {provide: LocationStrategy, useClass: PathLocationStrategy}]
})
export class EmployeeDetailComponent implements OnInit {

  public employee = <Employee>{};
  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private employeeApiService: EmployeeApiService) { }

  ngOnInit() {
    this.getEmployee();
  }

  private getEmployee() {
    const id = +this.route.snapshot.paramMap.get('id');
    if(id) {
      this.employeeApiService.getEmployee(id).subscribe((e: Employee) => {
        this.employee = e;
      });  
    }else {
      this.employee = <Employee> {
        firstName: '',
        lastName: '',
        dependents: []
      }
    }  
  }

  public goBack() {
    this.location.back();
  }

  public save() {
    this.removeEmptyDependents();
    let apiCall: Observable<Employee>;
    if(this.employee && this.employee.id) {
      apiCall = this.employeeApiService.updateEmployee(this.employee);
    }else {
      apiCall = this.employeeApiService.addEmployee(this.employee);
    }
    apiCall.pipe(take(1))
      .subscribe((employee) => {
        this.employee = employee;
        this.goBack();
      });
  }

  public addDependent() {
    const emptyDependents = this.employee.dependents.find((d) => !d.dependentName || !d.dependentName.trim());
    if(!emptyDependents){
      this.employee.dependents.push(<Dependent>{});
    }
  }

  private removeEmptyDependents() {
    this.employee.dependents = this.employee.dependents.filter(x => x.dependentName);
  }
}
