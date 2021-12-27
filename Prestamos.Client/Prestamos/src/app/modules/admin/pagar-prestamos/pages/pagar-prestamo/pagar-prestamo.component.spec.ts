import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PagarPrestamoComponent } from './pagar-prestamo.component';

describe('PagarPrestamoComponent', () => {
  let component: PagarPrestamoComponent;
  let fixture: ComponentFixture<PagarPrestamoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PagarPrestamoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PagarPrestamoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
