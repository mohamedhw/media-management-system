# media-management-system
media-management-system

A self-hosted personal media library and cataloging system built with **ASP.NET Core** and **Clean Architecture**. DCL lets you track everything in your personal collection — movies, series, music, games, and images — along with the technical details of each file (quality, codec, storage location) and rich metadata (genres, tags, actors, directors, age ratings).

## Features

- **Unified media catalog** — a single `Media` entity covers movies, series, music, games, and images, with type-specific detail tables (`MovieDetail`, `SeriesDetail`, `MusicDetail`, `GameDetail`).
- **File-level tracking** — record file format, resolution/quality, frame rate mode, scan type, bitrate, and which physical `StorageDevice` a file lives on.
- **Rich metadata** — genres, tags, actors, directors, makers, labels, age ratings, and multi-language translations/subtitles per media item.
- **Filtering & search** — query your collection by title, media type, genre, tag, age rating, watch status, and release year range.
- **Lookup (LKP) management** — a dedicated endpoint for reading lookup/reference tables (genres, tags, formats, etc.) used throughout the app.
- **CQRS with MediatR** — commands and queries are cleanly separated for maintainability and testability.
- **OpenAPI docs** — interactive API reference via [Scalar](https://scalar.com/) in development mode.

## Tech stack

| Layer | Technology |
|---|---|
| API | ASP.NET Core Web API (.NET) |
| Application | MediatR (CQRS), custom DTOs |
| Domain | Plain C# entity classes |
| Persistence | Entity Framework Core (SQLite by default) |
| API docs | `Microsoft.AspNetCore.OpenApi` + Scalar UI |

## Architecture

The project follows **Clean Architecture** principles, split into four layers:

```
DCL.Domain          -> Entities (Media, MediaFile, Genre, Tag, Actor, ...)
DCL.Application     -> Commands, Queries, DTOs, interfaces (IApplicationDbContext)
DCL.Infrastructure  -> EF Core DbContext, migrations, persistence implementation
DCL.API             -> Controllers, Program.cs, HTTP concerns
```

Dependencies point inward: `API -> Application -> Domain`, with `Infrastructure` implementing the interfaces defined in `Application`. This keeps business logic independent of EF Core and ASP.NET Core.

### Domain model highlights

- `Media` is the aggregate root — every item in the library, regardless of type.
- Type-specific details (`MovieDetail`, `SeriesDetail`, `MusicDetail`, `GameDetail`) hang off `Media` via a one-to-one relationship, selected based on `MediaTypeId`.
- `MediaFile` records one or more physical files per media item, each tied to a `StorageDevice`, `FileFormat`, `Quality`, `ScanType`, and `FrameRateMode`.
- `MediaGenre` and `MediaTag` are many-to-many join entities with composite keys.
- Lookup ("LKP") entities — `Genre`, `Tag`, `Actor`, `Director`, `Maker`, `Label`, `Language`, `AgeRating`, `Quality`, `FileFormat`, `StorageDevice`, `ScanType`, `FrameRateMode`, `SourceType`, `DownloadSource` — back the dropdowns and filters used across the app.

## Getting started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (8.0 or later recommended)
- SQLite (bundled — no separate install needed) or another EF Core–supported database if you swap the provider

### Setup

```bash
# Clone the repo
git clone https://github.com/<your-username>/dcl.git
cd dcl

# Restore dependencies
dotnet restore

# Apply database migrations (creates dcl.db via SQLite)
dotnet ef database update

# Run the API
dotnet run --project DCL.API
```

The API will be available at the URL shown in the console output. In development, browse to `/scalar/v1` for interactive API documentation.

### Configuration

By default the app uses SQLite with `Data Source=dcl.db` (see `ApplicationDbContextFactory`). To point at a different database, update the connection string in `appsettings.json` and the provider registration in your Infrastructure DI setup.

CORS is currently configured to allow a local React dev server at `http://localhost:5173` — update the `AllowReactApp` policy in `Program.cs` if your frontend runs elsewhere.

## API overview

| Endpoint | Method | Description |
|---|---|---|
| `/api/media` | `POST` | Create a new media item (multipart form, supports cover image upload) |
| `/api/media/GETByFilter` | `POST` | Query media by title, type, genre, tag, rating, year range, etc. |
| `/api/media/GETDetails` | `POST` | Get full details for a single media item |
| `/api/media/{id}` | `PUT` | Update an existing media item, its type-specific detail, genres, and tags |
| `/api/lkps` | `POST` | Fetch lookup/reference table data |
| `/api/actor` | — | Actor endpoints (in progress) |

## Project status

This project is under active development. Some areas — such as full CRUD for series/music/game details and the Actor endpoints — are scaffolded but not yet complete.

## Contributing

Issues and pull requests are welcome. Please open an issue to discuss significant changes before submitting a PR.

## License

Add your preferred license here (e.g. MIT).
