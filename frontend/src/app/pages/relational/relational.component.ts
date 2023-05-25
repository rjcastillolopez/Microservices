import { Component } from '@angular/core';
import { Object } from 'src/app/models/object.model';
import { NgForm } from '@angular/forms';
import { RelationalService } from 'src/app/services/relational.service';

@Component({
    selector: 'app-relational',
    templateUrl: './relational.component.html',
    styleUrls: ['./relational.component.css']
})
export class RelationalComponent {
    object: Object = {
        id: 0,
        name: '',
        value: '',
        parentId: 0
    };

    objects: Array<Object> = [];

    constructor(
        private relationalService: RelationalService
    ) { }

    ngOnInit() {
        this.getObjects();
        console.log(this.objects);
    }

    getObjects() {
        this.relationalService.getObjects().subscribe(
            (res: any) => {
                // cambiar logica para convertir tabla no relacional a relacional
                res.forEach((obj: any) => {
                    let _student = {
                        id: obj.id,
                        name: obj.name,
                        value: obj.value,
                        parentId: obj.parentId
                    };
                    this.objects.push(_student);
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
            this.relationalService.getObject(this.object.id).subscribe(
                (res: any) => {
                    if (res) {
                        alert('Ya existe un objeto con ese id');
                    } else {
                        this.relationalService.addObject(this.object.id, this.object.name, this.object.value, this.object.parentId).subscribe(
                            (res: any) => {
                                alert('Objeto agregado');
                                // reload page
                                window.location.reload();
                            },
                            err => {
                                console.log(err);
                            }
                        );
                    }
                }
            );
        }
    }

    onUpdate(form: NgForm) {
        if (form.invalid) {
            console.log('Formulario inválido');
        } else {
            console.log('Formulario válido');
            this.relationalService.updateObject(this.object.id, this.object.name, this.object.value, this.object.parentId).subscribe(
                (res: any) => {
                    alert('Objeto actualizado');
                    // reload page
                    window.location.reload();
                },
                err => {
                    console.log(err);
                }
            );
        }
    }

    onDelete() {
        if (confirm('¿Está seguro de que desea eliminar este objeto?')) {
            this.relationalService.deleteObject(this.object.id).subscribe(
                (res: any) => {
                    alert('Objeto eliminado');
                    // reload page
                    window.location.reload();
                }
            );
        }
    }

    onSelect(object: Object) {
        this.object = object;
    }

    onClear() {
        this.object = {
            id: 0,
            name: '',
            value: '',
            parentId: -2
        };
    }
}
