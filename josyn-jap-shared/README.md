# JOSYN.Jap.Shared

**JOSYN.Jap.Shared** contains the shared libraries of the **JOSYN** (*JobSystem Next*)
system layer — as an independent NuGet package used by both EXE processes
(`JobHost` and `JAPServer`).

---

## Packages

| Package | Role | Dependencies |
|---|---|---|
| [`JOSYN.Jap.Contract`](JOSYN.Jap.Contract/README.md) | Application contract (JAP) between JobHost and JAPServer | ResultPattern |

> `JOSYN.Jap.Shared.Log` was relocated to `JOSYN.Commons.Log` per ADR-008.

### Dependency chain

```
JOSYN.Foundation.ResultPattern
        ↑
JOSYN.Jap.Contract
```

---

## Local development

```
.local-build\build.cmd          # release build
.local-build\build.cmd Debug    # debug build
.local-build\test.cmd           # run tests
.local-build\pack.cmd           # NuGet packages → ..\..\local-packages\
```

**First-time setup order** (due to dependency on ResultPattern):

```
1. josyn-foundation\josyn-foundation-result-pattern\  → pack
2. josyn-jap\josyn-jap-shared\                        → pack
```

---

## Status

Milestone 1. Package is internally production-ready;
the `preview` label reflects the pending release process.

---

*JOSYN.Jap.Shared — © 2026 HAEVG AG — MIT License*
