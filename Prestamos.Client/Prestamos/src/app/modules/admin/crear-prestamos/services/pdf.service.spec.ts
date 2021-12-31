import { TestBed } from '@angular/core/testing';

import { CronogramprestamoPdfService } from './cronograma-prestamo-pdf.service';

describe('PdfService', () => {
  let service: CronogramprestamoPdfService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CronogramprestamoPdfService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
