@echo off
dotnet publish -r win-x64
move /y bin\Release\net8.0-windows\win-x64 package
copy eye-saver.ico package
cd package
del /q publish

