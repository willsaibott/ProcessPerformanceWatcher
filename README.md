# ProcessPerformanceWatcher
Visual Studio C# Project of Process Performance Monitoring on Windows


Goal:
This project isn't completed yet. 
The main goal of this project is to query performance counters of network and IO usage of a process.

I'm currenlty able to query IO usage by process and network (bytes sent/s and bytes recv/s) usage by Network Adapter
The next step is to query network usage by process and make this project a dll compatible with C/C++.

To get the network usage information by process, there's no default windows PerformanceCounter provided by windows,
but it's possible. We need to query IPV4/IPV6 Table statistics, and filter by UDP/TCP protocol statistics and sum 
all traffic information for each entry (connection by pid/port traffic statistic).
