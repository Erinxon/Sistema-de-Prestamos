import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConcederPrestamoComponent } from './conceder-prestamo.component';

describe('ConcederPrestamoComponent', () => {
  let component: ConcederPrestamoComponent;
  let fixture: ComponentFixture<ConcederPrestamoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConcederPrestamoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConcederPrestamoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
