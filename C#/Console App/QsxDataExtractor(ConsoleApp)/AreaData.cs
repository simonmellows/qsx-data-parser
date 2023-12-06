using System.Collections.Generic;

namespace QsxDataExtractor_ConsoleApp_
{
    class AreaData
    {
        public string AreaName { get; set; }
        public string Href { get; set; }

        public List<DeviceData> Devices { get; set; }
        public List<ZoneData> Zones { get; set; }
        public List<SceneData> Scenes { get; set; }
        public List<ShadeGroupData> ShadeGroups { get; set; }
    }
}
