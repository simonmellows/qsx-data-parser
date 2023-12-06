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

namespace UserModule_CF_LUTRON_SCENES_V1_0
{
    public class UserModuleClass_CF_LUTRON_SCENES_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput GETDATA;
        Crestron.Logos.SplusObjects.StringInput AREAHREF;
        Crestron.Logos.SplusObjects.DigitalOutput DATAREADY;
        Crestron.Logos.SplusObjects.StringOutput ERROR;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SCENELABEL;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SCENEHREF;
        object GETDATA_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort X = 0;
                ushort STATUS = 0;
                
                QsxDataExtractor.sceneDataStruct DATA;
                DATA  = new QsxDataExtractor.sceneDataStruct();
                
                
                __context__.SourceCodeLine = 69;
                if ( Functions.TestForTrue  ( ( Functions.Length( AREAHREF ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 71;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)17; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 73;
                        SCENELABEL [ X]  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 74;
                        SCENEHREF [ X]  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 76;
                        STATUS = (ushort) ( DataExtractor.GetSceneData( ref DATA , AREAHREF .ToString() , (int)( X ) , "" ) ) ; 
                        __context__.SourceCodeLine = 78;
                        if ( Functions.TestForTrue  ( ( STATUS)  ) ) 
                            { 
                            __context__.SourceCodeLine = 79;
                            SCENELABEL [ X]  .UpdateValue ( DATA . label  ) ; 
                            __context__.SourceCodeLine = 80;
                            SCENEHREF [ X]  .UpdateValue ( DATA . href  ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 71;
                        } 
                    
                    __context__.SourceCodeLine = 83;
                    DATAREADY  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 87;
                    ERROR  .UpdateValue ( "No area specified"  ) ; 
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
            
            __context__.SourceCodeLine = 99;
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
        
        GETDATA = new Crestron.Logos.SplusObjects.DigitalInput( GETDATA__DigitalInput__, this );
        m_DigitalInputList.Add( GETDATA__DigitalInput__, GETDATA );
        
        DATAREADY = new Crestron.Logos.SplusObjects.DigitalOutput( DATAREADY__DigitalOutput__, this );
        m_DigitalOutputList.Add( DATAREADY__DigitalOutput__, DATAREADY );
        
        AREAHREF = new Crestron.Logos.SplusObjects.StringInput( AREAHREF__AnalogSerialInput__, 255, this );
        m_StringInputList.Add( AREAHREF__AnalogSerialInput__, AREAHREF );
        
        ERROR = new Crestron.Logos.SplusObjects.StringOutput( ERROR__AnalogSerialOutput__, this );
        m_StringOutputList.Add( ERROR__AnalogSerialOutput__, ERROR );
        
        SCENELABEL = new InOutArray<StringOutput>( 17, this );
        for( uint i = 0; i < 17; i++ )
        {
            SCENELABEL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SCENELABEL__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( SCENELABEL__AnalogSerialOutput__ + i, SCENELABEL[i+1] );
        }
        
        SCENEHREF = new InOutArray<StringOutput>( 17, this );
        for( uint i = 0; i < 17; i++ )
        {
            SCENEHREF[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SCENEHREF__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( SCENEHREF__AnalogSerialOutput__ + i, SCENEHREF[i+1] );
        }
        
        
        GETDATA.OnDigitalPush.Add( new InputChangeHandlerWrapper( GETDATA_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_CF_LUTRON_SCENES_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint GETDATA__DigitalInput__ = 0;
    const uint AREAHREF__AnalogSerialInput__ = 0;
    const uint DATAREADY__DigitalOutput__ = 0;
    const uint ERROR__AnalogSerialOutput__ = 0;
    const uint SCENELABEL__AnalogSerialOutput__ = 1;
    const uint SCENEHREF__AnalogSerialOutput__ = 18;
    
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
