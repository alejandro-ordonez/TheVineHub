# run_app.ps1
# Usage: .\run_app.ps1 -ApiUrl "http://localhost:5000" -Device "web-server" -Port 8080

param (
    [string]$ApiUrl = "http://localhost:5000",
    [string]$Device = "",
    [int]$Port = 0
)

$deviceArgs = if ($Device) { "-d $Device" } else { "" }
$portArgs = if ($Port -gt 0) { "--web-port $Port" } else { "" }

Write-Host "Starting JM Ministry App" -ForegroundColor Cyan
Write-Host "API_BASE_URL: $ApiUrl" -ForegroundColor Gray
if ($Device) { Write-Host "Device: $Device" -ForegroundColor Gray }
if ($Port -gt 0) { Write-Host "Port: $Port" -ForegroundColor Gray }

Invoke-Expression "flutter run $deviceArgs $portArgs --dart-define=API_BASE_URL=$ApiUrl"
