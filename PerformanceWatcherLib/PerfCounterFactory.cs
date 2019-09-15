using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessPerformanceWatcher
{
    public static class PerfCounterNames
    {
        public enum _ {
            //IO_READ_OPERATIONS_BY_SEC,      //new PerformanceCounter("Process", "IO Read Operations/sec", instance_name),
            //IO_WRITE_OPERATIONS_BY_SEC,     //new PerformanceCounter("Process", "IO Write Operations/sec", instance_name),
            //IO_DATA_OPERATIONS_BY_SEC,      //new PerformanceCounter("Process", "IO Data Operations/sec", instance_name),
            IO_READ_BYTES_BY_SEC,           //new PerformanceCounter("Process", "IO Read Bytes/sec", instance_name),
            IO_WRITE_BYTES_BY_SEC,          //new PerformanceCounter("Process", "IO Write Bytes/sec", instance_name),
            IO_DATA_BYTES_BY_SEC,           //new PerformanceCounter("Process", "IO Data Bytes/sec", instance_name),
            NETWORK_BYTES_SENT,             //new PerformanceCounter(".NET CLR Networking", "Bytes Sent",         instance_name),
            NETWORK_BYTES_RECEIVED,         //new PerformanceCounter(".NET CLR Networking", "Bytes Received",     instance_name),
            NETWORK_BYTES_SENT_BY_SEC,      //new PerformanceCounter(".NET CLR Networking", "Bytes Sent/sec",     instance_name),
            NETWORK_BYTES_RECEIVED_BY_SEC,  //new PerformanceCounter(".NET CLR Networking", "Bytes Received/sec", instance_name),
        }

        /**
         *  34458
            Network bytes sent
            34460
            Network bytes received
            4982
            In - Total bytes received
            4984
            Out - Total bytes sent
            6388
            Offloaded Bytes Received/sec
            6390
            Offloaded Bytes Sent/sec
            7434
            Bytes transmitted/sec
            7612
            Sent Bytes/sec
            7502
            Sent Bytes/sec
         */
        public static readonly string[] names = {
            //"IO Read Operations/sec", "IO Write Operations/sec", "IO Data Operations/sec",
            "Read Bytes/sec", "Write Bytes/sec", "Data Bytes/sec",
            "Bytes Sent", "Bytes Received", "Sent Bytes/sec", "Bytes Received/sec"
        };

        public static readonly long[] indexes = {
            7526, 7518, 7578,
            4712, 4722, 7502, 8428
        };
    }
    class PerfCounterFactory
    {

    }
}
