@echo off
@if defined _echo echo on

:install_dotnet_cli
setlocal
  set "DOTNET_MULTILEVEL_LOOKUP=0"

  set /p NuGet_Version=<"%~dp0..\.config\NuGetCLIVersion.txt"
  if not defined NuGet_Version (
    call :print_error_message Unknown NuGet CLI Version.
    exit /b 1
  )

  set NuGet_Path=%~dp0..\packages\nuget
  set NuGet=%NuGet_Path%\nuget.exe
  set NuGet_Url=https://dist.nuget.org/win-x86-commandline/v%NuGet_Version%/nuget.exe

  if exist "%NuGet%" (
    goto :install_dotnet_cli_exit
  ) 

  if not exist "%NuGet%" (
    if not exist "%NuGet_Path%" (
      mkdir "%NuGet_Path%"
    )
  )

  echo Installing NuGet CLI
  echo Downloading NuGet
  powershell -NoProfile -ExecutionPolicy unrestricted -Command "Invoke-WebRequest -Uri '%NuGet_Url%' -OutFile '%NuGet_Path%\nuget.exe'"
  if not exist "%NuGet_Path%\nuget.exe" (
    call :print_error_message Failed to download "%NuGet_Path%\nuget.exe"
    exit /b 1
  )

:install_dotnet_cli_exit
  echo/
  call :tools

endlocal& (
  set "PATH=%NuGet_Path%;%PATH%"
  exit /b 0
)

:tools

  echo/
  echo/ ========== MyGet ==========
  echo/ NuGet CLI 
  echo/ ========== MyGet ==========
  where.exe /R %~dp0..\packages /F nuget.exe

  echo/

  exit /b 0

:print_error_message
  echo/
  echo/  [ERROR] %*
  echo/
  exit /b %errorlevel%

:remove_directory
  if "%~1" == "" (
    call :print_error_message Directory name was not specified.
    exit /b 1
  )
  if exist "%~1" rmdir /s /q "%~1"
  if exist "%~1" (
    call :print_error_message Failed to remove directory "%~1".
    exit /b 1
  )
  exit /b 0
:exit