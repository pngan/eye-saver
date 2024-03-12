@echo off
dotnet publish -r win-x64
move /y bin\Release\net8.0-windows\win-x64 package
copy eye-saver.ico package
del /q package\publish

rem the following line requiries Inno Setup to be installed and on the path
ISCC.exe /O. setup.iss
