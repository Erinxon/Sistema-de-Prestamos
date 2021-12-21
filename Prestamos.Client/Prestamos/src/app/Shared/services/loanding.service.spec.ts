import { TestBed } from '@angular/core/testing';

import { LoandingService } from './loanding.service';

describe('LoandingService', () => {
  let service: LoandingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoandingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
