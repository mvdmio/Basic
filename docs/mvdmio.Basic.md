# mvdmio.Basic

Small .NET utility library, published as the `mvdmio.Basic` NuGet package. Provides time abstractions, common extensions, async helpers, and URL utilities.

## Table of Contents

- [Architecture Overview](#architecture-overview)
- [Package](#package)
- [Registration](#registration)
- [Time Abstractions](#time-abstractions)
- [Extensions](#extensions)
- [Utilities](#utilities)
- [Key File Locations](#key-file-locations)

---

## Architecture Overview

`mvdmio.Basic` has one package dependency: `Microsoft.Extensions.DependencyInjection.Abstractions`, for `AddBasic()`. `JetBrains.Annotations` is used at compile time only.

```
mvdmio.Basic
├── Time/           ← IClock, ICalendar abstractions + SystemClock, SystemCalendar
├── Extensions/     ← C# 14 extension members for DateTime, string, Uri, DirectoryInfo, etc.
├── Utils/          ← UrlUtil (URL normalization/classification)
└── AsyncHelper     ← Run async code in sync contexts
```

---

## Package

Published to nuget.org as `mvdmio.Basic` for `net8.0`, `net9.0`, and `net10.0`. Versions:

- **0.1.0**: first release, from the suite ([michielvandermeer/mvdmio-suite#3](https://github.com/michielvandermeer/mvdmio-suite/issues/3)).
- **0.2.0**: removed `Combine(DirectoryInfo[])`, which returned the last directory instead of joining the paths ([michielvandermeer/mvdmio-suite#268](https://github.com/michielvandermeer/mvdmio-suite/issues/268)).
- **0.2.1**: first release from [mvdmio/Basic](https://github.com/mvdmio/Basic). The package links to the repository and carries Source Link ([michielvandermeer/mvdmio-suite#267](https://github.com/michielvandermeer/mvdmio-suite/issues/267)).

Releasing:

- **Release**: raise `Version` in `src/mvdmio.Basic/mvdmio.Basic.csproj`, add the version above, and push to `main`.
- **Workflow**: `publish nuget` (`.github/workflows/publish-nuget.yml`) runs on a `main` push that changes `src/mvdmio.Basic/**`. It runs the unit tests, packs, pushes to nuget.org, and creates the GitHub release `v<version>`.
- **No version change**: the push skips a version that already exists on nuget.org, and the release step skips a tag that already exists, so the run stays green.
- **Suite**: the suite pins `mvdmio.Basic` in its central package versions. A new version reaches the suite when the suite raises its pin.
- **Doc comments**: a public member without one fails the build (CS1591 is an error in this project).

---

## Registration

```csharp
services.AddBasic();
```

Registers as singletons:
- `IClock` → `SystemClock`
- `ICalendar` → `SystemCalendar`

---

## Time Abstractions

### `IClock`

Abstracts the system clock. Inject instead of `DateTime.Now` directly.

| Member | Description |
|--------|-------------|
| `Now` | Current local `DateTimeOffset` |
| `UtcNow` | Current UTC `DateTimeOffset` |
| `Today` | Current `DateOnly` |
| `Delay(TimeSpan)` | Async delay |
| `Delay(int milliseconds)` | Async delay |

### `ICalendar`

High-level calendar operations. Inject this for week/ISO week number calculations.

| Method | Description |
|--------|-------------|
| `StartOfWeek()` | Start of current week (Monday by default) |
| `StartOfWeek(DayOfWeek)` | Start of current week with custom first day |
| `StartOfWeek(DateOnly)` | Start of the week containing a given date |
| `StartOfWeek(DateOnly, DayOfWeek)` | Same, with custom first day |
| `EndOfWeek()` | End of current week (Sunday by default) |
| `EndOfWeek(DayOfWeek)` | End of current week with custom first day |
| `EndOfWeek(DateOnly)` | End of the week containing a given date |
| `EndOfWeek(DateOnly, DayOfWeek)` | Same, with custom first day |
| `IsoWeekNumber()` | ISO 8601 week number for today |
| `IsoWeekNumber(DateOnly)` | ISO 8601 week number for a given date |
| `IsoWeekNumber(DateOnly, Calendar)` | Same, with explicit calendar |

---

## Extensions

All extension methods use **C# 14 `extension(...)` syntax** unless noted otherwise.

### `DateTimeExtensions`

Extensions on `DateTime`:

| Method | Description |
|--------|-------------|
| `StartOfDay` | `00:00:00.000` |
| `EndOfDay` | `23:59:59.999` |
| `StartOfWeek` | Monday `00:00:00` |
| `EndOfWeek` | Sunday `23:59:59.999` |
| `StartOfMonth` | First day of month, `00:00:00` |
| `EndOfMonth` | Last day of month, `23:59:59.999` |
| `StartOfYear` | January 1, `00:00:00` |
| `EndOfYear` | December 31, `23:59:59.999` |
| `WeekNumber` | ISO 8601 week number |
| `Floor(TimeSpan?)` | Truncates to nearest interval |

### `DateTimeOffsetExtensions`

Extensions on `DateTimeOffset`:

| Method | Description |
|--------|-------------|
| `StartOfDay` | `00:00:00.000` (preserves offset) |
| `EndOfDay` | `23:59:59.999` (preserves offset) |
| `Floor(TimeSpan?)` | Truncates to nearest interval |

### `StringExtensions`

Traditional static extension on `string`:

| Method | Description |
|--------|-------------|
| `Capitalize()` | Uppercases first character; null-safe (returns `null` for `null`) |

### `EnumerableExtensions`

Traditional static extensions on `IEnumerable<T>`:

| Method | Description |
|--------|-------------|
| `WithIndex<T>()` | Returns `(T item, int index)` tuples |
| `ToJson<T>()` | Serializes to JSON string |

### `HashExtensions`

Extensions on `string` and `byte[]`:

| Method | Description |
|--------|-------------|
| `Sha256(this string?)` | Returns Base64-encoded SHA-256 hash |
| `Sha256(this byte[])` | Returns SHA-256 hash as `byte[]` |
| `Sha512(this string?)` | Returns Base64-encoded SHA-512 hash |

### `QueueExtensions`

C# 14 generic extension on `Queue<T>`:

| Method | Description |
|--------|-------------|
| `EnqueueRange<T>(IEnumerable<T>)` | Enqueues all items from a sequence |

### `UriExtensions`

C# 14 extensions on `Uri`:

| Member | Description |
|--------|-------------|
| `RootDomain` | Extracts root domain; handles IPs and ccTLDs (e.g. `co.uk`) |
| `RootDomainEquals(Uri)` | Compares root domains |
| `AbsoluteUriBase` | URI without query string and fragment |
| `NormalizedAbsoluteUri` | Lowercase scheme+host, removes default ports, strips trailing slash, keeps query |

### `DirectoryInfoExtensions`

C# 14 extensions on `DirectoryInfo`:

| Method | Description |
|--------|-------------|
| `RecursiveCreate()` | Creates directory and all parents |
| `ForceDelete()` | Clears read-only attributes recursively, then deletes |
| `Combine(string[])` | Combines path segments, returns `DirectoryInfo` |

### `FileInfoExtensions`

C# 14 extension on `FileInfo`:

| Method | Description |
|--------|-------------|
| `ReadAllTextAsync(CancellationToken)` | Reads file contents; throws `FileNotFoundException` if missing |

---

## Utilities

### `AsyncHelper`

Runs async code synchronously. Use only when a sync context is unavoidable (e.g. legacy interfaces).

```csharp
var result = AsyncHelper.RunSync(() => SomeAsyncMethod());
AsyncHelper.RunSync(() => SomeAsyncVoidMethod());
```

Silently swallows `ThreadAbortException` and `TaskCanceledException`.

### `UrlUtil`

Static helper for URL classification and normalization.

| Method | Description |
|--------|-------------|
| `IsLocal(string)` | Returns `true` if URL starts with `/` or `./` |
| `Normalize(string?)` | Prepends `https://` if bare domain; strips trailing slashes |

---

## Key File Locations

| File | Description |
|------|-------------|
| `src/mvdmio.Basic/ServiceProviderExtension.cs` | `AddBasic()` registration |
| `src/mvdmio.Basic/AsyncHelper.cs` | Sync-over-async helper |
| `src/mvdmio.Basic/Time/` | `IClock`, `ICalendar`, `SystemClock`, `SystemCalendar` |
| `src/mvdmio.Basic/Extensions/` | All extension methods |
| `src/mvdmio.Basic/Utils/UrlUtil.cs` | URL normalization/classification |
