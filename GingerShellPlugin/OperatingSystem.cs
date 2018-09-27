﻿using System.Runtime.InteropServices;

namespace GingerShellPlugin
{

    public static class OperatingSystem
    {

        public static bool IsWindows() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsMacOS() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static bool IsLinux() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static string GetCurrentOS()
        {
            return
            (IsWindows() ? "windows" : null) ??
            (IsMacOS() ? "mac" : null) ??
            (IsLinux() ? "linux" : null);
        }
    }


    //public static void DetermineOS()
    //{
    //    string windir = Environment.GetEnvironmentVariable("windir");
    //    if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
    //    {
    //        _isWindows = true;
    //    }
    //    else if (File.Exists(@"/proc/sys/kernel/ostype"))
    //    {
    //        string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
    //        if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
    //        {
    //            // Note: Android gets here too
    //            _isLinux = true;
    //        }
    //        else
    //        {
    //            throw new UnsupportedPlatformException(osType);
    //        }
    //    }
    //    else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
    //    {
    //        // Note: iOS gets here too
    //        _isMacOsX = true;
    //    }
    //    else
    //    {
    //        throw new UnsupportedPlatformException();
    //    }
    //}


}
