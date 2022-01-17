﻿
using Dotify.Core.Artists.Entities;

namespace Dotify.Core.Artists.Queries;

public interface IGetArtistsQuery
{
    Task<IEnumerable<Artist>> ExecuteAsync();
}
