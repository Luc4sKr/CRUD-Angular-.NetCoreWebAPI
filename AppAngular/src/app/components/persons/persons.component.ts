import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms'

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.scss']
})
export class PersonsComponent implements OnInit {

  form: any;
  formTitle?: string;

  constructor() { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null),
      lastName: new FormControl(null),
      age: new FormControl(null),
      occupation: new FormControl(null)
    });
  }
}
