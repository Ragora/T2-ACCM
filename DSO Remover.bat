@echo off
color 2f
cls
echo;
echo;
echo           ษอออออออออออออออออออออออออออออออออออออออออออออออออออออออออป
echo           บ                    0.70 DSO Remover                     บ
echo           ฬอออออออออออออออออออออออออออออออออออออออออออออออออออออออออน
echo           บ This DOS batch file will remove those pesky dso's from  บ
echo           บ your Tribes 2 installation. Regardless of where it is.  บ
echo           ฬอออออออออออออออออออออออออออออออออออออออออออออออออออออออออน
echo           บ    Remove all DSO files(not flagged as read only) from  บ
echo           บ    Tribes 2 directory by pressing enter.                บ
echo           ศอออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ
echo;
echo;
pause
cd ..
del /s /q *.dso
cls
echo;
echo;
echo           ษอออออออออออออออออออออออออออออออออออออออออออออออออออออออออป
echo           บ                        Success!                         บ
echo           บ                                                         บ
echo           บ       All dso's from Tribes 2 have been removed.        บ
echo           ศอออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ
echo;
echo;
pause