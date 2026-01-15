using Xunit;
using NSubstitute;
using Application.Interfaces;
using Application.Dtos.Movies;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MoviesControllerTests
{
    private readonly IMovieService _movieService = Substitute.For<IMovieService>();
    private readonly MoviesController _controller;

    public MoviesControllerTests()
    {
        _controller = new MoviesController(_movieService);
    }

    [Fact]
    public async Task Get_ShouldReturnAllMovies()
    {
        // Arrange
        var movies = new List<MovieReadDto>
        {
            new MovieReadDto { Id = Guid.NewGuid(), Title = "Movie 1" },
            new MovieReadDto { Id = Guid.NewGuid(), Title = "Movie 2" }
        };

        _movieService.GetMoviesAsync().Returns(movies);

        // Act
        var result = await _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedMovies = Assert.IsAssignableFrom<List<MovieReadDto>>(okResult.Value);
        Assert.Equal(2, returnedMovies.Count);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenMissing()
    {
        var id = Guid.NewGuid();
        _movieService.GetMovieAsync(id).Returns((MovieReadDto?)null);

        var result = await _controller.Get(id);

        Assert.IsType<NotFoundResult>(result.Result);
    }
}
