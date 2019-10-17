import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { EmployeeComponent } from './employee/employee.component';

const routes: Routes = [
    {
        path: 'employee',
        component: EmployeeComponent,
        children: [
            {
                path: '', redirectTo: 'list', pathMatch: 'full'
            },
            {
                path: 'list',
                component: EmployeeListComponent
            },
            {
                path: 'detail',
                component: EmployeeDetailComponent
            },
            {
                path: 'detail/:id',
                component: EmployeeDetailComponent
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class EmployeeRoutingModule { }