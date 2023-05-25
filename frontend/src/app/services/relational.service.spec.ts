import { TestBed } from '@angular/core/testing';

import { RelationalService } from './relational.service';

describe('RelationalService', () => {
  let service: RelationalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RelationalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
