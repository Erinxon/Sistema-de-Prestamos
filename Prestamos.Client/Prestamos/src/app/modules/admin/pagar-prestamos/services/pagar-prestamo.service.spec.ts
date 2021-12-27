import { TestBed } from '@angular/core/testing';

import { PagarPrestamoService } from './pagar-prestamo.service';

describe('PagarPrestamoService', () => {
  let service: PagarPrestamoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PagarPrestamoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
