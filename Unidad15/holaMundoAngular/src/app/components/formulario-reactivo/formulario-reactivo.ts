import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-formulario-reactivo',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './formulario-reactivo.html',
  styleUrl: './formulario-reactivo.css',
})
export class FormularioReactivo implements OnInit {

  formulario!: FormGroup;

  ngOnInit(): void {
    this.formulario = new FormGroup({
      nombre: new FormControl('', [Validators.required]),
      apellidos: new FormControl('', [Validators.required])
    });
  }

  saludar() {
    if (this.formulario.valid) {
      const nombre = this.formulario.get('nombre')?.value;
      alert(`Hola ${nombre}`);
    }
  }
}