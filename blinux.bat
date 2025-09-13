REM blinux stands for "build for linux"
dotnet publish --self-contained -r linux-x64 -p:DefineConstants="LINUX"