import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormularioPersona } from './formulario-persona';
import {MatFormFieldModule} from '@angular/material/form-field'; 
import { MatCardModule } from '@angular/material/card'; 
import { MatInputModule } from '@angular/material/input';


describe('FormularioPersona', () => {
  let component: FormularioPersona;
  let fixture: ComponentFixture<FormularioPersona>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormularioPersona, MatFormFieldModule, MatCardModule, MatInputModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioPersona);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
