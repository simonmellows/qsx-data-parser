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

namespace UserModule_LUTRON_HOMEWORKS_QSX_COMMAND_PROCESSOR
{
    public class UserModuleClass_LUTRON_HOMEWORKS_QSX_COMMAND_PROCESSOR : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONNECT;
        Crestron.Logos.SplusObjects.DigitalInput DISCONNECT;
        Crestron.Logos.SplusObjects.DigitalInput DEBUG;
        Crestron.Logos.SplusObjects.StringInput IP_ADDRESS;
        Crestron.Logos.SplusObjects.DigitalOutput IS_COMMUNICATING;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        UShortParameter COMMAND_PROCESSOR_ID;
        StringParameter IPADDRESS;
        StringParameter USERNAME;
        StringParameter PASSWORD;
        Lutron.Leap.CommLib.CommandProcessor PROCESSOR;
        ushort READY = 0;
        object CONNECT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 109;
                if ( Functions.TestForTrue  ( ( READY)  ) ) 
                    {
                    __context__.SourceCodeLine = 110;
                    PROCESSOR . Connect ( ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DISCONNECT_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 115;
            if ( Functions.TestForTrue  ( ( READY)  ) ) 
                {
                __context__.SourceCodeLine = 116;
                PROCESSOR . Disconnect ( ) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object IP_ADDRESS_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 121;
        PROCESSOR . IPAddress  =  ( IP_ADDRESS  )  .ToString() ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void ONCOMMUNICATIONCHANGE ( object __sender__ /*Lutron.Leap.CommLib.CommandProcessor SENDER */, Lutron.Leap.CommLib.Event_Arguments.CommunicatingEventArgs ARGS ) 
    { 
    CommandProcessor  SENDER  = (CommandProcessor )__sender__;
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 130;
        IS_COMMUNICATING  .Value = (ushort) ( ARGS.Payload ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public void ONINITIALIZATIONCHANGE ( object __sender__ /*Lutron.Leap.CommLib.CommandProcessor SENDER */, Lutron.Leap.CommLib.Event_Arguments.InitializationEventArgs ARGS ) 
    { 
    CommandProcessor  SENDER  = (CommandProcessor )__sender__;
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 135;
        IS_INITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public void ONDEBUGMESSAGE ( object __sender__ /*Lutron.Leap.CommLib.CommandProcessor SENDER */, Lutron.Leap.CommLib.Event_Arguments.DebugEventArgs ARGS ) 
    { 
    CommandProcessor  SENDER  = (CommandProcessor )__sender__;
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 140;
        if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 141;
            Trace( "{0}", ARGS . Payload ) ; 
            }
        
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public void ONREADYSTATE ( object __sender__ /*Lutron.Leap.CommLib.CommandProcessor SENDER */, EventArgs ARGS ) 
    { 
    CommandProcessor  SENDER  = (CommandProcessor )__sender__;
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 146;
        READY = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 148;
        if ( Functions.TestForTrue  ( ( CONNECT  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 149;
            PROCESSOR . Connect ( ) ; 
            }
        
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    CrestronString IP;
    IP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 162;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 164;
        // RegisterEvent( PROCESSOR , ONINITIALIZATIONCHANGE , ONINITIALIZATIONCHANGE ) 
        try { g_criticalSection.Enter(); PROCESSOR .OnInitializationChange  += ONINITIALIZATIONCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 165;
        // RegisterEvent( PROCESSOR , ONCOMMUNICATIONCHANGE , ONCOMMUNICATIONCHANGE ) 
        try { g_criticalSection.Enter(); PROCESSOR .OnCommunicationChange  += ONCOMMUNICATIONCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 166;
        // RegisterEvent( PROCESSOR , ONDEBUGMESSAGE , ONDEBUGMESSAGE ) 
        try { g_criticalSection.Enter(); PROCESSOR .OnDebugMessage  += ONDEBUGMESSAGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 167;
        // RegisterEvent( PROCESSOR , ONREADYSTATE , ONREADYSTATE ) 
        try { g_criticalSection.Enter(); PROCESSOR .OnReadyState  += ONREADYSTATE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 169;
        IP  .UpdateValue ( PROCESSOR . IPAddress  ) ; 
        __context__.SourceCodeLine = 171;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( IP ) <= 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 172;
            IP  .UpdateValue ( IPADDRESS  ) ; 
            }
        
        __context__.SourceCodeLine = 174;
        PROCESSOR . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value ), IP .ToString(), USERNAME  .ToString(), PASSWORD  .ToString()) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    CONNECT = new Crestron.Logos.SplusObjects.DigitalInput( CONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( CONNECT__DigitalInput__, CONNECT );
    
    DISCONNECT = new Crestron.Logos.SplusObjects.DigitalInput( DISCONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( DISCONNECT__DigitalInput__, DISCONNECT );
    
    DEBUG = new Crestron.Logos.SplusObjects.DigitalInput( DEBUG__DigitalInput__, this );
    m_DigitalInputList.Add( DEBUG__DigitalInput__, DEBUG );
    
    IS_COMMUNICATING = new Crestron.Logos.SplusObjects.DigitalOutput( IS_COMMUNICATING__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_COMMUNICATING__DigitalOutput__, IS_COMMUNICATING );
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    IP_ADDRESS = new Crestron.Logos.SplusObjects.StringInput( IP_ADDRESS__AnalogSerialInput__, 100, this );
    m_StringInputList.Add( IP_ADDRESS__AnalogSerialInput__, IP_ADDRESS );
    
    COMMAND_PROCESSOR_ID = new UShortParameter( COMMAND_PROCESSOR_ID__Parameter__, this );
    m_ParameterList.Add( COMMAND_PROCESSOR_ID__Parameter__, COMMAND_PROCESSOR_ID );
    
    IPADDRESS = new StringParameter( IPADDRESS__Parameter__, this );
    m_ParameterList.Add( IPADDRESS__Parameter__, IPADDRESS );
    
    USERNAME = new StringParameter( USERNAME__Parameter__, this );
    m_ParameterList.Add( USERNAME__Parameter__, USERNAME );
    
    PASSWORD = new StringParameter( PASSWORD__Parameter__, this );
    m_ParameterList.Add( PASSWORD__Parameter__, PASSWORD );
    
    
    CONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONNECT_OnPush_0, false ) );
    DISCONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISCONNECT_OnPush_1, false ) );
    IP_ADDRESS.OnSerialChange.Add( new InputChangeHandlerWrapper( IP_ADDRESS_OnChange_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    PROCESSOR  = new Lutron.Leap.CommLib.CommandProcessor();
    
    
}

public UserModuleClass_LUTRON_HOMEWORKS_QSX_COMMAND_PROCESSOR ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CONNECT__DigitalInput__ = 0;
const uint DISCONNECT__DigitalInput__ = 1;
const uint DEBUG__DigitalInput__ = 2;
const uint IP_ADDRESS__AnalogSerialInput__ = 0;
const uint IS_COMMUNICATING__DigitalOutput__ = 0;
const uint IS_INITIALIZED__DigitalOutput__ = 1;
const uint COMMAND_PROCESSOR_ID__Parameter__ = 10;
const uint IPADDRESS__Parameter__ = 11;
const uint USERNAME__Parameter__ = 12;
const uint PASSWORD__Parameter__ = 13;

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
