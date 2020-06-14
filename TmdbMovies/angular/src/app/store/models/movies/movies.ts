import { ABP } from '@abp/ng.core';
export namespace Movies {
    export interface State {
        movies: Response;
    }

    export interface Response {
        items: Movie[];
        totalCount: number;
    }

    export interface MoviesQueryParams extends ABP.PageQueryParams {
        filterText?: string;
        popularityMax?: number;
        popularityMin?: number;
        voteCountMax?: number;
        voteCountMin?: number;
        video?: boolean;
        posterPath?: string;
        movieIdMax?: number;
        movieIdMin?: number;
        adult?: boolean;
        backdropPath?: string;
        originalLanguage?: string;
        originalTitle?: string;
        title?: string;
        voteAverageMax?: number;
        voteAverageMin?: number;
        overview?: string;
        releaseDateMax?: string;
        releaseDateMin?: string;
    }

    export interface Movie {
        id: string;
        popularity: number;
        voteCount: number;
        video: boolean;
        posterPath: string;
        movieId: number;
        adult: boolean;
        backdropPath: string;
        originalLanguage: string;
        originalTitle: string;
        title: string;
        voteAverage: number;
        overview: string;
        releaseDate: string;
        youtubeTrailerId: string;
    }

    export interface MovieCreateUpdateDto {
        popularity: number;
        voteCount: number;
        video: boolean;
        posterPath: string;
        movieId: number;
        adult: boolean;
        backdropPath: string;
        originalLanguage: string;
        originalTitle: string;
        title: string;
        voteAverage: number;
        overview: string;
        releaseDate: string;
    }
}
