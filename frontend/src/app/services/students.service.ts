import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class StudentsService {
    private url = 'http://localhost:80/api/Student';
  
    constructor(
        private http: HttpClient
    ) { }

    // Get all students
    getStudents() {
        return this.http.get(this.url + '/GetStudents');
    }

    // Get student by code
    getStudentByCode(studentCode: string): Observable<any> {
        return this.http.get(this.url + '/GetStudentByCode/' + studentCode);
    }

    // Get student id
    getStudentId(studentCode: string) {
        return this.http.get(this.url + '/GetStudentId/' + studentCode);
    }

    // Add student
    addStudent(name: string, lastname: string, studentCode: string, birthdate: string): Observable<any> {    
        console.log(name, lastname, studentCode, birthdate);
        return this.http.post(this.url + '/CreateStudent', {
            name: name,
            lastName: lastname,
            studentCode: studentCode,
            birthDate: birthdate
        });
    }

    // Update student
    updateStudent(id: number, name: string, lastname: string, studentCode: string, birthdate: string): Observable<any> {
        console.log(id, name, lastname, studentCode, birthdate);
        return this.http.put(this.url + '/UpdateStudent', {
            id: id,
            name: name,
            lastName: lastname,
            studentCode: studentCode,
            birthDate: birthdate
        });
    }

    // Delete student
    deleteStudent(id: number) {
        return this.http.delete(this.url + '/DeleteStudent/' + id);
    }
}
