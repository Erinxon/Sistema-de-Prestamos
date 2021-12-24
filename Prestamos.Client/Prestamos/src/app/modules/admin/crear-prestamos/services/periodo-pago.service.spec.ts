import { TestBed } from '@angular/core/testing';

import { PeriodoPagoService } from './periodo-pago.service';

describe('PeriodoPagoService', () => {
  let service: PeriodoPagoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PeriodoPagoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
