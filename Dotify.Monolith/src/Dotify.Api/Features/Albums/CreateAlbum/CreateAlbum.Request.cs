using System.ComponentModel.DataAnnotations;

namespace Dotify.Api.Features.Albums;

public class CreateAlbumRequest
{
    [Required]
    public string Title { get; set; }
    public ReleaseDate ReleaseDate { get; set; }

    public CreateAlbumRequest(string title, ReleaseDate releaseDate)
    {
        Title = title;
        ReleaseDate = releaseDate;
    }
}

public class ReleaseDate
{
    [DefaultValue(2022)]
    public int Year { get; set; }

    [DefaultValue(1)]
    public int Month { get; set; }

    [DefaultValue(1)]
    public int Day { get; set; } = 1;

    public override string ToString()
    {
        return $"{Year}-{Month}-{Day}";
    }
}