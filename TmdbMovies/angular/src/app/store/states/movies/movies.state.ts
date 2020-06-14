import { Injectable } from '@angular/core';
import { State, Action, StateContext, Selector } from '@ngxs/store';
import { GetMovies, CreateUpdateMovie, DeleteMovie, GetYoutubeTrailer } from '../../actions/movies/movies.action';
import { Movies } from '../../models/movies/movies';
import { MoviesService } from '../../../movies/movies/movies.service';
import { tap } from 'rxjs/operators';

@State<Movies.State>({
    name: 'MoviesState',
    defaults: { movies: {} } as Movies.State
})
@Injectable()
export class MoviesState {
    @Selector()
    static getMovies(state: Movies.State) {
        return state.movies.items || [];
    }

    @Selector()
    static getTotalCount(state: Movies.State): number {
        return state.movies.totalCount || 0;
    }

    constructor(private moviesService: MoviesService) { }

    @Action(GetMovies)
    get({ patchState }: StateContext<Movies.State>, { payload }: GetMovies) {
        return this.moviesService.get(payload).pipe(
            tap(moviesResponse => {
                patchState({
                    movies: moviesResponse,
                });
                console.log(moviesResponse);
            }),
        );
    }

    // @Action(GetYoutubeTrailer)
    // getYoutubeTrailerId({ patchState }: StateContext<string>, { moviedId }: GetYoutubeTrailer) {
    //     return this.moviesService.getYoutubeTrailer(moviedId).pipe(
    //         tap(youtubeIdResponse => {
    //             patchState({
    //                 movies: moviesResponse,
    //             });
    //         }),
    //     );
    // }

    @Action(CreateUpdateMovie)
    save(ctx: StateContext<Movies.State>, action: CreateUpdateMovie) {
        let request;

        if (action.id) {
            request = this.moviesService.update(action.payload, action.id);
        } else {
            request = this.moviesService.create(action.payload);
        }

        return request;
    }

    @Action(DeleteMovie)
    delete(ctx: StateContext<Movies.State>, action: DeleteMovie) {
        return this.moviesService.delete(action.id);
    }
}
