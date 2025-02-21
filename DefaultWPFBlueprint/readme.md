# WPF Blueprint - Fast Start for WPF Applications

This blueprint provides a streamlined setup for quickly creating a WPF application.

## 🚀 Features
- Pre-configured WPF project structure
- Implements MVVM pattern with Community Toolkit
- Built-in error handling to prevent crashes
- JSON-based data persistence (loading & saving)
- Default application icon (customizable)
- Includes a `MainWindow` with two User Controls

## 📦 Getting Started

To create a new WPF application using this blueprint, run:

```shell
dotnet new competitionWpf -o MyNewProject
```

Replace `MyNewProject` with your desired project name.

## 🔧 Build & Publish as an Executable

To generate a standalone executable, use the following command:

```shell
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:DebugType=None
```

### Explanation of Flags:
- `-c Release` → Builds in release mode for optimized performance.
- `-r win-x64` → Targets Windows 64-bit systems.
- `--self-contained true` → Includes all necessary .NET runtime files.
- `-p:PublishSingleFile=true` → Produces a single `.exe` file.
- `-p:IncludeNativeLibrariesForSelfExtract=true` → Ensures native libraries are extracted correctly.
- `-p:DebugType=None` → Excludes debug symbols to reduce file size.

After publishing, the executable can be found in:
```plaintext
<MyProject>/bin/Release/netX.X/win-x64/publish/
```

## 🛠 Error Handling & Logging
This template includes built-in error handling to prevent crashes. Unhandled exceptions will be logged and displayed as a friendly message.
