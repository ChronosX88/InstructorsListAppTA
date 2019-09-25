import { Injectable, Inject } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Instructor } from '../models/instructor';
 
@Injectable()
export class InstructorsHttpService {
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

    getInstructors() {
        return this.http.get<Instructor[]>(this.baseUrl + "api/v1/instructors")
    }

    createInstructor(instructor: Instructor) {
        return this.http.post(this.baseUrl + "api/v1/instructors/add", instructor)
    }

    updateInstructor(instructor: Instructor) {
        return this.http.put(this.baseUrl + "api/v1/instructors/" + instructor.id, instructor)
    }

    deleteInstructor(id: string) {
        return this.http.delete(this.baseUrl + "api/v1/instructors/" + id)
    }
}