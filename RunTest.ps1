Param(
    [String]$TestPlatform = "editmode",
    [Boolean]$WithGraphics = $true
)

$GraphicOption = $WithGraphics ? "" : "-nographics"
$OutputFilePrefix = $TestPlatform + ($WithGraphics ? "" : "-nographics")
Write-Output "Running tests with $OutputFilePrefix..."
$WithGraphicsResult = Start-Process -FilePath 'C:\Program Files\Unity\Hub\Editor\2022.3.15f1\Editor\Unity.exe' `
    -NoNewWindow `
    -Wait `
    -PassThru `
    -ArgumentList " `
        -batchmode `
        $GraphicOption `
        -projectPath . `
        -runTests -testPlatform $TestPlatform `
        -testResults Logs/$OutputFilePrefix.xml `
        -logFile Logs/$OutputFilePrefix.log"

if ($WithGraphicsResult.ExitCode -ne 0) {
    throw "Tests failed with $OutputFilePrefix"
}
