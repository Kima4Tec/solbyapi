using API.Controllers;              // Controller-klassen vi tester
using Application.Dtos.Movies;      // DTO'er til movies
using Application.Interfaces;       // Her ligger IMovieService
using Microsoft.AspNetCore.Mvc;     // Bruges til ActionResult-typer (OkObjectResult, NotFoundResult)
using NSubstitute;                  // Bruges til at mocke interfaces og services

public class MoviesControllerTests
{
    // Mock af IMovieService vha. NSubstitute
    private readonly IMovieService _movieService = Substitute.For<IMovieService>();

    // Controller vi vil teste
    private readonly MoviesController _controller;

    // Constructor: vi initialiserer controlleren med den mockede service
    public MoviesControllerTests()
    {
        _controller = new MoviesController(_movieService);
    }

    // Test af GET /api/movies
    [Fact]  // xUnit attribut, markerer en test-metode
    public async Task Get_ShouldReturnAllMovies()
    {
        // Arrange: forbered testdata og hvad mocken skal returnere
        var movies = new List<MovieReadDto>
        {
            new MovieReadDto { Id = Guid.NewGuid(), Title = "Movie 1" },
            new MovieReadDto { Id = Guid.NewGuid(), Title = "Movie 2" }
        };

        // Mock: Når GetMoviesAsync() kaldes, returner testlisten
        _movieService.GetMoviesAsync().Returns(movies);

        // Act: udfør selve handlingen
        var result = await _controller.Get();

        // Assert: tjek at vi fik et OkObjectResult
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        // Assert: tjek at resultatet indeholder en liste af MovieReadDto
        var returnedMovies = Assert.IsAssignableFrom<List<MovieReadDto>>(okResult.Value);

        // Assert: tjek at der er præcis 2 elementer
        Assert.Equal(2, returnedMovies.Count);
    }

    // Test af GET /api/movies/{id} hvor filmen ikke findes
    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenMissing()
    {
        // Arrange: en tilfældig id som ikke findes
        var id = Guid.NewGuid();

        // Mock: GetMovieAsync returnerer null for denne id
        _movieService.GetMovieAsync(id).Returns((MovieReadDto?)null);

        // Act: kald controller-metoden
        var result = await _controller.Get(id);

        // Assert: tjek at resultatet er NotFoundResult
        Assert.IsType<NotFoundResult>(result.Result);
    }
}
