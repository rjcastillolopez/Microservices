import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class RelationalService {
    private url = 'http://localhost:5286/api/NoRelational';  

    constructor(
        private http: HttpClient
    ) { }

    // Get alL objects
    getObjects() {
        return this.http.get(this.url + '/GetObjects');
    }
    
    getObject(id: number): Observable<any> {
        return this.http.get(this.url + '/GetObject/' + id);
    }

    // Add object
    addObject(id:number, name: string, value: string, parentId: number): Observable<any> {
        return this.http.post(this.url + '/AddObject', {
            id: id,
            name: name,
            value: value,
            parentId: parentId
        });
    }

    // Update object
    updateObject(id: number, name: string, value: string, parentId: number): Observable<any> {
        console.log(id, name, value, parentId);
        return this.http.put(this.url + '/UpdateObject', {
            id: id,
            name: name,
            value: value,
            parentId: parentId
        });
    }

    // Delete object
    deleteObject(id: number) {
        return this.http.delete(this.url + '/DeleteObject/' + id);
    }    
}
