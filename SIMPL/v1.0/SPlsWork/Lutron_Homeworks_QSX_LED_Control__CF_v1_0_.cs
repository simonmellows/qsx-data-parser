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

namespace UserModule_LUTRON_HOMEWORKS_QSX_LED_CONTROL__CF_V1_0_
{
    public class UserModuleClass_LUTRON_HOMEWORKS_QSX_LED_CONTROL__CF_V1_0_ : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LED_STATE;
        Crestron.Logos.SplusObjects.DigitalInput INIT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> LED_INPUT;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> LED_HREF_ID__DOLLAR__;
        UShortParameter COMMAND_PROCESSOR_ID;
        Lutron.Leap.CommLib.Components.LEDComponent COMPONENT;
        uint [] LED_HREF_ID;
        public void ONINITIALIZATIONCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.LEDComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.InitializationEventArgs ARGS ) 
            { 
            LEDComponent  SENDER  = (LEDComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 103;
                IS_INITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONLEDSTATUSCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.LEDComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.LEDStatusEventArgs ARGS ) 
            { 
            LEDComponent  SENDER  = (LEDComponent )__sender__;
            ushort LED = 0;
            
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 110;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)50; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( LED  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (LED  >= __FN_FORSTART_VAL__1) && (LED  <= __FN_FOREND_VAL__1) ) : ( (LED  <= __FN_FORSTART_VAL__1) && (LED  >= __FN_FOREND_VAL__1) ) ; LED  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 112;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.Payload.Id == LED_HREF_ID[ LED ]))  ) ) 
                        {
                        __context__.SourceCodeLine = 113;
                        LED_STATE [ LED]  .Value = (ushort) ( ARGS.Payload.Status ) ; 
                        }
                    
                    __context__.SourceCodeLine = 110;
                    } 
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object LED_INPUT_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort LED = 0;
                
                
                __context__.SourceCodeLine = 126;
                LED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 128;
                COMPONENT . SetLEDControl ( (uint)( LED_HREF_ID[ LED ] ), (ushort)( LED_INPUT[ LED ] .UshortValue )) ; 
                
                
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
            ushort LED = 0;
            
            
            __context__.SourceCodeLine = 136;
            // RegisterEvent( COMPONENT , ONINITIALIZATIONCHANGE , ONINITIALIZATIONCHANGE ) 
            try { g_criticalSection.Enter(); COMPONENT .OnInitializationChange  += ONINITIALIZATIONCHANGE; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 137;
            // RegisterEvent( COMPONENT , ONLEDSTATUSCHANGE , ONLEDSTATUSCHANGE ) 
            try { g_criticalSection.Enter(); COMPONENT .OnLEDStatusChange  += ONLEDSTATUSCHANGE; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 139;
            COMPONENT . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value )) ; 
            __context__.SourceCodeLine = 141;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( LED  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (LED  >= __FN_FORSTART_VAL__1) && (LED  <= __FN_FOREND_VAL__1) ) : ( (LED  <= __FN_FORSTART_VAL__1) && (LED  >= __FN_FOREND_VAL__1) ) ; LED  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 143;
                LED_HREF_ID [ LED] = (uint) ( Functions.Atol( LED_HREF_ID__DOLLAR__[ LED ] ) ) ; 
                __context__.SourceCodeLine = 145;
                COMPONENT . AddLEDStatus ( (uint)( LED_HREF_ID[ LED ] )) ; 
                __context__.SourceCodeLine = 141;
                } 
            
            
            
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
        
        __context__.SourceCodeLine = 161;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    LED_HREF_ID  = new uint[ 51 ];
    
    INIT = new Crestron.Logos.SplusObjects.DigitalInput( INIT__DigitalInput__, this );
    m_DigitalInputList.Add( INIT__DigitalInput__, INIT );
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    LED_INPUT = new InOutArray<AnalogInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        LED_INPUT[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( LED_INPUT__AnalogSerialInput__ + i, LED_INPUT__AnalogSerialInput__, this );
        m_AnalogInputList.Add( LED_INPUT__AnalogSerialInput__ + i, LED_INPUT[i+1] );
    }
    
    LED_STATE = new InOutArray<AnalogOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        LED_STATE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LED_STATE__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LED_STATE__AnalogSerialOutput__ + i, LED_STATE[i+1] );
    }
    
    LED_HREF_ID__DOLLAR__ = new InOutArray<StringInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        LED_HREF_ID__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( LED_HREF_ID__DOLLAR____AnalogSerialInput__ + i, LED_HREF_ID__DOLLAR____AnalogSerialInput__, 255, this );
        m_StringInputList.Add( LED_HREF_ID__DOLLAR____AnalogSerialInput__ + i, LED_HREF_ID__DOLLAR__[i+1] );
    }
    
    COMMAND_PROCESSOR_ID = new UShortParameter( COMMAND_PROCESSOR_ID__Parameter__, this );
    m_ParameterList.Add( COMMAND_PROCESSOR_ID__Parameter__, COMMAND_PROCESSOR_ID );
    
    
    for( uint i = 0; i < 50; i++ )
        LED_INPUT[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( LED_INPUT_OnChange_0, true ) );
        
    INIT.OnDigitalPush.Add( new InputChangeHandlerWrapper( INIT_OnPush_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    COMPONENT  = new Lutron.Leap.CommLib.Components.LEDComponent();
    
    
}

public UserModuleClass_LUTRON_HOMEWORKS_QSX_LED_CONTROL__CF_V1_0_ ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint IS_INITIALIZED__DigitalOutput__ = 0;
const uint LED_STATE__AnalogSerialOutput__ = 0;
const uint INIT__DigitalInput__ = 0;
const uint LED_INPUT__AnalogSerialInput__ = 0;
const uint LED_HREF_ID__DOLLAR____AnalogSerialInput__ = 50;
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
