import { PersonsService } from './../../services/persons.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms'

import { Person } from 'src/app/models/person';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.scss']
})
export class PersonsComponent implements OnInit {

  form: any;
  formTitle?: string;

  constructor(private personsService: PersonsService) { }

  ngOnInit(): void {
    this.formTitle = "New Person";

    this.form = new FormGroup({
      name: new FormControl(null),
      lastName: new FormControl(null),
      age: new FormControl(null),
      occupation: new FormControl(null)
    });
  }

  submitForm(): void {
    const person: Person = this.form.value;

    this.personsService.save(person).subscribe(result => {
      alert("success");
    });
  }
}
