@echo off
@if defined _echo echo on

:main
setlocal enabledelayedexpansion
  set errorlevel=

  set OutputDirectory=%~dp0..\..\..\Blazor\artifacts\build

  if not exist %OutputDirectory% (
      call :print_error_message Failed to find Blazor folder
      exit /b 1
  )

  rem Don't fall back to machine-installed versions of dotnet, only use repo-local version
  set DOTNET_MULTILEVEL_LOOKUP=0

  call "%~dp0nuget-install.cmd" || exit /b 1

  set procedures=
  set procedures=%procedures% build_myget

  for %%p in (%procedures%) do (
    call :%%p || (
      call :print_error_message Failed to run %%p
      exit /b 1
    )
  )
endlocal& exit /b %errorlevel%

:build_myget
  if "%MYGET_ACCESSTOKEN%" == "" (
    echo/ 
    echo/ ========== MyGet ==========
    echo/ Missing MyGet access token environment variable API key
    echo/ ========== MyGet ==========
  )
  if not "%MYGET_ACCESSTOKEN%" == "" (
    for /f "tokens=* usebackq" %%f in (`dir /B %OutputDirectory%\*.nupkg`) do (
      echo/ 
      echo/ ========== MyGet ==========
      echo/ Uploading MyGet package %OutputDirectory%\%%f
      echo/ ========== MyGet ==========
      nuget push %OutputDirectory%\%%f %MYGET_ACCESSTOKEN% -Source https://www.myget.org/F/blazor/api/v2/package || exit /b 1
    )
  )
  exit /b 0

:print_error_message
  echo/
  echo/  [ERROR] %*
  echo/
  exit /b %errorlevel%

:exit