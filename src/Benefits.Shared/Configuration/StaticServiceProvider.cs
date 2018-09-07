using System;

namespace Benefits.Shared.Configuration
{
    public static class StaticServiceProvider
    {
        // Assign in Startup.cs
        public static IServiceProvider Instance { get; set; }
    }
}