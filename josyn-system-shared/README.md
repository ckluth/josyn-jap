# JOSYN.System.Shared

**JOSYN.System.Shared** enthält die gemeinsamen Bibliotheken der **JOSYN** (*JobSystem Next*)
Systemschicht — als eigenständige NuGet-Pakete, die von beiden EXE-Prozessen
(`JobHost` und `JAPServer`) genutzt werden.

---

## Pakete

| Paket | Rolle | Abhängigkeiten |
|---|---|---|
| [`JOSYN.System.Shared.Contract`](JOSYN.System.Shared.Contract/) | Applikationsvertrag (JAP) zwischen JobHost und JAPServer | ResultPattern |
| [`JOSYN.System.Shared.Log`](JOSYN.System.Shared.Log/) | Prozess-lokaler Datei-Logger für alle JOSYN-EXE-Prozesse | ResultPattern |

### Abhängigkeitskette

```
JOSYN.Foundation.ResultPattern
        ↑                ↑
JOSYN.System.      JOSYN.System.
Shared.Contract    Shared.Log
```

`Contract` und `Log` kennen sich gegenseitig nicht.

---

## Lokales Arbeiten

```
.local-build\build.cmd          # Release-Build
.local-build\build.cmd Debug    # Debug-Build
.local-build\test.cmd           # Tests ausführen
.local-build\pack.cmd           # NuGet-Pakete → ..\..\local-packages\
```

**Reihenfolge beim ersten Setup** (wegen Abhängigkeit auf ResultPattern):

```
1. josyn-foundation\josyn-foundation-result-pattern\  → pack
2. josyn-system\josyn-system-shared\                  → pack
```

---

## Status

Reifer PoC — Milestone 1. Die Pakete sind intern produktionsreif;
die `preview`-Kennzeichnung spiegelt den noch offenen Abnahme-Prozess wider.
Bekannte PoC-Einschränkungen sind in [`POC-HACKS.md`](POC-HACKS.md) dokumentiert.

---

*JOSYN.System.Shared — © 2026 HAEVG AG — MIT License*
