# eye-saver

A Windows Utility that blanks the screen for 20 seconds every 20 minutes to promote eye health.

## Download and Install
Download the installer executable from the Releases section of this repository. When the installer is run, Windows will issue a scary message about the executable being unsafe. This is because the executable has not been digitally signed. Ignore this message by pressing "More Info".

## Local build

The project can be built on a local Windows machine.

### Prerequisites
Install Inno Setup on your pc, and put it's bin file into the `%PATH%` environment variable.

### To build locally
```
run `build.bat`
```
This creates a Windows installer called `eyesaver-installer.exe`.

## Build and release on github
Create a tag on the repo, and push to the github server. For example to release `v1.0.1` do the following:
```
git tag v1.0.1
git push origin v1.0.1
```
This creates a release called `v1.0.1` in this repo.