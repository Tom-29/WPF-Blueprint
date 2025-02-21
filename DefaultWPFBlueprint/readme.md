# Blueprint to create a WPF app in competition

This Blueprint is meant to faster up the creation of an WPF application.

## Publish as executable

The file must be an executable in the end. To archie this just run the following command:

```shell
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:DebugType=None
```