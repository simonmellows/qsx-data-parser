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

namespace UserModule_LUTRON_HOMEWORKS_QSX_SHADE_GROUP_CONTROL__CF_V1_0_
{
    public class UserModuleClass_LUTRON_HOMEWORKS_QSX_SHADE_GROUP_CONTROL__CF_V1_0_ : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INIT;
        Crestron.Logos.SplusObjects.DigitalInput LIFT_RAISE;
        Crestron.Logos.SplusObjects.DigitalInput LIFT_LOWER;
        Crestron.Logos.SplusObjects.DigitalInput TILT_RAISE;
        Crestron.Logos.SplusObjects.DigitalInput TILT_LOWER;
        Crestron.Logos.SplusObjects.DigitalInput SET_LIFT_LEVEL;
        Crestron.Logos.SplusObjects.DigitalInput SET_TILT_LEVEL;
        Crestron.Logos.SplusObjects.AnalogInput LIFT_LEVEL;
        Crestron.Logos.SplusObjects.AnalogInput TILT_LEVEL;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.AnalogOutput LIFT_LEVEL_FB;
        Crestron.Logos.SplusObjects.AnalogOutput TILT_LEVEL_FB;
        Crestron.Logos.SplusObjects.StringInput ZONE_HREF_ID__DOLLAR__;
        UShortParameter COMMAND_PROCESSOR_ID;
        UShortParameter SHADE_MODE;
        Lutron.Leap.CommLib.Components.ShadeComponent COMPONENT;
        public void ONINITIALIZATIONCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.ShadeComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.InitializationEventArgs ARGS ) 
            { 
            ShadeComponent  SENDER  = (ShadeComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 113;
                IS_INITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONLIFTLEVELCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.ShadeComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.DimLevelEventArgs ARGS ) 
            { 
            ShadeComponent  SENDER  = (ShadeComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 118;
                LIFT_LEVEL_FB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONTILTLEVELCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.ShadeComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.DimLevelEventArgs ARGS ) 
            { 
            ShadeComponent  SENDER  = (ShadeComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 123;
                TILT_LEVEL_FB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object LIFT_RAISE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 132;
                COMPONENT . RaiseLift ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object LIFT_LOWER_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 137;
            COMPONENT . LowerLift ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object LIFT_RAISE_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 142;
        COMPONENT . StopLift ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TILT_RAISE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 147;
        COMPONENT . RaiseTilt ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TILT_LOWER_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 152;
        COMPONENT . LowerTilt ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TILT_RAISE_OnRelease_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 157;
        COMPONENT . StopTilt ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_LIFT_LEVEL_OnRelease_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 162;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LIFT_LEVEL  .UshortValue != LIFT_LEVEL_FB  .Value))  ) ) 
            { 
            __context__.SourceCodeLine = 164;
            COMPONENT . SetLiftLevel ( (ushort)( LIFT_LEVEL  .UshortValue )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LIFT_LEVEL_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 170;
        if ( Functions.TestForTrue  ( ( SET_LIFT_LEVEL  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 172;
            COMPONENT . SetLiftLevel ( (ushort)( LIFT_LEVEL  .UshortValue )) ; 
            __context__.SourceCodeLine = 173;
            Functions.Delay (  (int) ( 10 ) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_TILT_LEVEL_OnRelease_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 179;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TILT_LEVEL  .UshortValue != TILT_LEVEL_FB  .Value))  ) ) 
            { 
            __context__.SourceCodeLine = 181;
            COMPONENT . SetTiltLevel ( (ushort)( TILT_LEVEL  .UshortValue )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TILT_LEVEL_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 187;
        if ( Functions.TestForTrue  ( ( SET_TILT_LEVEL  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 189;
            COMPONENT . SetTiltLevel ( (ushort)( TILT_LEVEL  .UshortValue )) ; 
            __context__.SourceCodeLine = 190;
            Functions.Delay (  (int) ( 10 ) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INIT_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        uint ZONE_HREF_ID = 0;
        
        
        __context__.SourceCodeLine = 200;
        // RegisterEvent( COMPONENT , ONINITIALIZATIONCHANGE , ONINITIALIZATIONCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnInitializationChange  += ONINITIALIZATIONCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 201;
        // RegisterEvent( COMPONENT , ONLIFTLEVELCHANGE , ONLIFTLEVELCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnLiftLevelChange  += ONLIFTLEVELCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 202;
        // RegisterEvent( COMPONENT , ONTILTLEVELCHANGE , ONTILTLEVELCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnTiltLevelChange  += ONTILTLEVELCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 205;
        ZONE_HREF_ID = (uint) ( Functions.Atol( ZONE_HREF_ID__DOLLAR__ ) ) ; 
        __context__.SourceCodeLine = 207;
        COMPONENT . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value ), (ushort)( SHADE_MODE  .Value ), (uint)( ZONE_HREF_ID )) ; 
        
        
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
        
        __context__.SourceCodeLine = 219;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    
    INIT = new Crestron.Logos.SplusObjects.DigitalInput( INIT__DigitalInput__, this );
    m_DigitalInputList.Add( INIT__DigitalInput__, INIT );
    
    LIFT_RAISE = new Crestron.Logos.SplusObjects.DigitalInput( LIFT_RAISE__DigitalInput__, this );
    m_DigitalInputList.Add( LIFT_RAISE__DigitalInput__, LIFT_RAISE );
    
    LIFT_LOWER = new Crestron.Logos.SplusObjects.DigitalInput( LIFT_LOWER__DigitalInput__, this );
    m_DigitalInputList.Add( LIFT_LOWER__DigitalInput__, LIFT_LOWER );
    
    TILT_RAISE = new Crestron.Logos.SplusObjects.DigitalInput( TILT_RAISE__DigitalInput__, this );
    m_DigitalInputList.Add( TILT_RAISE__DigitalInput__, TILT_RAISE );
    
    TILT_LOWER = new Crestron.Logos.SplusObjects.DigitalInput( TILT_LOWER__DigitalInput__, this );
    m_DigitalInputList.Add( TILT_LOWER__DigitalInput__, TILT_LOWER );
    
    SET_LIFT_LEVEL = new Crestron.Logos.SplusObjects.DigitalInput( SET_LIFT_LEVEL__DigitalInput__, this );
    m_DigitalInputList.Add( SET_LIFT_LEVEL__DigitalInput__, SET_LIFT_LEVEL );
    
    SET_TILT_LEVEL = new Crestron.Logos.SplusObjects.DigitalInput( SET_TILT_LEVEL__DigitalInput__, this );
    m_DigitalInputList.Add( SET_TILT_LEVEL__DigitalInput__, SET_TILT_LEVEL );
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    LIFT_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( LIFT_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( LIFT_LEVEL__AnalogSerialInput__, LIFT_LEVEL );
    
    TILT_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( TILT_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TILT_LEVEL__AnalogSerialInput__, TILT_LEVEL );
    
    LIFT_LEVEL_FB = new Crestron.Logos.SplusObjects.AnalogOutput( LIFT_LEVEL_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LIFT_LEVEL_FB__AnalogSerialOutput__, LIFT_LEVEL_FB );
    
    TILT_LEVEL_FB = new Crestron.Logos.SplusObjects.AnalogOutput( TILT_LEVEL_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( TILT_LEVEL_FB__AnalogSerialOutput__, TILT_LEVEL_FB );
    
    ZONE_HREF_ID__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( ZONE_HREF_ID__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( ZONE_HREF_ID__DOLLAR____AnalogSerialInput__, ZONE_HREF_ID__DOLLAR__ );
    
    COMMAND_PROCESSOR_ID = new UShortParameter( COMMAND_PROCESSOR_ID__Parameter__, this );
    m_ParameterList.Add( COMMAND_PROCESSOR_ID__Parameter__, COMMAND_PROCESSOR_ID );
    
    SHADE_MODE = new UShortParameter( SHADE_MODE__Parameter__, this );
    m_ParameterList.Add( SHADE_MODE__Parameter__, SHADE_MODE );
    
    
    LIFT_RAISE.OnDigitalPush.Add( new InputChangeHandlerWrapper( LIFT_RAISE_OnPush_0, false ) );
    LIFT_LOWER.OnDigitalPush.Add( new InputChangeHandlerWrapper( LIFT_LOWER_OnPush_1, false ) );
    LIFT_RAISE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( LIFT_RAISE_OnRelease_2, false ) );
    LIFT_LOWER.OnDigitalRelease.Add( new InputChangeHandlerWrapper( LIFT_RAISE_OnRelease_2, false ) );
    TILT_RAISE.OnDigitalPush.Add( new InputChangeHandlerWrapper( TILT_RAISE_OnPush_3, false ) );
    TILT_LOWER.OnDigitalPush.Add( new InputChangeHandlerWrapper( TILT_LOWER_OnPush_4, false ) );
    TILT_RAISE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( TILT_RAISE_OnRelease_5, false ) );
    TILT_LOWER.OnDigitalRelease.Add( new InputChangeHandlerWrapper( TILT_RAISE_OnRelease_5, false ) );
    SET_LIFT_LEVEL.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SET_LIFT_LEVEL_OnRelease_6, false ) );
    LIFT_LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( LIFT_LEVEL_OnChange_7, true ) );
    SET_TILT_LEVEL.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SET_TILT_LEVEL_OnRelease_8, false ) );
    TILT_LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( TILT_LEVEL_OnChange_9, true ) );
    INIT.OnDigitalPush.Add( new InputChangeHandlerWrapper( INIT_OnPush_10, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    COMPONENT  = new Lutron.Leap.CommLib.Components.ShadeComponent();
    
    
}

public UserModuleClass_LUTRON_HOMEWORKS_QSX_SHADE_GROUP_CONTROL__CF_V1_0_ ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INIT__DigitalInput__ = 0;
const uint LIFT_RAISE__DigitalInput__ = 1;
const uint LIFT_LOWER__DigitalInput__ = 2;
const uint TILT_RAISE__DigitalInput__ = 3;
const uint TILT_LOWER__DigitalInput__ = 4;
const uint SET_LIFT_LEVEL__DigitalInput__ = 5;
const uint SET_TILT_LEVEL__DigitalInput__ = 6;
const uint LIFT_LEVEL__AnalogSerialInput__ = 0;
const uint TILT_LEVEL__AnalogSerialInput__ = 1;
const uint IS_INITIALIZED__DigitalOutput__ = 0;
const uint LIFT_LEVEL_FB__AnalogSerialOutput__ = 0;
const uint TILT_LEVEL_FB__AnalogSerialOutput__ = 1;
const uint ZONE_HREF_ID__DOLLAR____AnalogSerialInput__ = 2;
const uint COMMAND_PROCESSOR_ID__Parameter__ = 10;
const uint SHADE_MODE__Parameter__ = 11;

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
