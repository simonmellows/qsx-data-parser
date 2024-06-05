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
using Lutron.Leap.CommLib.Models.Bodies;
using Lutron.Leap.CommLib.Event_Arguments;
using Lutron.Leap.CommLib.Components;
using Lutron.Leap.CommLib.ComponentStates;
using Lutron.Leap.CommLib;
using Lutron.Leap.CommLib.Models;
using Lutron.Leap.CommLib.Components.SubComponents;
using Lutron.Leap.CommLib.Helper;
using Lutron.Leap.CommLib.LeapSupport;
using Lutron.Leap.CommLib.JsonSupport;
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

namespace UserModule_LUTRON_HOMEWORKS_QSX_KEYPAD_CONTROL__CF_V2_0_
{
    public class UserModuleClass_LUTRON_HOMEWORKS_QSX_KEYPAD_CONTROL__CF_V2_0_ : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INIT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> BUTTON_PRESS;
        Crestron.Logos.SplusObjects.StringInput KEYPAD_HREF_ID__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> BUTTON_ENABLED;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> BUTTON_LED_STATUS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> BUTTON_LABEL;
        UShortParameter COMMAND_PROCESSOR_ID;
        Lutron.Leap.CommLib.Components.KeypadComponent COMPONENT;
        public void ONINITIALIZATIONCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.KeypadComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.InitializationEventArgs ARGS ) 
            { 
            KeypadComponent  SENDER  = (KeypadComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 106;
                IS_INITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONKEYPADBUTTONLABELCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.KeypadComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.KeypadLabelEventArgs ARGS ) 
            { 
            KeypadComponent  SENDER  = (KeypadComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 111;
                BUTTON_LABEL [ ARGS.Id]  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONKEYPADBUTTONFEEDBACKCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.KeypadComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.KeypadButtonEventArgs ARGS ) 
            { 
            KeypadComponent  SENDER  = (KeypadComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 116;
                BUTTON_LED_STATUS [ ARGS.Id]  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONKEYPADBUTTONENABLECHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.KeypadComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.KeypadButtonEventArgs ARGS ) 
            { 
            KeypadComponent  SENDER  = (KeypadComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 121;
                BUTTON_ENABLED [ ARGS.Id]  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object BUTTON_PRESS_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 131;
                COMPONENT . ButtonPress ( (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object BUTTON_PRESS_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 135;
            COMPONENT . ButtonRelease ( (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) )) ; 
            
            
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
        
        __context__.SourceCodeLine = 141;
        // RegisterEvent( COMPONENT , ONINITIALIZATIONCHANGE , ONINITIALIZATIONCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnInitializationChange  += ONINITIALIZATIONCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 142;
        // RegisterEvent( COMPONENT , ONKEYPADBUTTONLABELCHANGE , ONKEYPADBUTTONLABELCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnKeypadButtonLabelChange  += ONKEYPADBUTTONLABELCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 143;
        // RegisterEvent( COMPONENT , ONKEYPADBUTTONFEEDBACKCHANGE , ONKEYPADBUTTONFEEDBACKCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnKeypadButtonFeedbackChange  += ONKEYPADBUTTONFEEDBACKCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 144;
        // RegisterEvent( COMPONENT , ONKEYPADBUTTONENABLECHANGE , ONKEYPADBUTTONENABLECHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnKeypadButtonEnableChange  += ONKEYPADBUTTONENABLECHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 147;
        COMPONENT . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value ), (uint)( Functions.Atol( KEYPAD_HREF_ID__DOLLAR__ ) )) ; 
        
        
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
        
        __context__.SourceCodeLine = 160;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    INIT = new Crestron.Logos.SplusObjects.DigitalInput( INIT__DigitalInput__, this );
    m_DigitalInputList.Add( INIT__DigitalInput__, INIT );
    
    BUTTON_PRESS = new InOutArray<DigitalInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        BUTTON_PRESS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_PRESS__DigitalInput__ + i, BUTTON_PRESS__DigitalInput__, this );
        m_DigitalInputList.Add( BUTTON_PRESS__DigitalInput__ + i, BUTTON_PRESS[i+1] );
    }
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    BUTTON_ENABLED = new InOutArray<DigitalOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        BUTTON_ENABLED[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( BUTTON_ENABLED__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( BUTTON_ENABLED__DigitalOutput__ + i, BUTTON_ENABLED[i+1] );
    }
    
    BUTTON_LED_STATUS = new InOutArray<AnalogOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        BUTTON_LED_STATUS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( BUTTON_LED_STATUS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( BUTTON_LED_STATUS__AnalogSerialOutput__ + i, BUTTON_LED_STATUS[i+1] );
    }
    
    KEYPAD_HREF_ID__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( KEYPAD_HREF_ID__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( KEYPAD_HREF_ID__DOLLAR____AnalogSerialInput__, KEYPAD_HREF_ID__DOLLAR__ );
    
    BUTTON_LABEL = new InOutArray<StringOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        BUTTON_LABEL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( BUTTON_LABEL__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( BUTTON_LABEL__AnalogSerialOutput__ + i, BUTTON_LABEL[i+1] );
    }
    
    COMMAND_PROCESSOR_ID = new UShortParameter( COMMAND_PROCESSOR_ID__Parameter__, this );
    m_ParameterList.Add( COMMAND_PROCESSOR_ID__Parameter__, COMMAND_PROCESSOR_ID );
    
    
    for( uint i = 0; i < 50; i++ )
        BUTTON_PRESS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_PRESS_OnPush_0, false ) );
        
    for( uint i = 0; i < 50; i++ )
        BUTTON_PRESS[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( BUTTON_PRESS_OnRelease_1, false ) );
        
    INIT.OnDigitalPush.Add( new InputChangeHandlerWrapper( INIT_OnPush_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    COMPONENT  = new Lutron.Leap.CommLib.Components.KeypadComponent();
    
    
}

public UserModuleClass_LUTRON_HOMEWORKS_QSX_KEYPAD_CONTROL__CF_V2_0_ ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INIT__DigitalInput__ = 0;
const uint BUTTON_PRESS__DigitalInput__ = 1;
const uint KEYPAD_HREF_ID__DOLLAR____AnalogSerialInput__ = 0;
const uint IS_INITIALIZED__DigitalOutput__ = 0;
const uint BUTTON_ENABLED__DigitalOutput__ = 1;
const uint BUTTON_LED_STATUS__AnalogSerialOutput__ = 0;
const uint BUTTON_LABEL__AnalogSerialOutput__ = 50;
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
