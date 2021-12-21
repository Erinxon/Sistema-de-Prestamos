import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarClientesComponent } from './agregar-clientes.component';

describe('AgregarClientesComponent', () => {
  let component: AgregarClientesComponent;
  let fixture: ComponentFixture<AgregarClientesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarClientesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarClientesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
