import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeApiService } from 'src/app/employee/services/employee-api.service';
import { Paycheck } from 'src/app/employee/models';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';

@Component({
  selector: 'app-paycheck',
  templateUrl: './paycheck.component.html',
  styleUrls: ['./paycheck.component.css'],
  providers: [Location, {provide: LocationStrategy, useClass: PathLocationStrategy}]
})
export class PaycheckComponent implements OnInit {

  public paycheck = <Paycheck>{};

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private employeeApiService: EmployeeApiService) { }

  ngOnInit() {
    this.getPaycheck();
  }

  private getPaycheck() {
    const id = +this.route.snapshot.paramMap.get('id');
    if(id) {
      this.employeeApiService.getPaycheck(id).subscribe((e: Paycheck) => {
        this.paycheck = e;
      });  
    }
  }

  public goBack() {
    this.location.back();
  }

}
