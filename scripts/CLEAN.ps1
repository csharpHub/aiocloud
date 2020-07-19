Set-Location ..

Remove-Item -Recurse -Force AioCloud\bin
Remove-Item -Recurse -Force AioCloud\obj
Remove-Item -Recurse -Force AioCloud.*\bin
Remove-Item -Recurse -Force AioCloud.*\obj

Set-Location scripts
exit 0
