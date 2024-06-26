﻿using System.Collections.Generic;
using System;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using Crestron.SimplSharp;

namespace QsxDataExtractor
{
    public struct sceneDataStruct
    {
        public string label;
        public string href;
        public string fbHref;
    }    
    public struct zoneDataStruct
    {
        public string label;
        public string href;
    }

    public struct shadeGroupDataStruct
    {
        public string label;
        public string href;
    }

    public static class DataExtractor
    {   
        static List<AreaData> Areas = new List<AreaData>();
        static List<DeviceData> Devices = new List<DeviceData>();
        //public static List<ComponentData> Components = new List<ComponentData>();
        //public static List<SceneData> Scenes = new List<SceneData>();
        //public static List<ZoneData> Zones = new List<ZoneData>();

        private static readonly object zoneLock = new object();
        private static readonly object sceneLock = new object();
        private static readonly object shadeGroupLock = new object();

        private static string AreaNode = @"Area Name,href";
        private static string SceneNode = "Area Scene Name,href";
        private static string ComponentNode = "Device name,Model,href,Component,Component href,Component Name";
        private static string ZoneNode = "Zone Name,href";
        private static string ShadeGroupNode = "Shade Group Name,href";

        /***************** SIMPL Functions *****************/
        // Getters
        public static int GetZoneData(ref zoneDataStruct myStructArg, string areaHref, int zone)
        {
            lock (zoneLock)
            {
                var area = Areas.Find(a => a.Href == areaHref);
                if (area != null)
                {
                    if (area.Zones != null)
                    {
                        if (area.Zones.ElementAtOrDefault(zone - 1) != null)
                        {
                            myStructArg.label = area.Zones[zone - 1].Label;
                            myStructArg.href = area.Zones[zone - 1].Href;
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            
        }
        
        public static int GetShadeGroupData(ref shadeGroupDataStruct myStructArg, string areaHref, int shadeGroup)
        {
            lock (shadeGroupLock)
            {
                var area = Areas.Find(a => a.Href == areaHref);
                if (area != null)
                {
                    if (area.ShadeGroups != null)
                    {
                        if (area.ShadeGroups.ElementAtOrDefault(shadeGroup - 1) != null)
                        {
                            myStructArg.label = area.ShadeGroups[shadeGroup - 1].Label;
                            myStructArg.href = area.ShadeGroups[shadeGroup - 1].Href;
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            
        }
        public static int GetSceneData(ref sceneDataStruct myStructArg, string areaHref, int scene, string keypadHref = "")
        {
            lock (sceneLock)
            {
                var area = Areas.Find(a => a.Href == areaHref);
                // If the keypad Href is defined, use a device definition
                if (keypadHref.Length > 0)
                {
                    if (area != null)
                    {
                        var dev = area.Devices.Find(a => a.Href == keypadHref);
                        if (dev != null)
                        {
                            if (dev.Components != null)
                            {
                                if (dev.Components.Find(c => c.Number == scene) != null)
                                {
                                    myStructArg.label = dev.Components.Find(c => c.Number == scene && c.Type == "button").Name;
                                    myStructArg.href = dev.Components.Find(c => c.Number == scene && c.Type == "button").Href;
                                    if (dev.Components.Find(c => c.Number == scene && c.Type == "led") != null)
                                    {
                                        myStructArg.fbHref = dev.Components.Find(c => c.Number == scene && c.Type == "led").Href;
                                    }
                                    else
                                    {
                                        myStructArg.fbHref = "";
                                    }
                                    return 1;
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                // Otherwise return the area scenes
                else
                {
                    if (area != null)
                    {
                        if (area.Scenes != null)
                        {
                            if (area.Scenes[scene - 1] != null)
                            {
                                myStructArg.label = area.Scenes[scene - 1].Label;
                                myStructArg.href = area.Scenes[scene - 1].Href;
                                myStructArg.fbHref = "";
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
 
        public static string ExtractSubstring(string startLine, string sourceString)
        {
            string pattern = $@"{startLine}\r?\n(.+?)(\r?\n\r?\n|$)";
            Match match = Regex.Match(sourceString, pattern, RegexOptions.Singleline);
            if (match.Success)
            {
                return match.Groups[0].Value;
            }
            else
            {
                return "Substring not found.";
            }
        }

        public static void AddDataToMatchingDevice(ComponentData component)
        {
            // Update an existing device
            if (Devices.Find(d => d.Href == component.DeviceHref) != null)
            {
                var device = Devices.Find(d => d.Href == component.DeviceHref);

                device.Components.Add(component);
            }
            // Create a new device
            else
            {
                DeviceData device = new DeviceData();
                device.Name = component.DeviceName;
                device.Href = component.DeviceHref;
                device.Model = component.DeviceModel;
                device.Components = new List<ComponentData>();
                device.Components.Add(component);
                Devices.Add(device);
            }
        }

        // Function to extract the actual href from data
        public static string ParseHref(string href)
        {
            return new string(href.Where(char.IsDigit).ToArray());
        }
        // Function to extract component type from data
        public static string parseType(string href)
        {
            if (href.Contains("button"))
            {
                return "button";
            }
            else if (href.Contains("led"))
            {
                return "led";
            }
            else
            {
                return "unknown";
            }
        }
        // Function to extract component number from data
        public static int ParseNumber(string val)
        {
            string cleanedHref = new string(val.Where(char.IsDigit).ToArray());

            if (int.TryParse(cleanedHref, out int parsedValue))
            {
                // parsedValue contains the parsed integer
                return parsedValue;
            }
            else
            {
                // Parsing failed, handle the error if needed
                return 0;
            }
        }

        // Function to remove any invisible characters from a string
        public static string CleanString(string input)
        {
            var lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            StringBuilder result = new StringBuilder();

            string pattern = @"[^\x20-\x7E\r]+";

            foreach (var line in lines)
            {
                string lineWithoutBackslashes = Regex.Replace(line, pattern, "");
                result.Append(lineWithoutBackslashes);
                // Append the new line character after each line, as it's removed during the split
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        // Replace this with init function to trigger from SIMPL
        public static string ReadData(string filePath)
        {
            try
            {
                string fileText = File.ReadAllText($@"{filePath}");

                if (fileText.Length > 0)
                {
                    string AreaCsvData = ExtractSubstring(AreaNode, fileText);
                    string ComponentCsvData = ExtractSubstring(ComponentNode, fileText);
                    string SceneCsvData = ExtractSubstring(SceneNode, fileText);
                    string ZoneCsvData = ExtractSubstring(ZoneNode, fileText);
                    string ShadeGroupCsvData = ExtractSubstring(ShadeGroupNode, fileText);

                    char delimiter = ',';

                    //Console.WriteLine(CleanString(ComponentCsvData));

                    // Establish Areas
                    if (AreaCsvData != "Substring not found.")
                    {
                        var areas = CSVConverter.ConvertToClassData<AreaData>(CleanString(AreaCsvData), delimiter);
                        if (areas != null)
                        {
                            foreach (var record in areas)
                            {
                                //Console.WriteLine($"Area: {record.AreaName}");
                                record.Devices = new List<DeviceData>();
                                record.Scenes = new List<SceneData>();
                                record.Zones = new List<ZoneData>();
                                record.ShadeGroups = new List<ShadeGroupData>();
                                record.Href = (ParseHref(record.Href));
                                Areas.Add(record);
                            }
                        }
                    }

                    // Establish Scenes
                    if (SceneCsvData != "Substring not found.")
                    {
                        var scenes = CSVConverter.ConvertToClassData<SceneData>(CleanString(SceneCsvData), delimiter);
                        if (scenes != null)
                        {
                            foreach (var record in scenes)
                            {
                                string[] splitName = record.Name.Split('\\');
                                record.Label = splitName[splitName.Length - 1];

                                string sceneName = record.Name;
                                record.Href = ParseHref(record.Href);
                                foreach (var area in Areas)
                                {
                                    if (sceneName.Contains(area.AreaName))
                                    {
                                        area.Scenes.Add(record);
                                    }
                                }
                            }
                        }
                    }

                    // Establish Zones
                    if (ZoneCsvData != "Substring not found.")
                    {
                        var zones = CSVConverter.ConvertToClassData<ZoneData>(CleanString(ZoneCsvData), delimiter);
                        if (zones != null)
                        {
                            foreach (var record in zones)
                            {
                                string[] splitName = record.Name.Split('\\');
                                record.Label = splitName[splitName.Length - 1];

                                string zoneName = record.Name;
                                record.Href = ParseHref(record.Href);
                                foreach (var area in Areas)
                                {
                                    if (zoneName.Contains(area.AreaName))
                                    {
                                        area.Zones.Add(record);
                                    }
                                }
                            }
                        }
                    }
                    
                    // Establish Shade Groups
                    if(ShadeGroupCsvData != "Substring not found.")
                    {
                        var shadeGroups = CSVConverter.ConvertToClassData<ShadeGroupData>(CleanString(ShadeGroupCsvData), delimiter);
                        if (shadeGroups != null)
                        {
                            foreach (var record in shadeGroups)
                            {
                                string[] splitName = record.Name.Split('\\');
                                record.Label = splitName[splitName.Length - 1];

                                string shadeGroupName = record.Name;
                                record.Href = ParseHref(record.Href);

                                foreach (var area in Areas)
                                {
                                    if (shadeGroupName.Contains(area.AreaName))
                                    {
                                        area.ShadeGroups.Add(record);
                                    }
                                }

                            }
                        }
                    }

                    // Establish Components
                    if (ComponentCsvData != "Substring not found.")
                    {
                        var comps = CSVConverter.ConvertToClassData<ComponentData>(CleanString(ComponentCsvData), delimiter);
                        if (comps != null)
                        {
                            ComponentData previousRecord = null;

                            foreach (var record in comps)
                            {
                                if (record.DeviceName.Length < 1 && previousRecord != null)
                                {
                                    record.DeviceName = previousRecord.DeviceName;
                                    record.DeviceModel = previousRecord.DeviceModel;
                                    record.DeviceHref = previousRecord.DeviceHref;
                                }
                                else
                                {
                                    record.DeviceHref = ParseHref(record.DeviceHref);
                                }
                                record.Number = ParseNumber(record.Component);
                                record.Type = parseType(record.Href);
                                record.Href = ParseHref(record.Href);

                                AddDataToMatchingDevice(record);
                                previousRecord = record;

                            }
                        }
                    }

                    // Allocate devices to areas
                    foreach (var Device in Devices)
                    {
                        string deviceName = Device.Name;
                        foreach (var area in Areas)
                        {
                            if (deviceName.Contains(area.AreaName))
                            {
                                area.Devices.Add(Device);
                            }
                        }
                    }

                    // Write area data to console
                    foreach (var Area in Areas)
                    {
                        Console.WriteLine($"Area: {Area.AreaName}, Href: {Area.Href}");
                        if (Area.Devices != null)
                        {
                            Console.WriteLine($"Number of Devices: {Area.Devices.Count}");
                            foreach (var Device in Area.Devices)
                            {
                                Console.WriteLine($"Device: {Device.Name}, Href: {Device.Href}, Href: {Device.Href}");
                                if (Device.Components != null)
                                {
                                    Console.WriteLine($"Number of Components: {Device.Components.Count}");
                                    foreach (var Component in Device.Components)
                                    {
                                        Console.WriteLine($"Component: {Component.Name}, Href: {Component.Href}, Type: {Component.Type}");

                                    }
                                }
                            }
                        }
                        if (Area.Zones != null)
                        {
                            Console.WriteLine($"Number of zones: {Area.Zones.Count}");
                            foreach (var Zone in Area.Zones)
                            {
                                Console.WriteLine($"Zone: {Zone.Name}, Href: {Zone.Href}, Label: {Zone.Label}");
                            }
                        }
                        if (Area.Scenes != null)
                        {
                            Console.WriteLine($"Number of scenes: {Area.Scenes.Count}");
                            foreach (var Scene in Area.Scenes)
                            {
                                Console.WriteLine($"Scene: {Scene.Name}, Href: {Scene.Href}, Label: {Scene.Label}");
                            }
                        }                        
                        if (Area.ShadeGroups != null)
                        {
                            Console.WriteLine($"Number of scenes: {Area.ShadeGroups.Count}");
                            foreach (var ShadeGroup in Area.ShadeGroups)
                            {
                                Console.WriteLine($"Scene: {ShadeGroup.Name}, Href: {ShadeGroup.Href}, Label: {ShadeGroup.Label}");
                            }
                        }
                    }

                    return "File read complete. Status: SUCCESS";
                }
                else
                {
                    return "No file content";
                }
           
            }
            catch (Exception ex)
            {
                // Handle any exceptions, e.g., file not found, permissions issues, etc.
                return $"An error occurred: {ex.Message}";
            }
        }
    }
}
