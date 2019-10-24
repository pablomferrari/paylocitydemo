import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeRoutingModule } from './employee-routing.module';
import { FormsModule } from '@angular/forms';
import { EmployeeApiService } from './services/employee-api.service';
import { 
  EmployeeListComponent,
  EmployeeDetailComponent, 
  EmployeeComponent, 
  DependentsComponent,
  PaycheckComponent 
} from '.';

@NgModule({
  declarations: [
    EmployeeListComponent, 
    EmployeeDetailComponent, 
    EmployeeComponent,
    DependentsComponent,
    PaycheckComponent
  ],
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
