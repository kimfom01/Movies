﻿using Movies.Context;
using Movies.Models;

namespace Movies.Repositories;

public class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
    }

    public override async Task AddEntities(IEnumerable<Movie> entities)
    {
        var oldMovies = base.GetEntities();

        await base.DeleteEntities(oldMovies);

        await base.AddEntities(entities);
    }
}