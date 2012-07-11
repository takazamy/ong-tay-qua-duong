using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TestDirectX2.Core
{
    public class DxTimer
    {
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceFrequency(ref long Frequency);
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceCounter(ref long Count);

        private static long lLastTime = 0;
        private static long lCurrentTime = 0;
        private static long lTicksPerSecond = 0;

        public static long TicksPerSecond
        {
            get { return lTicksPerSecond; }
           
        }
        private static bool bInitialized = false;
        private static double dElapsedSeconds = 0.0;
        private static double dElapsedMilliseconds = 0.0;

        public static void Init()
        {
            if (!QueryPerformanceFrequency(ref lTicksPerSecond))
            {
                throw new Exception("Performance Counter not supported!");
            }
            bInitialized = true;
        }

        public static void Start()
        {

            if (!bInitialized)
            {
                throw new Exception("Timer not Initialized!!");
            }

            QueryPerformanceCounter(ref lLastTime);
        }

        public static double GetElapsedMilliseconds()
        {
            if (!bInitialized)
            {
                throw new Exception("Timer not Initialized!!");
            }
            QueryPerformanceCounter(ref lCurrentTime);
            dElapsedMilliseconds = ((double)(lCurrentTime - lLastTime) / (double)lTicksPerSecond) * 1000.0;
            lLastTime = lCurrentTime;
            return dElapsedMilliseconds;
        }

        public static double GetElapsedSeconds()
        {
            if (!bInitialized)
            {
                throw new Exception("Timer not initialized!!");
            }
            QueryPerformanceCounter(ref lCurrentTime);
            dElapsedSeconds = (double)(lCurrentTime - lLastTime) /
            (double)lTicksPerSecond;
            lLastTime = lCurrentTime;
            return dElapsedSeconds;
        
        }

        public static void Reset()
        {
            QueryPerformanceCounter(ref lLastTime);
        }
       
    }
}
