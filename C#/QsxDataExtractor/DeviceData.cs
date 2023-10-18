using System.Collections.Generic;

namespace QsxDataExtractor
{
    class DeviceData
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Href { get; set; }
        public List<ComponentData> Components { get; set; }
    }
}
