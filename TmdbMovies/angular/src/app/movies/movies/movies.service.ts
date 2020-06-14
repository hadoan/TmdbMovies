import { Injectable } from '@angular/core';
import { RestService, ABP } from '@abp/ng.core';
import { Movies } from '../../store/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class MoviesService {
    apiName = 'Default';

    constructor(private restService: RestService) { }

    get(params = {} as Movies.MoviesQueryParams): Observable<Movies.Response> {
        return this.restService.request<void, Movies.Response>({
            method: 'GET',
            url: '/api/app/movie',
            params
        },
            { apiName: this.apiName });
    }

    create(createMovieInput: Movies.MovieCreateUpdateDto): Observable<Movies.Movie> {
        return this.restService.request<Movies.MovieCreateUpdateDto, Movies.Movie>({
            method: 'POST',
            url: '/api/app/movie',
            body: createMovieInput
        },
            { apiName: this.apiName });
    }

    getYoutubeTrailer(movieId: string): Observable<string> {
        return this.restService.request<void, string>({
            method: 'GET',
            url: `/api/app/movie/gettrailer/${movieId}`
        },
            { apiName: this.apiName });
    }

    getById(id: string): Observable<Movies.Movie> {
        return this.restService.request<void, Movies.Movie>({
            method: 'GET',
            url: `/api/app/movie/${id}`
        },
            { apiName: this.apiName });
    }

    update(createMovieInput: Movies.MovieCreateUpdateDto, id: string): Observable<Movies.Movie> {
        return this.restService.request<Movies.MovieCreateUpdateDto, Movies.Movie>({
            method: 'PUT',
            url: `/api/app/movie/${id}`,
            body: createMovieInput
        },
            { apiName: this.apiName });
    }

    delete(id: string): Observable<void> {
        return this.restService.request<void, void>({
            method: 'DELETE',
            url: `/api/app/movie/${id}`
        },
            { apiName: this.apiName });
    }
}
