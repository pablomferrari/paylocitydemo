import { Component, OnInit, Input } from '@angular/core';
import { Dependent } from './models';

@Component({
  selector: 'app-dependents',
  templateUrl: './dependents.component.html',
  styleUrls: ['./dependents.component.css']
})
export class DependentsComponent implements OnInit {
  @Input() dependents: Dependent[] = [];
  constructor() { }

  ngOnInit() {
  }

}
