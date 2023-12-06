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
using Crestron.SimplSharp;

namespace CrestronModule_INITIALPARAMETERS
{
    public class CrestronModuleClass_INITIALPARAMETERS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.StringOutput ROOMID;
        Crestron.Logos.SplusObjects.StringOutput ROOMNAME;
        Crestron.Logos.SplusObjects.DigitalOutput DEVICEPLATFORMAPPLIANCE;
        Crestron.Logos.SplusObjects.DigitalOutput DEVICEPLATFORMSERVER;
        private void REFRESH (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 37;
            ROOMID  .UpdateValue ( InitialParametersAdapter . RoomId  ) ; 
            __context__.SourceCodeLine = 38;
            ROOMNAME  .UpdateValue ( InitialParametersAdapter . RoomName  ) ; 
            __context__.SourceCodeLine = 40;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (InitialParametersAdapter.DevicePlatform == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 42;
                DEVICEPLATFORMSERVER  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 43;
                DEVICEPLATFORMAPPLIANCE  .Value = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 46;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (InitialParametersAdapter.DevicePlatform == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 48;
                DEVICEPLATFORMAPPLIANCE  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 49;
                DEVICEPLATFORMSERVER  .Value = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 52;
            Print( "FirmwareVersion = {0}\r\n", InitialParametersAdapter . FirmwareVersion ) ; 
            __context__.SourceCodeLine = 53;
            Print( "ControllerPromptName = {0}\r\n", InitialParametersAdapter . ControllerPromptName ) ; 
            
            }
            
        public override object FunctionMain (  object __obj__ ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusFunctionMainStartCode();
                
                __context__.SourceCodeLine = 58;
                REFRESH (  __context__  ) ; 
                __context__.SourceCodeLine = 60;
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
            
            DEVICEPLATFORMAPPLIANCE = new Crestron.Logos.SplusObjects.DigitalOutput( DEVICEPLATFORMAPPLIANCE__DigitalOutput__, this );
            m_DigitalOutputList.Add( DEVICEPLATFORMAPPLIANCE__DigitalOutput__, DEVICEPLATFORMAPPLIANCE );
            
            DEVICEPLATFORMSERVER = new Crestron.Logos.SplusObjects.DigitalOutput( DEVICEPLATFORMSERVER__DigitalOutput__, this );
            m_DigitalOutputList.Add( DEVICEPLATFORMSERVER__DigitalOutput__, DEVICEPLATFORMSERVER );
            
            ROOMID = new Crestron.Logos.SplusObjects.StringOutput( ROOMID__AnalogSerialOutput__, this );
            m_StringOutputList.Add( ROOMID__AnalogSerialOutput__, ROOMID );
            
            ROOMNAME = new Crestron.Logos.SplusObjects.StringOutput( ROOMNAME__AnalogSerialOutput__, this );
            m_StringOutputList.Add( ROOMNAME__AnalogSerialOutput__, ROOMNAME );
            
            
            
            _SplusNVRAM.PopulateCustomAttributeList( true );
            
            NVRAM = _SplusNVRAM;
            
        }
        
        public override void LogosSimplSharpInitialize()
        {
            
            
        }
        
        public CrestronModuleClass_INITIALPARAMETERS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
        
        
        
        
        const uint ROOMID__AnalogSerialOutput__ = 0;
        const uint ROOMNAME__AnalogSerialOutput__ = 1;
        const uint DEVICEPLATFORMAPPLIANCE__DigitalOutput__ = 0;
        const uint DEVICEPLATFORMSERVER__DigitalOutput__ = 1;
        
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
