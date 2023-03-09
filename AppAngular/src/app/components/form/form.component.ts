import { Component, OnInit } from '@angular/core';

import { Person } from './../../models/person';
import { PersonsService } from './../../services/persons.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {
  form: any;
  formTitle?: string;

  constructor(private personsService: PersonsService) { }

  ngOnInit(): void {

  }

  submitForm(): void {
    const person: Person = this.form.value;

    if (person.id > 0) {
      this.personsService.update(person);
    } else {
      this.personsService.save(person)
    }
  }
}
