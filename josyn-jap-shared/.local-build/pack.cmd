@echo off
CHCP 1252
cd /d "%~dp0.."

dotnet pack JOSYN.Jap.Shared.Contract --output "..\..\local-packages"
if %ERRORLEVEL% neq 0 (
    echo [FEHLER] Pack JOSYN.Jap.Shared.Contract fehlgeschlagen.
    exit /b %ERRORLEVEL%
)

echo.
echo [OK] Paket erfolgreich gepackt.
REM pause
