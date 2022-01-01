import { TestBed } from '@angular/core/testing';

import { ErrorGuard } from './error.guard';

describe('ErrorGuard', () => {
  let guard: ErrorGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ErrorGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
