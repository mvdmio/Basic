# mvdmio.Basic

Small utilities for .NET applications: an injectable clock and calendar, time zone helpers, extension members for common types, and a few static helpers.

## Usage

### Install the NuGet package

```
dotnet add package mvdmio.Basic
```

The extension members use C# 14 extension blocks. A consuming project needs the .NET 10 SDK and `LangVersion` 14 or later, also when it targets `net8.0` or `net9.0`.

### Register the services

```csharp
services.AddBasic();
```

This registers two singletons:

- `IClock` → `SystemClock`: the current time (`Now`, `UtcNow`, `Today`) and `Delay`. Inject it instead of reading `DateTime.Now`, so tests can supply their own clock.
- `ICalendar` → `SystemCalendar`: start and end of the week, and ISO 8601 week numbers.

## Helpers

- **Time**: `TimeZones` finds a time zone by id and converts a `DateTime` to UTC by its `Kind`.
- **Extensions** (`mvdmio.Basic.Extensions`): members for `DateTime`, `DateTimeOffset`, `string`, `IEnumerable<T>`, `Queue<T>`, `Uri`, `DirectoryInfo` and `FileInfo`, plus SHA-256 and SHA-512 hashing.
- **`AsyncHelper`**: runs async code synchronously, for the places where a synchronous call cannot be avoided.
- **`UrlUtil`**: tells whether a URL is local (starts with `/` or `./`) and normalizes a bare domain to an `https://` URL.

# Contact

For questions or issues, please contact me at [michiel@mvdm.io](mailto:michiel@mvdm.io).
