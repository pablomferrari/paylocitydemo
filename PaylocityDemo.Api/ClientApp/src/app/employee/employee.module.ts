import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { EmployeeComponent } from './employee/employee.component';
import { EmployeeRoutingModule } from './employee-routing.module';
import { FormsModule } from '@angular/forms';
import { EmployeeApiService } from './services/employee-api.service';

@NgModule({
  declarations: [EmployeeListComponent, EmployeeDetailComponent, EmployeeComponent],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    FormsModule
  ],
  providers: [
    EmployeeApiService
  ]
})
export class EmployeeModule { }
