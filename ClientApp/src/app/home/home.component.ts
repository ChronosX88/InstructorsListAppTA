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
    private savedInstructor: Instructor = new Instructor();

    constructor(private instructorsService: InstructorsHttpService) {}

    ngOnInit() {
        this.loadInstructors()
    }

    private loadInstructors() {
        this.instructorsService.getInstructors().subscribe(result => {
            this.instructors = result
        })
    }

    setChangingInstructor(instructor: Instructor) {
        Object.assign(this.savedInstructor, instructor)
        this.changingInstructor = instructor
    }

    clearChangingInstructor(isUndo: boolean) {
        if(isUndo) {
            // undo edit changes
            Object.assign(this.changingInstructor, this.savedInstructor) // copy previous object
        }
        this.changingInstructor = new Instructor() // remove ref
        this.savedInstructor = new Instructor()
    }

    saveChanges() {
        if(this.changingInstructor.id == null) {
            console.log("Creating instructor...")
            this.instructorsService.createInstructor(this.changingInstructor).subscribe(result => {
                this.instructors.push(result)
                console.log("Instructor successfully created")
                
            })
            
        } else {
            console.log("Updating instructor...")
            this.instructorsService.updateInstructor(this.changingInstructor).subscribe(_ => {
                console.log("Instructor successfully updated")
            })
        }
        this.clearChangingInstructor(false)
    }

    deleteInstructor(instructor: Instructor) {
        this.instructorsService.deleteInstructor(instructor.id).subscribe(_ =>{
            this.instructors.splice(this.instructors.indexOf(instructor), 1)
        })
    }
}