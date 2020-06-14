import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Component, TemplateRef, TrackByFunction, ViewChild, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Select, Store } from '@ngxs/store';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { MoviesService } from './movies.service';
import { MoviesState } from '../../store/states';
import { Movies } from '../../store/models';
import { GetMovies, CreateUpdateMovie, DeleteMovie } from '../../store/actions';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import snq from 'snq';
import * as _ from 'lodash';

@Component({
  selector: 'app-movies',
  providers: [{ provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss'],
})

export class MoviesComponent implements OnInit {
  @Select(MoviesState.getMovies)
  data$: Observable<Movies.Movie[]>;

  @Select(MoviesState.getTotalCount)
  totalCount$: Observable<number>;

  @ViewChild('modalContent', { static: false })
  modalContent: TemplateRef<any>;

  form: FormGroup;

  selected: Movies.Movie;

  pageQuery: Movies.MoviesQueryParams = { maxResultCount: 10 };

  isModalVisible: boolean;

  isAdvancedFiltersHidden: boolean = true;

  loading: boolean = false;

  modalBusy: boolean = false;

  sortOrder: string = '';

  sortKey: string = '';



  trackByFn: TrackByFunction<AbstractControl> = (index, item) => Object.keys(item)[0] || index;

  get roleGroups(): FormGroup[] {
    return snq(() => (this.form.get('roleNames') as FormArray).controls as FormGroup[], []);
  }

  constructor(
    private confirmationService: ConfirmationService,
    public moviesService: MoviesService,
    private fb: FormBuilder,
    private store: Store,
  ) { }

  ngOnInit() {
    this.get();
  }

  onSearch(value) {
    this.pageQuery.filterText = value;
    this.get();
  }

  buildForm() {
    this.form = this.fb.group({
      popularity: [this.selected.popularity || '', []],
      voteCount: [this.selected.voteCount || '', []],
      video: [this.selected.video || false, []],
      posterPath: [this.selected.posterPath || '', []],
      movieId: [this.selected.movieId || '', []],
      adult: [this.selected.adult || false, []],
      backdropPath: [this.selected.backdropPath || '', []],
      originalLanguage: [this.selected.originalLanguage || '', []],
      originalTitle: [this.selected.originalTitle || '', []],
      title: [this.selected.title || '', []],
      voteAverage: [this.selected.voteAverage || '', []],
      overview: [this.selected.overview || '', []],
      releaseDate: [this.selected.releaseDate ? new Date(this.selected.releaseDate) : null, []],

    });
  }

  openModal() {
    this.buildForm();
    this.isModalVisible = true;
  }

  onAdd() {
    this.selected = {

    } as Movies.Movie;
    this.openModal();
  }

  onEdit(id: string) {
    this.moviesService
      .getById(id)
      .subscribe((state: Movies.Movie) => {
        this.selected = state;
        this.openModal();
      });
  }

  save() {
    if (!this.form.valid) return;
    this.modalBusy = true;

    this.store
      .dispatch(new CreateUpdateMovie({
        ...this.form.value,
      }, this.selected.id)
      )
      .pipe(finalize(() => (this.modalBusy = false)))
      .subscribe(() => {
        this.isModalVisible = false;
        this.get();
      });
  }

  delete(id: string) {
    this.confirmationService
      .warn('::DeleteConfirmationMessage', '::AreYouSure', {})
      .subscribe((status: Confirmation.Status) => {
        if (status === Confirmation.Status.confirm) {
          this.store.dispatch(new DeleteMovie(id)).subscribe(() => this.get())
        }
      });
  }

  onPageChange(page: number) {
    this.pageQuery.skipCount = (page - 1) * this.pageQuery.maxResultCount;

    this.get();
  }

  get() {
    this.loading = true;
    let filter = Object.assign({}, this.pageQuery);
    filter.releaseDateMin = filter.releaseDateMin ? new Date(filter.releaseDateMin).toISOString() : "";
    filter.releaseDateMax = filter.releaseDateMax ? new Date(filter.releaseDateMax).toISOString() : "";

    this.store
      .dispatch(new GetMovies(filter))
      .pipe(finalize(() => (this.loading = false)))
      .subscribe(result=>{
        console.log(result);
        console.log(this.data$);
      });
  }

  getYoutubeTrailer(movie: Movies.Movie) {
    if(movie.youtubeTrailerId) return;
    this.moviesService
    .getYoutubeTrailer(movie.movieId.toString())
    .subscribe((youtubeId: string) => {
      movie.youtubeTrailerId = youtubeId;
    });
  }
}
