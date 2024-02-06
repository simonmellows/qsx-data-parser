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

namespace UserModule_LUTRON_HOMEWORKS_QSX_BUTTON_CONTROL__CF_V1_0_
{
    public class UserModuleClass_LUTRON_HOMEWORKS_QSX_BUTTON_CONTROL__CF_V1_0_ : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INIT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> BUTTON;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> BUTTON_HREF_ID__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PRESS;
        UShortParameter COMMAND_PROCESSOR_ID;
        UShortParameter MODE;
        UShortParameter MULTITAP_INTERVAL;
        Lutron.Leap.CommLib.Components.ButtonComponent COMPONENT;
        uint [] BUTTON_HREF_ID;
        public void ONINITIALIZATIONCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.ButtonComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.InitializationEventArgs ARGS ) 
            { 
            ButtonComponent  SENDER  = (ButtonComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 117;
                IS_INITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONBUTTONEVENTCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.ButtonComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.ButtonFeedbackEventArgs ARGS ) 
            { 
            ButtonComponent  SENDER  = (ButtonComponent )__sender__;
            ushort BTN = 0;
            
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 124;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)50; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( BTN  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (BTN  >= __FN_FORSTART_VAL__1) && (BTN  <= __FN_FOREND_VAL__1) ) : ( (BTN  <= __FN_FORSTART_VAL__1) && (BTN  >= __FN_FOREND_VAL__1) ) ; BTN  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 126;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.Id == BUTTON_HREF_ID[ BTN ]))  ) ) 
                        {
                        __context__.SourceCodeLine = 127;
                        PRESS [ BTN]  .Value = (ushort) ( Functions.Not( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ARGS.Payload == ButtonEventFeedback.Unknown) ) || Functions.TestForTrue ( Functions.BoolToInt (ARGS.Payload == ButtonEventFeedback.Release) )) ) ) ) ; 
                        }
                    
                    __context__.SourceCodeLine = 124;
                    } 
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object BUTTON_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 137;
                COMPONENT . Press ( (uint)( BUTTON_HREF_ID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object BUTTON_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 141;
            COMPONENT . Release ( (uint)( BUTTON_HREF_ID[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object INIT_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort BUTTON = 0;
        
        
        __context__.SourceCodeLine = 149;
        // RegisterEvent( COMPONENT , ONINITIALIZATIONCHANGE , ONINITIALIZATIONCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnInitializationChange  += ONINITIALIZATIONCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 150;
        // RegisterEvent( COMPONENT , ONBUTTONEVENTCHANGE , ONBUTTONEVENTCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnButtonEventChange  += ONBUTTONEVENTCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 152;
        COMPONENT . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value ), (ushort)( MODE  .Value ), (ushort)( 0 )) ; 
        __context__.SourceCodeLine = 154;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)50; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( BUTTON  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (BUTTON  >= __FN_FORSTART_VAL__1) && (BUTTON  <= __FN_FOREND_VAL__1) ) : ( (BUTTON  <= __FN_FORSTART_VAL__1) && (BUTTON  >= __FN_FOREND_VAL__1) ) ; BUTTON  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 156;
            BUTTON_HREF_ID [ BUTTON] = (uint) ( Functions.Atol( BUTTON_HREF_ID__DOLLAR__[ BUTTON ] ) ) ; 
            __context__.SourceCodeLine = 158;
            COMPONENT . AddButton ( (uint)( BUTTON_HREF_ID[ BUTTON ] )) ; 
            __context__.SourceCodeLine = 154;
            } 
        
        __context__.SourceCodeLine = 159;
        ; 
        
        
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
        
        __context__.SourceCodeLine = 174;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    BUTTON_HREF_ID  = new uint[ 51 ];
    
    INIT = new Crestron.Logos.SplusObjects.DigitalInput( INIT__DigitalInput__, this );
    m_DigitalInputList.Add( INIT__DigitalInput__, INIT );
    
    BUTTON = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        BUTTON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON__DigitalInput__ + i, BUTTON__DigitalInput__, this );
        m_DigitalInputList.Add( BUTTON__DigitalInput__ + i, BUTTON[i+1] );
    }
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    PRESS = new InOutArray<DigitalOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        PRESS[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PRESS__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PRESS__DigitalOutput__ + i, PRESS[i+1] );
    }
    
    BUTTON_HREF_ID__DOLLAR__ = new InOutArray<StringInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        BUTTON_HREF_ID__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( BUTTON_HREF_ID__DOLLAR____AnalogSerialInput__ + i, BUTTON_HREF_ID__DOLLAR____AnalogSerialInput__, 255, this );
        m_StringInputList.Add( BUTTON_HREF_ID__DOLLAR____AnalogSerialInput__ + i, BUTTON_HREF_ID__DOLLAR__[i+1] );
    }
    
    COMMAND_PROCESSOR_ID = new UShortParameter( COMMAND_PROCESSOR_ID__Parameter__, this );
    m_ParameterList.Add( COMMAND_PROCESSOR_ID__Parameter__, COMMAND_PROCESSOR_ID );
    
    MODE = new UShortParameter( MODE__Parameter__, this );
    m_ParameterList.Add( MODE__Parameter__, MODE );
    
    MULTITAP_INTERVAL = new UShortParameter( MULTITAP_INTERVAL__Parameter__, this );
    m_ParameterList.Add( MULTITAP_INTERVAL__Parameter__, MULTITAP_INTERVAL );
    
    
    for( uint i = 0; i < 50; i++ )
        BUTTON[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_OnPush_0, false ) );
        
    for( uint i = 0; i < 50; i++ )
        BUTTON[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( BUTTON_OnRelease_1, false ) );
        
    INIT.OnDigitalPush.Add( new InputChangeHandlerWrapper( INIT_OnPush_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    COMPONENT  = new Lutron.Leap.CommLib.Components.ButtonComponent();
    
    
}

public UserModuleClass_LUTRON_HOMEWORKS_QSX_BUTTON_CONTROL__CF_V1_0_ ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INIT__DigitalInput__ = 0;
const uint BUTTON__DigitalInput__ = 1;
const uint BUTTON_HREF_ID__DOLLAR____AnalogSerialInput__ = 0;
const uint IS_INITIALIZED__DigitalOutput__ = 0;
const uint PRESS__DigitalOutput__ = 1;
const uint COMMAND_PROCESSOR_ID__Parameter__ = 10;
const uint MODE__Parameter__ = 11;
const uint MULTITAP_INTERVAL__Parameter__ = 12;

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
