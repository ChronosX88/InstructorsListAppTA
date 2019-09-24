import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    public instructors: any[] = [{id: "1", firstName: "Test", lastName: "Testov"}];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        /*http.get<Instructor[]>(baseUrl + 'api/v1/instructors').subscribe(result => {
          this.instructors = result;
        }, error => console.error(error));*/
    }
}

interface Instructor {
    id: string,
    firstName: string,
    lastName: string
}