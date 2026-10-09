# mvdmio.Basic

Small .NET utility library — injectable clock and calendar abstractions, extension members for dates, strings, collections, hashing, URIs and the file system, and URL and sync-over-async helpers. Shipped as the `mvdmio.Basic` NuGet package (MIT) for `net8.0;net9.0;net10.0`. Work style: telegraph, low-filler, direct.

## Essentials

- **Build:** `dotnet build`
- **Test:** `dotnet test`
- Before finishing any change, confirm it builds (`dotnet build`) then tests pass (`dotnet test`). Run these **sequentially, never in parallel** — overlapping `dotnet` runs cause file locks/deadlocks.
- This is a published NuGet library: treat the public API as a contract. No backward-compat shims and no API changes unless intentional and called out.

## Universal rules

- **Never branch.** Work on `main` — when asked to commit/push, commit on `main` and push directly. Only create a branch when the user explicitly asks for one by name.
- Search early. Quote exact errors. If blocked or the design is unclear, ask.

## Agent skills

### Issue tracker

Work is tracked as GitHub Issues in `mvdmio/Basic`. See `.agents/refs/tracker.md`.
