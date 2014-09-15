FAKE.MsDeployFuncs
==================

Ms Deploy and some remote IIS Utilities for FAKE F# build dsl

Example

```fs
#r "MsDeployFuncs.dll"

open MsDeployFuncs

let msDeployLocation = "C:\Program Files\IIS\Microsoft Web Deploy V3\msdeploy.exe"
Task "Deploy" (fun _ -> 
    let username = "tom"
    let password = "jones"
    let server = "tomjones.com"
    let sourceFile = fileInfo("myPackage.zip")
    let destFile = fileInfo(@"C:\RemoteServer\Folder\myPackage.zip")

    let result = MsDeploy.SyncFile(
        msDeployLocation, server, 
        username, password, 
        sourceFile, destfile,
        System.TimeSpan.FromMinutes(float(1)))
    if result <> 0 failwith "Operation failed or timed out"
)
```

Check source for other functions

```
MsDeploy.SyncFile
MsDeploy.RunRemoteCommand
```

