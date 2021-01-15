param([string]$NewVersion)

Get-ChildItem -Include AssemblyInfo.cs -Recurse | ForEach-Object {
	$_.IsReadOnly = $false
        (Get-Content -Path $_) -replace '(?<=Assembly(?:File)?Version\(")[^"]*(?="\))', $NewVersion |Set-Content -Path $_
}