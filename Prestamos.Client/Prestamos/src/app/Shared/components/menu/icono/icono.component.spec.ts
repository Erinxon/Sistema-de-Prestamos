import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IconoComponent } from './icono.component';

describe('IconoComponent', () => {
  let component: IconoComponent;
  let fixture: ComponentFixture<IconoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IconoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IconoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
