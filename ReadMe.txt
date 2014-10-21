A process is an inert container
	 Defines a virtual address space
		Contents not addressable from another process
	 Libraries of code are mapped in to the address space

Threads execute code
	A path of executuion through any/all code within a single process
	Have access to any/all data within thar process
		for managed threads,within an AppDomain
	Each thread has its own callstack & copy of the CPU registers
		technically,a CLI implementation-specific detail
	A process with no threads exits(because it can no longer perform work)