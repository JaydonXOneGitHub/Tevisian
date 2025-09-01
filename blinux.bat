REM blinux stands for "build for linux"
dotnet publish -sc -r linux-x64 -p:DefineConstants="LINUX"