# EFAutomapperBugRepro

Reproduction for issue: https://github.com/aspnet/EntityFrameworkCore/issues/12531

 - Open in VS
 - Run `Update-Database` in package manager console
 - Debug app
 
 Should launch `api/thing` were the bug is reproduced.
 Navigate to `api/thingwithouttype` to see a working projection.
