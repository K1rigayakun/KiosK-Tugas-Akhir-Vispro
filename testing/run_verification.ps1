$ErrorActionPreference = 'Stop'
$root = 'M:\Smester 5\VISPRO PRAK\VisproPrakProjectAkhir'
$proj = Join-Path $root 'VisproPrakProjectAkhir.vbproj'
$exe  = Join-Path $root 'bin\Debug\net10.0-windows\VisproPrakProjectAkhir.exe'
$report = Join-Path $root 'testing\self_test_report.txt'
$shotDir = Join-Path $root 'testing\screenshoot'

Write-Host '=== 1. BUILD (Option Strict On) ==='
dotnet build $proj -c Debug
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

Write-Host '=== 2. SELF-TEST LOGIKA INTI ==='
$p1 = Start-Process -FilePath $exe -ArgumentList @('--self-test', "`"$report`"") -Wait -PassThru
Get-Content $report
if ($p1.ExitCode -ne 0) { exit $p1.ExitCode }

Write-Host '=== 3. CAPTURE VISUAL SCREENSHOTS ==='
if (Test-Path $shotDir) { Remove-Item "$shotDir\*.png" -Force -ErrorAction SilentlyContinue }
$p2 = Start-Process -FilePath $exe -ArgumentList @('--capture-tour', "`"$shotDir`"") -Wait -PassThru
if ($p2.ExitCode -ne 0) { exit $p2.ExitCode }

Get-ChildItem $shotDir -Filter *.png | Sort-Object Name | Select-Object Name, Length | Format-Table -AutoSize
