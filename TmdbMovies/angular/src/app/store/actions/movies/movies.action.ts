import { Movies } from '../../models';

export class GetMovies {
    static readonly type = '[Movies] Get';
    constructor(public payload?: Movies.MoviesQueryParams) { }
}

export class CreateUpdateMovie {
    static readonly type = '[Movies] Create Update Movie';
    constructor(public payload: Movies.MovieCreateUpdateDto, public id?: string) { }
}

export class DeleteMovie {
    static readonly type = '[Movies] Delete';
    constructor(public id: string) { }
}

export class GetYoutubeTrailer {
    static readonly type = '[Movies] Get Trailer';

    constructor(public moviedId: string) {
    }
}