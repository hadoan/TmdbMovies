import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgbDatepickerModule, NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { MoviesRoutingModule } from './movies-routing.module';
import { MoviesComponent } from './movies/movies.component';

@NgModule({
  declarations: [MoviesComponent],
  imports: [
    CommonModule,
    SharedModule,
    MoviesRoutingModule,
    NgbCollapseModule,
    NgbDatepickerModule
  ]
})

export class MoviesModule { }
