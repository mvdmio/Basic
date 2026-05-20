# mvdmio.Basic

Foundational utility library shared across all services. Provides time abstractions, common extensions, async helpers, and URL utilities.

## Table of Contents

- [Architecture Overview](#architecture-overview)
- [Registration](#registration)
- [Time Abstractions](#time-abstractions)
- [Extensions](#extensions)
- [Utilities](#utilities)
- [Exceptions](#exceptions)
- [Key File Locations](#key-file-locations)

---

## Architecture Overview

`mvdmio.Basic` is a dependency-free utility library (no external NuGet packages). It is a prerequisite for `mvdmio.ASP`, `mvdmio.Email`, and `mvdmio.ASP.Razor`.

```
mvdmio.Basic
├── Time/           ← IClock, ICalendar abstractions + SystemClock, SystemCalendar
├── Extensions/     ← C# 14 extension members for DateTime, string, Uri, DirectoryInfo, etc.
├── Utils/          ← UrlUtil (URL normalization/classification)
├── Exceptions/     ← ApplicationException base
└── AsyncHelper     ← Run async code in sync contexts
```

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
| `DistinctBy<T, TKey>(Func<T, TKey>)` | Distinct by key selector |
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
| `Combine(DirectoryInfo[])` | Same, with `DirectoryInfo` arguments |

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

## Exceptions

| Class | Description |
|-------|-------------|
| `ApplicationException` | Base exception class. 3 constructors: `(message)`, `(message, inner)`, default |

---

## Key File Locations

| File | Description |
|------|-------------|
| `Libraries/src/mvdmio.Basic/ServiceProviderExtension.cs` | `AddBasic()` registration |
| `Libraries/src/mvdmio.Basic/AsyncHelper.cs` | Sync-over-async helper |
| `Libraries/src/mvdmio.Basic/Time/` | `IClock`, `ICalendar`, `SystemClock`, `SystemCalendar` |
| `Libraries/src/mvdmio.Basic/Extensions/` | All extension methods |
| `Libraries/src/mvdmio.Basic/Utils/UrlUtil.cs` | URL normalization/classification |
| `Libraries/src/mvdmio.Basic/Exceptions/ApplicationException.cs` | Base exception |
