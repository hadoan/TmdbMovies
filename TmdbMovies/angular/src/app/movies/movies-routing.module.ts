import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PermissionGuard } from '@abp/ng.core';
import { MoviesComponent } from './movies/movies.component';

const routes: Routes = [
  {
    path: '',
    children: [{ path: '', component: MoviesComponent }],
    // canActivate: [PermissionGuard],
    data: { requiredPolicy: 'TmdbMovies.Movies' },
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class MoviesRoutingModule { }
