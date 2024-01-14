import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'AzureCICDUI';
}

// jel moram pazit na default outputPath da se ne izvrši svaki put odnosno da ga moram prebacit u development config
//ne moram prebacit, to je default output ako nije specificirano

//što je sa production sourceMap? -> default je false na prod

