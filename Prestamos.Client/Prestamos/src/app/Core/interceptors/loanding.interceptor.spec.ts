import { TestBed } from '@angular/core/testing';

import { LoandingInterceptor } from './loanding.interceptor';

describe('LoandingInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      LoandingInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: LoandingInterceptor = TestBed.inject(LoandingInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
