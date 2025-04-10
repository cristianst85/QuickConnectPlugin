@echo off

set PROJECT_PATH=%~dp0
set KEEPASS_PATH="%PROJECT_PATH%libs\KeePass.exe"
set SOURCE_PATH="%PROJECT_PATH%QuickConnectPlugin"

cd /d "%PROJECT_PATH%"

IF NOT EXIST .\QuickConnectPlugin\Properties\GeneratedAssemblyInfo.cs (
	echo File GeneratedAssemblyInfo.cs was not found. Build the solution first.
	pause
	exit
)

IF NOT EXIST build (
	mkdir build
)

xcopy /Y .\QuickConnectPlugin\bin\Debug\QuickConnectPlugin.dll .\build\
xcopy /Y .\QuickConnectPlugin\bin\Debug\QuickConnectPlugin.pdb .\build\

echo Cleaning project directory...
IF EXIST .\QuickConnectPlugin\bin\ (
	rmdir /S /Q .\QuickConnectPlugin\bin\
)

IF EXIST .\QuickConnectPlugin\obj\ (
	rmdir /S /Q .\QuickConnectPlugin\obj\
)

echo Building PLGX file...

copy /Y .\QuickConnectPlugin\Info.cs .\QuickConnectPlugin\Info.cs.bak
xcopy /Y .\Info.cs .\QuickConnectPlugin\

%KEEPASS_PATH% --plgx-prereq-kp:2.52 --plgx-prereq-net:4.0 --plgx-create %SOURCE_PATH%

echo Moving PLGX file to build directory...
move /Y .\QuickConnectPlugin.plgx .\build\QuickConnectPlugin.plgx

echo Cleaning PLGX build directory....

move /Y .\QuickConnectPlugin\Info.cs.bak .\QuickConnectPlugin\Info.cs

echo Done.
pause