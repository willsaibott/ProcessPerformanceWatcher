# ProcessPerformanceWatcher
Visual Studio C# Project of Process Performance Monitoring on Windows


Goal:
This project isn't completed yet. 
The main goal of this project is to query performance counters of network and IO usage of a process.

To get the network usage information by process, there's no default windows PerformanceCounter provided by windows,
but it's possible. We need to query IPV4/IPV6 Table statistics, and filter by UDP/TCP protocol statistics and sum 
all traffic information for each entry (connection by pid/port traffic statistic).

This project has neither optimized code, nor standarized and well structured code. I've spent now 5 hours! =). 
Please, forgive me!

I'm planning to transform this in a solution with 3 projects: 
1. Library
2. Application code that uses the library
3. Test Project

I'll come back to this project as soon as I can make the same thing in pure C++.

New Features:

1. I'm able to get network information by process/pid now, But this is information is only filtered by PID,
it means that it's not, currently, filtered by network interface or connection port yet.