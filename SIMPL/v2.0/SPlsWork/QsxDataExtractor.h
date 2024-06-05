namespace QsxDataExtractor;
        // class declarations
         class ComponentData;
         class sceneDataStruct;
         class zoneDataStruct;
         class shadeGroupDataStruct;
         class DataExtractor;
         class SceneData;
         class ZoneData;
     class ComponentData 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING DeviceName[];
        STRING DeviceModel[];
        STRING DeviceHref[];
        STRING Component[];
        STRING Href[];
        STRING Name[];
        STRING Type[];
        SIGNED_LONG_INTEGER Number;
    };

     class sceneDataStruct 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING label[];
        STRING href[];
        STRING fbHref[];

        // class properties
    };

     class zoneDataStruct 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING label[];
        STRING href[];

        // class properties
    };

     class shadeGroupDataStruct 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING label[];
        STRING href[];

        // class properties
    };

    static class DataExtractor 
    {
        // class delegates

        // class events

        // class functions
        static SIGNED_LONG_INTEGER_FUNCTION GetZoneData ( BYREF zoneDataStruct myStructArg , STRING areaHref , SIGNED_LONG_INTEGER zone );
        static SIGNED_LONG_INTEGER_FUNCTION GetShadeGroupData ( BYREF shadeGroupDataStruct myStructArg , STRING areaHref , SIGNED_LONG_INTEGER shadeGroup );
        static SIGNED_LONG_INTEGER_FUNCTION GetSceneData ( BYREF sceneDataStruct myStructArg , STRING areaHref , SIGNED_LONG_INTEGER scene , STRING keypadHref );
        static STRING_FUNCTION ExtractSubstring ( STRING startLine , STRING sourceString );
        static FUNCTION AddDataToMatchingDevice ( ComponentData component );
        static STRING_FUNCTION ParseHref ( STRING href );
        static STRING_FUNCTION parseType ( STRING href );
        static SIGNED_LONG_INTEGER_FUNCTION ParseNumber ( STRING val );
        static STRING_FUNCTION CleanString ( STRING input );
        static STRING_FUNCTION ReadData ( STRING filePath );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class SceneData 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        STRING Href[];
        STRING Label[];
    };

     class ZoneData 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        STRING Href[];
        STRING Label[];
    };

