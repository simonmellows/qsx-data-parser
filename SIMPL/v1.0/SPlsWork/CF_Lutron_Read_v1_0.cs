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
using QsxDataExtractor;
using Crestron.SimplSharp.Python;

namespace UserModule_CF_LUTRON_READ_V1_0
{
    public class UserModuleClass_CF_LUTRON_READ_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput READDATA;
        Crestron.Logos.SplusObjects.DigitalOutput READCOMPLETE;
        Crestron.Logos.SplusObjects.StringOutput STATUS;
        StringParameter CSVFILEPATH;
        object READDATA_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString S;
                S  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
                
                
                __context__.SourceCodeLine = 68;
                S  .UpdateValue ( DataExtractor . ReadData (  CSVFILEPATH   .ToString() )  ) ; 
                __context__.SourceCodeLine = 69;
                STATUS  .UpdateValue ( S  ) ; 
                __context__.SourceCodeLine = 70;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (S == "File read complete. Status: SUCCESS"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 72;
                    READCOMPLETE  .Value = (ushort) ( 1 ) ; 
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
            
            __context__.SourceCodeLine = 83;
            WaitForInitializationComplete ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        READDATA = new Crestron.Logos.SplusObjects.DigitalInput( READDATA__DigitalInput__, this );
        m_DigitalInputList.Add( READDATA__DigitalInput__, READDATA );
        
        READCOMPLETE = new Crestron.Logos.SplusObjects.DigitalOutput( READCOMPLETE__DigitalOutput__, this );
        m_DigitalOutputList.Add( READCOMPLETE__DigitalOutput__, READCOMPLETE );
        
        STATUS = new Crestron.Logos.SplusObjects.StringOutput( STATUS__AnalogSerialOutput__, this );
        m_StringOutputList.Add( STATUS__AnalogSerialOutput__, STATUS );
        
        CSVFILEPATH = new StringParameter( CSVFILEPATH__Parameter__, this );
        m_ParameterList.Add( CSVFILEPATH__Parameter__, CSVFILEPATH );
        
        
        READDATA.OnDigitalPush.Add( new InputChangeHandlerWrapper( READDATA_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_CF_LUTRON_READ_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint READDATA__DigitalInput__ = 0;
    const uint READCOMPLETE__DigitalOutput__ = 0;
    const uint STATUS__AnalogSerialOutput__ = 0;
    const uint CSVFILEPATH__Parameter__ = 10;
    
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
