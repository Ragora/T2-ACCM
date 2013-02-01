@echo OFF
echo Construction Mod 0.70
echo Advanced Mod Loader
echo.
echo Please choose options below to launch server:
echo.
echo Options:
echo 1) Launch Online Dedicated Server (Ispawn).
echo 2) Launch Online Dedicated Server.
echo 3) Launch Offline Dedicated Server (Ispawn).
echo 4) Launch Offline Dedicated Server.
echo 5) Launch Online Listen Server.
echo 6) Launch Offline Listen Server.
echo 7) Exit.
set /p Input=Press enter after selection (1-7): 
if %Input%==7 goto exit
set /p RemDSO=Would you like to remove all DSOs from your Tribes 2 install? (y/n): 
cd ..
if %RemDSO%==y del /s /q *.dso
if %Input%==1 goto NDI
if %Input%==2 goto ND
if %Input%==3 goto FDI
if %Input%==4 goto FD
if %Input%==5 goto NL
if %Input%==6 goto FL

goto exit

:NDI
start ispawn.exe 28000 Tribes2.exe -dedicated -mod Construction
goto exit

:ND
start Tribes2.exe -dedicated -mod Construction
goto exit

:FDI
start ispawn.exe 28000 Tribes2.exe -nologin -dedicated -mod Construction
goto exit

:FD
start Tribes2.exe -nologin -dedicated -mod Construction
goto exit

:NL
start Tribes2.exe -online -mod Construction
goto exit

:FL
start Tribes2.exe -nologin -mod Construction
goto exit

:exit