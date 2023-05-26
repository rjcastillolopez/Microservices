import { Component } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { NgForm } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { StudentsService } from 'src/app/services/students.service';

@Component({
    selector: 'app-students',
    templateUrl: './students.component.html',
    styleUrls: ['./students.component.css']
})
export class StudentsComponent {

    student: Student = {
        name: '',
        lastname: '',
        studentCode: '',
        birthdate: ''
    };

    students: Array<Student> = [];

    constructor(
        private studentService: StudentsService
    ) { }

    ngOnInit() {
        this.getStudents();
        console.log(this.students);
    }

    getStudents() { 
        this.studentService.getStudents().subscribe(
            (res: any) => {
                res.forEach((obj: any) => {
                    let _student = {
                        name: obj.name,
                        lastname: obj.lastName,
                        studentCode: obj.studentCode,
                        birthdate: new Date(obj.birthDate).toISOString().split('T')[0]
                    };
                    this.students.push(_student);
                });
            },
            err => {
                console.log(err);
            }
        );
    }

    onSubmit(form: NgForm) {
        if (form.invalid) {
            console.log('Formulario inválido');
        } else {
            console.log('Formulario válido');
            this.studentService.getStudentByCode(this.student.studentCode).subscribe(
                (res: any) => {
                    if (res) {
                        alert('El código de estudiante ya existe');
                    } else {
                        this.studentService.addStudent(this.student.name, this.student.lastname, this.student.studentCode, this.student.birthdate).subscribe(
                            (res: any) => {
                                alert('Estudiante agregado');
                                this.students.push(this.student);
                                // reload page
                                window.location.reload();
                            },
                            err => {
                                console.log(err);
                            }
                        );
                    }
                },
            );
        }
    }

    onUpdate(form: NgForm) {
        if (form.invalid) {
            console.log('Formulario inválido');
        } else {
            console.log('Formulario válido');
            this.studentService.getStudentId(this.student.studentCode).subscribe(
                (id: any) => {
                    console.log(id, this.student.name, this.student.lastname, this.student.studentCode, this.student.birthdate);
                    this.studentService.updateStudent(id, this.student.name, this.student.lastname, this.student.studentCode, this.student.birthdate).subscribe(
                        (res: any) => {
                            alert('Estudiante actualizado');
                            // reload page
                            window.location.reload();
                        },
                        err => {
                            console.log(err);
                        }
                    );
                },
                err => {
                    console.log(err);
                }
            );
        }
    }

    onDelete() {
        if (confirm('¿Está seguro de que desea eliminar este estudiante?')) {
            this.studentService.getStudentId(this.student.studentCode).subscribe(
                (id: any) => {
                    this.studentService.deleteStudent(id).subscribe(
                        (res: any) => {
                            alert('Estudiante eliminado');
                            // reload page
                            window.location.reload();
                        }
                    );
                },
                err => {
                    console.log(err);
                }
            );
        }
    }

    onSelect(student: Student) {
        this.student = student;
    }

    onClear() {
        this.student = {
            name: '',
            lastname: '',
            studentCode: '',
            birthdate: ''
        };
    }
}
