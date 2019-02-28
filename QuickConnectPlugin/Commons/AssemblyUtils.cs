﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;

namespace QuickConnectPlugin.Commons {

    public static class AssemblyUtils {

        public static String GetApplicationPath() {
            return new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
        }

        public static String GetApplicationDirPath() {
            return Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
        }

        public static string GetProductVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.ProductVersion;
        }

        public static Version GetVersion() {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            return assembly.GetName().Version;
        }

        public static Version GetVersion(String assemblyName) {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(assemblyName);
            return assembly.GetName().Version;
        }

        public static Assembly AssemblyResolver(object sender, ResolveEventArgs args) {
            string resourceName = new AssemblyName(args.Name).Name + ".dll";
            string resource = Array.Find(Assembly.GetExecutingAssembly().GetManifestResourceNames(), element => element.EndsWith(resourceName));
            if (resource != null) {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource)) {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            }
            return null;
        }

        public static Assembly AssemblyResolverFromResources(object sender, ResolveEventArgs args) {
            string resourceName = new AssemblyName(args.Name).Name.Replace(".", "_").Replace("-", "_");
            if (resourceName.EndsWith("_resources")) {
                return null;
            }
            var baseAssembly = System.Reflection.Assembly.GetAssembly(typeof(QuickConnectPluginExt));
            ResourceManager resourceManager = new System.Resources.ResourceManager(baseAssembly.GetName().Name + ".Properties.Resources", baseAssembly);
            var resourceObject = resourceManager.GetObject(resourceName);
            if (resourceObject != null) {
                return Assembly.Load((byte[])resourceObject);
            }
            return null;
        }

        public static String GetExecutingAssemblyName() {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}