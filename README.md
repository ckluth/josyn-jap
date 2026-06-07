# josyn-jap

**josyn-jap** contains the protocol contracts of the **JOSYN** (*JobSystem Next*)
system layer — the shared NuGet packages that both JAP parties depend on.

> `JOSYN.Jap.JAPServer` (the EXE) was relocated to `josyn-backend` per ADR-004.
> The protocol contract (`Contract`) remains here as the single source of truth.
> `JOSYN.Jap.Shared.Log` was relocated to `JOSYN.Commons.Log` per ADR-008.

---

## Building blocks

| Component | Type | Role | Dependencies |
|---|---|---|---|
| [`JOSYN.Jap.Shared.Contract`](josyn-jap-shared/README.md) | NuGet | Application contract (JAP) between JobHost and JAPServer | ResultPattern |

### Dependency chain

```
JOSYN.Foundation.ResultPattern
        ↑
Shared.Contract
```

---

## Local development

Each sub-repo is self-contained. From the respective directory:

```
.local-build\build.cmd      # release build
.local-build\test.cmd       # run tests
.local-build\pack.cmd       # NuGet packages → ..\..\local-packages\
```

Or via the root scripts (all sub-repos at once):

```
.local-build\build.cmd      # release build (all sub-repos)
.local-build\test.cmd       # tests (all sub-repos)
.local-build\pack.cmd       # NuGet packages (all sub-repos)
.local-build\all.cmd        # clean → build → test → pack
```

**Prerequisite:** `josyn-foundation-result-pattern` must be packed first
(located in `..\..\local-packages\`).

---

## Status

Milestone 1. Packages are internally production-ready;
the `preview` label reflects the pending release process.

---

*JOSYN System — © 2026 HAEVG AG — MIT License*
