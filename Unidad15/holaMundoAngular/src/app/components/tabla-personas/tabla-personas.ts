import { Component } from '@angular/core';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatSliderModule} from '@angular/material/slider';
import {MatDatepickerModule} from '@angular/material/datepicker';

@Component({
  selector: 'app-tabla-personas',
  imports: [MatProgressSpinnerModule, MatSliderModule, MatDatepickerModule],
  templateUrl: './tabla-personas.html',
  styleUrl: './tabla-personas.css',
})
export class TablaPersonas {

}
