using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using Lutron.Leap.CommLib.ProtocolSupport;
using Lutron.Leap.CommLib.Models.Bodies.SubClasses;
using Lutron.Leap.CommLib.Event_Arguments;
using Lutron.Leap.CommLib.ComponentStates;
using Lutron.Leap.CommLib.Models;
using Lutron.Leap.CommLib.Models.Bodies;
using Lutron.Leap.CommLib.LeapSupport;
using Lutron.Leap.CommLib.Components;
using Lutron.Leap.CommLib.JsonSupport;
using Lutron.Leap.CommLib.Components.SubComponents;
using Lutron.Leap.CommLib;
using Lutron.Leap.CommLib.CCI_Support;
using CCI.SimplSharp.Library.Comm.Priority;
using CCI.SimplSharp.Library.Comm.Model;
using CCI.SimplSharp.Library.Comm.Equality;
using CCI.SimplSharp.Library.Comm.Common;
using CCI.SimplSharp.Library.Components.EventArguments;
using CCI.SimplSharp.Library.Components.States;
using CCI.SimplSharp.Library.Components.Common;
using CCI.SimplSharp.Library.Components.Registration;
using CCI.SimplSharp.Library.IO.Utilities;
using CCI.SimplSharp.Library.IO.Common;

namespace UserModule_LUTRON_HOMEWORKS_QSX_AREA_SCENE_CONTROL__CF_V1_0_
{
    public class UserModuleClass_LUTRON_HOMEWORKS_QSX_AREA_SCENE_CONTROL__CF_V1_0_ : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INIT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> RECALL_SCENE;
        Crestron.Logos.SplusObjects.StringInput AREA_HREF_ID__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> PRESET_HREF_ID__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_IS_OCCUPIED;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_IS_VACANT;
        UShortParameter COMMAND_PROCESSOR_ID;
        Lutron.Leap.CommLib.Components.AreaComponent COMPONENT;
        uint AREA_HREF_ID = 0;
        uint [] PRESET_HREF_ID;
        public void ONINITIALIZATIONCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.AreaComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.InitializationEventArgs ARGS ) 
            { 
            AreaComponent  SENDER  = (AreaComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 108;
                IS_INITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONOCCUPANCYCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.AreaComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.OccupiedEventArgs ARGS ) 
            { 
            AreaComponent  SENDER  = (AreaComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 114;
                ROOM_IS_OCCUPIED  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == OccupiedStateTypes.Occupied) ) ; 
                __context__.SourceCodeLine = 115;
                ROOM_IS_VACANT  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == OccupiedStateTypes.Unoccupied) ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object RECALL_SCENE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort PRESET = 0;
                
                
                __context__.SourceCodeLine = 126;
                PRESET = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 128;
                COMPONENT . RecallPreset ( (ushort)( PRESET )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object INIT_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort PRESET = 0;
            
            
            __context__.SourceCodeLine = 136;
            // RegisterEvent( COMPONENT , ONINITIALIZATIONCHANGE , ONINITIALIZATIONCHANGE ) 
            try { g_criticalSection.Enter(); COMPONENT .OnInitializationChange  += ONINITIALIZATIONCHANGE; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 137;
            // RegisterEvent( COMPONENT , ONOCCUPANCYCHANGE , ONOCCUPANCYCHANGE ) 
            try { g_criticalSection.Enter(); COMPONENT .OnOccupancyChange  += ONOCCUPANCYCHANGE; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 139;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)17; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( PRESET  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (PRESET  >= __FN_FORSTART_VAL__1) && (PRESET  <= __FN_FOREND_VAL__1) ) : ( (PRESET  <= __FN_FORSTART_VAL__1) && (PRESET  >= __FN_FOREND_VAL__1) ) ; PRESET  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 141;
                PRESET_HREF_ID [ PRESET] = (uint) ( Functions.Atol( PRESET_HREF_ID__DOLLAR__[ PRESET ] ) ) ; 
                __context__.SourceCodeLine = 143;
                COMPONENT . AddPreset ( (ushort)( PRESET ), (uint)( PRESET_HREF_ID[ PRESET ] )) ; 
                __context__.SourceCodeLine = 139;
                } 
            
            __context__.SourceCodeLine = 147;
            AREA_HREF_ID = (uint) ( Functions.Atol( AREA_HREF_ID__DOLLAR__ ) ) ; 
            __context__.SourceCodeLine = 149;
            COMPONENT . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value ), (uint)( AREA_HREF_ID )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 163;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    PRESET_HREF_ID  = new uint[ 18 ];
    
    INIT = new Crestron.Logos.SplusObjects.DigitalInput( INIT__DigitalInput__, this );
    m_DigitalInputList.Add( INIT__DigitalInput__, INIT );
    
    RECALL_SCENE = new InOutArray<DigitalInput>( 17, this );
    for( uint i = 0; i < 17; i++ )
    {
        RECALL_SCENE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( RECALL_SCENE__DigitalInput__ + i, RECALL_SCENE__DigitalInput__, this );
        m_DigitalInputList.Add( RECALL_SCENE__DigitalInput__ + i, RECALL_SCENE[i+1] );
    }
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    ROOM_IS_OCCUPIED = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_IS_OCCUPIED__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_IS_OCCUPIED__DigitalOutput__, ROOM_IS_OCCUPIED );
    
    ROOM_IS_VACANT = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_IS_VACANT__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_IS_VACANT__DigitalOutput__, ROOM_IS_VACANT );
    
    AREA_HREF_ID__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( AREA_HREF_ID__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( AREA_HREF_ID__DOLLAR____AnalogSerialInput__, AREA_HREF_ID__DOLLAR__ );
    
    PRESET_HREF_ID__DOLLAR__ = new InOutArray<StringInput>( 17, this );
    for( uint i = 0; i < 17; i++ )
    {
        PRESET_HREF_ID__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( PRESET_HREF_ID__DOLLAR____AnalogSerialInput__ + i, PRESET_HREF_ID__DOLLAR____AnalogSerialInput__, 255, this );
        m_StringInputList.Add( PRESET_HREF_ID__DOLLAR____AnalogSerialInput__ + i, PRESET_HREF_ID__DOLLAR__[i+1] );
    }
    
    COMMAND_PROCESSOR_ID = new UShortParameter( COMMAND_PROCESSOR_ID__Parameter__, this );
    m_ParameterList.Add( COMMAND_PROCESSOR_ID__Parameter__, COMMAND_PROCESSOR_ID );
    
    
    for( uint i = 0; i < 17; i++ )
        RECALL_SCENE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( RECALL_SCENE_OnPush_0, false ) );
        
    INIT.OnDigitalPush.Add( new InputChangeHandlerWrapper( INIT_OnPush_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    COMPONENT  = new Lutron.Leap.CommLib.Components.AreaComponent();
    
    
}

public UserModuleClass_LUTRON_HOMEWORKS_QSX_AREA_SCENE_CONTROL__CF_V1_0_ ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INIT__DigitalInput__ = 0;
const uint RECALL_SCENE__DigitalInput__ = 1;
const uint AREA_HREF_ID__DOLLAR____AnalogSerialInput__ = 0;
const uint PRESET_HREF_ID__DOLLAR____AnalogSerialInput__ = 1;
const uint IS_INITIALIZED__DigitalOutput__ = 0;
const uint ROOM_IS_OCCUPIED__DigitalOutput__ = 1;
const uint ROOM_IS_VACANT__DigitalOutput__ = 2;
const uint COMMAND_PROCESSOR_ID__Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
