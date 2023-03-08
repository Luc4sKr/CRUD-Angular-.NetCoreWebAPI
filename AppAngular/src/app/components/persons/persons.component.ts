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
  persons?: Person[];

  tableVisibility: boolean = true;
  formVisibility: boolean = false;

  constructor(private personsService: PersonsService) { }

  ngOnInit(): void {
    this.personsService.getAll().subscribe(result => {
      this.persons = result;
    });
  }

  displayRegistrationForm(): void {
    this.tableVisibility = false;
    this.formVisibility = true;

    this.formTitle = "New Person";
    this.form = new FormGroup({
      name: new FormControl(null),
      lastName: new FormControl(null),
      age: new FormControl(null),
      occupation: new FormControl(null)
    });
  }

  displayUpdateForm(id: number): void {
    this.tableVisibility = false;
    this.formVisibility = true;

    this.personsService.getById(id).subscribe(result => {
      this.formTitle = `Update ${result.name} ${result.lastName}`;

      this.form = new FormGroup({
        id: new FormControl(result.id),
        name: new FormControl(result.name),
        lastName: new FormControl(result.lastName),
        age: new FormControl(result.age),
        occupation: new FormControl(result.occupation)
      });
    });;
  }

  back(): void {
    this.tableVisibility = true;
    this.formVisibility = false;
  }

  submitForm(): void {
    const person: Person = this.form.value;

    if (person.id > 0) {

      console.log(person.name)

      this.personsService.update(person).subscribe(result => {
        this.formVisibility = false;
        this.tableVisibility = true;

        alert("success");

        this.personsService.getAll().subscribe(newResult => {
          this.persons = newResult;
        });
      });
    } else {
      this.personsService.save(person).subscribe(result => {
        this.formVisibility = false;
        this.tableVisibility = true;

        alert("success");

        this.personsService.getAll().subscribe(newResult => {
          this.persons = newResult;
        });
      });
    }
  }
}
