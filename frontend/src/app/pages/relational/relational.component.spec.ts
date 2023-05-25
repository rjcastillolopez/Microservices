import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelationalComponent } from './relational.component';

describe('RelationalComponent', () => {
  let component: RelationalComponent;
  let fixture: ComponentFixture<RelationalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RelationalComponent]
    });
    fixture = TestBed.createComponent(RelationalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
