import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Instructor } from '../models/instructor';
import { InstructorsHttpService } from '../services/instructors-http-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [InstructorsHttpService]
})
export class HomeComponent {
    public instructors: Instructor[];
    private changingInstructor: Instructor = new Instructor();

    constructor(private instructorsService: InstructorsHttpService) {}

    ngOnInit() {
        this.loadInstructors()
    }

    private loadInstructors() {
        this.instructorsService.getInstructors().subscribe(result => {
            this.instructors = result
        })
    }

    saveChanges() {
        if(this.changingInstructor.id == null) {
            this.instructorsService.createInstructor(this.changingInstructor).subscribe(result => {
                this.instructors.push(result)
            })
            
        } else {
            this.instructorsService.updateInstructor(this.changingInstructor)
        }
        this.changingInstructor = new Instructor()
    }

    deleteInstructor(instructor: Instructor) {
        this.instructorsService.deleteInstructor(instructor.id).subscribe(_ =>{
            this.instructors.splice(this.instructors.indexOf(instructor), 1)
        })
    }
}