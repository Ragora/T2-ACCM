@echo off
color 2f
cls
echo;
echo;
echo           ���������������������������������������������������������ͻ
echo           �                    0.70 DSO Remover                     �
echo           ���������������������������������������������������������͹
echo           � This DOS batch file will remove those pesky dso's from  �
echo           � your Tribes 2 installation. Regardless of where it is.  �
echo           ���������������������������������������������������������͹
echo           �    Remove all DSO files(not flagged as read only) from  �
echo           �    Tribes 2 directory by pressing enter.                �
echo           ���������������������������������������������������������ͼ
echo;
echo;
pause
cd ..
del /s /q *.dso
cls
echo;
echo;
echo           ���������������������������������������������������������ͻ
echo           �                        Success!                         �
echo           �                                                         �
echo           �       All dso's from Tribes 2 have been removed.        �
echo           ���������������������������������������������������������ͼ
echo;
echo;
pause