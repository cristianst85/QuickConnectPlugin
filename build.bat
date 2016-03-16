@echo off

set KEEPASS_PATH="C:\Program Files (x86)\KeePass Password Safe 2\KeePass.exe"
set PROJECT_PATH=%~dp0
set SOURCE_PATH=%PROJECT_PATH%QuickConnectPlugin

cd /d "%PROJECT_PATH%"

echo Cleaning project directory...
IF EXIST .\QuickConnectPlugin\bin\ (
	rmdir /S /Q .\QuickConnectPlugin\bin\
)
IF EXIST .\QuickConnectPlugin\obj\ (
	rmdir /S /Q .\QuickConnectPlugin\obj\
)

echo Building PLGX file...
%KEEPASS_PATH% --plgx-prereq-net:3.5 --plgx-create "%SOURCE_PATH%"

IF NOT EXIST build (
	mkdir build
)

echo Moving PLGX file to build directory...
move /Y QuickConnectPlugin.plgx .\build\

echo Done.
pause