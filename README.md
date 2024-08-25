# eye-saver

A Windows Utility that blanks the screen for 20 seconds every 20 minutes to promote eye health.

## Prerequisites
Install Inno Setup on your pc, and put it's bin file into the `%PATH%` environment variable.

## To build locally
```
run `build.bat`
```
This creates a Windows installer called `eyesaver-installer.exe`.

## To build and release on github
Create a tag on the repo, and push to the github server
```
git tag v1.0.1
git push origin v1.0.1
```
This creates a new release in this repo.