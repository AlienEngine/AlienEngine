using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Microsoft.Win32;

namespace AlienEngine.Core.Utils
{
    /// <summary>
    /// Defines functionality for displaying detailed information about the
    /// computer CPU. Makes use of "assembler.dll", which is written in "C"
    /// and "Assembler commands".
    /// </summary>
    internal static class CPUInfo
    {
        private const string Library = "Assembler.dll";

        [DllImport(Library, CallingConvention = CallingConvention.StdCall, EntryPoint = "_cpuid")]
        [System.Security.SuppressUnmanagedCodeSecurity()]
        private static extern void __cpuid(uint function, uint subfunction);

        [DllImport(Library, CallingConvention = CallingConvention.StdCall, EntryPoint = "_rdtsc")]
        [System.Security.SuppressUnmanagedCodeSecurity()]
        private static extern void __rdtsc();

        [DllImport(Library, CallingConvention = CallingConvention.StdCall, EntryPoint = "_reg_eax")]
        [System.Security.SuppressUnmanagedCodeSecurity()]
        private static extern uint __reg_eax();

        [DllImport(Library, CallingConvention = CallingConvention.StdCall, EntryPoint = "_reg_ebx")]
        [System.Security.SuppressUnmanagedCodeSecurity()]
        private static extern uint __reg_ebx();

        [DllImport(Library, CallingConvention = CallingConvention.StdCall, EntryPoint = "_reg_ecx")]
        [System.Security.SuppressUnmanagedCodeSecurity()]
        private static extern uint __reg_ecx();

        [DllImport(Library, CallingConvention = CallingConvention.StdCall, EntryPoint = "_reg_edx")]
        [System.Security.SuppressUnmanagedCodeSecurity()]
        private static extern uint __reg_edx();

        public static byte CPUType = 0;
        public static byte CPUFamily = 0;
        public static byte CPUExtendedFamily = 0;
        public static byte CPUModel = 0;
        public static byte CPUExtendedModel = 0;
        public static byte CPUStepping = 0;

        public static uint CPUSpeed = 0;                // in Mhz.

        public enum VendorCompanies : byte
        {
            Unknown = 0,
            AMD = 1,
            Centaur = 2,
            Cyrix = 3,
            Intel = 4,
            NationalSemiconductor = 5,
            NexGen = 6,
            Rise = 7,
            SiS = 8,
            Transmeta = 9,
            UMC = 10,
            VIA = 11,
            Vortex = 12
        }

        public enum Bits : uint
        {
            Bit00 = 0x00000001U,
            Bit01 = 0x00000002U,
            Bit02 = 0x00000004U,
            Bit03 = 0x00000008U,
            Bit04 = 0x00000010U,
            Bit05 = 0x00000020U,
            Bit06 = 0x00000040U,
            Bit07 = 0x00000080U,
            Bit08 = 0x00000100U,
            Bit09 = 0x00000200U,
            Bit10 = 0x00000400U,
            Bit11 = 0x00000800U,
            Bit12 = 0x00001000U,
            Bit13 = 0x00002000U,
            Bit14 = 0x00004000U,
            Bit15 = 0x00008000U,
            Bit16 = 0x00010000U,
            Bit17 = 0x00020000U,
            Bit18 = 0x00040000U,
            Bit19 = 0x00080000U,
            Bit20 = 0x00100000U,
            Bit21 = 0x00200000U,
            Bit22 = 0x00400000U,
            Bit23 = 0x00800000U,
            Bit24 = 0x01000000U,
            Bit25 = 0x02000000U,
            Bit26 = 0x04000000U,
            Bit27 = 0x08000000U,
            Bit28 = 0x10000000U,
            Bit29 = 0x20000000U,
            Bit30 = 0x40000000U,
            Bit31 = 0x80000000U
        }

        // Returned in CPUID(1).EDX
        private enum StandardFlags1_EDX : uint
        {
            FPU = Bits.Bit00,			        // Bit 00 = Floating point on chip
            VME = Bits.Bit01,			        // Bit 01 = Virtual Mode Extension
            DE = Bits.Bit02,		                // Bit 02 = Debugging Extension
            PSE = Bits.Bit03,			        // Bit 03 = Page Size Extension
            TSC = Bits.Bit04,			        // Bit 04 = Time Stamp Counter
            MSR = Bits.Bit05,			        // Bit 05 = Model Specific Registers
            PAE = Bits.Bit06,			        // Bit 06 = Physical Address Extension
            MCE = Bits.Bit07,			        // Bit 07 = Machine Check Exception
            CX8 = Bits.Bit08,			        // Bit 08 = CMPXCHG8 Instruction Support
            APIC = Bits.Bit09,		            // Bit 09 = APIC Support
            // Bit 10 = Reserved
            FSC = Bits.Bit11,			        // Bit 11 = Fast System Call
            MTRR = Bits.Bit12,		            // Bit 12 = Memory Type Range Registers
            PGE = Bits.Bit13,			        // Bit 13 = Page Global Enable
            MCA = Bits.Bit14,			        // Bit 14 = Machine Check Architecture
            CMOV = Bits.Bit15,		            // Bit 15 = Conditional Move Instruction Support
            PAT = Bits.Bit16,			        // Bit 16 = Page Attribute Table
            PSE36 = Bits.Bit17,		            // Bit 17 = 36bit Page Size Extension
            SERIAL = Bits.Bit18,		            // Bit 18 = Processor Serial Number
            CLFSH = Bits.Bit19,                  // Bit 19 = CLFLUSH Instruction Support
            // Bit 20 = Reserved
            DS = Bits.Bit21,			            // Bit 21 = Debug Store
            ACPI = Bits.Bit22,		            // Bit 22 = CPU Thermal and Speed Control
            MMX = Bits.Bit23,			        // Bit 23 = MMX Support
            FXSR = Bits.Bit24,		            // Bit 24 = Fast Floating Point Save and Restore
            SSE = Bits.Bit25,			        // Bit 25 = Streaming SIMD Support
            SSE2 = Bits.Bit26,		            // Bit 26 = Streaming SIMD 2 Support
            SS = Bits.Bit27,			            // Bit 27 = Self-Snoop
            HTT = Bits.Bit28,			        // Bit 28 = Hyper-Threading Technology
            TM = Bits.Bit29,			            // Bit 29 = Thermal Monitor
            IA64 = Bits.Bit30,                   // Bit 30 = IA64 Processor Emulating x86
            SBF = Bits.Bit31		                // Bit 31 = Signal Break on FERR
        }

        // Returned by CPUID(1).ECX
        private enum StandardFlags1_ECX : uint
        {
            SSE3 = Bits.Bit00,                   // Bit 00 = SSE3
            PCLMULQDQ = Bits.Bit01,              // Bit 01 = PCLMULQDQ Support
            DS64 = Bits.Bit02,                   // Bit 02 = Debug Store 64bit
            MONITOR = Bits.Bit03,                // Bit 03 = MONITOR and MWAIT instructions
            DSCPL = Bits.Bit04,                  // Bit 04 = Debug Store CPL Qualified
            VMX = Bits.Bit05,                    // Bit 05 = Virtual Machine eXtensions
            SMX = Bits.Bit06,                    // Bit 06 = Safer Mode Extensions
            ESS = Bits.Bit07,                    // Bit 07 = Enhanced SpeedStep
            TM2 = Bits.Bit08,                    // Bit 08 = Thermal Monitor 2
            SSSE3 = Bits.Bit09,                  // Bit 09 = Supplemental SSE3
            CNXTID = Bits.Bit10,                 // Bit 10 = L1 Context ID
            // Bit 11 = Reserved
            FMA = Bits.Bit12,                    // Bit 12 = Fused Multiply Add
            CX16 = Bits.Bit13,                   // Bit 13 = CMPXCHG16B
            XTPR = Bits.Bit14,                   // Bit 14 = XTPR Update Control
            PDCM = Bits.Bit15,                   // Bit 15 = Perfmon and Debug Capability
            // Bit 16 = Reserved
            PCID = Bits.Bit17,                   // Bit 17 = Process Context Identifiers
            DCA = Bits.Bit18,                    // Bit 18 = Direct Cache Access
            SSE4_1 = Bits.Bit19,                 // Bit 19 = SSE4.1
            SSE4_2 = Bits.Bit20,                 // Bit 20 = SSE4.2
            X2APIC = Bits.Bit21,                 // Bit 21 = Extended xAPIC Support
            MOVBE = Bits.Bit22,                  // Bit 22 = MOVBE Instruction
            POPCNT = Bits.Bit23,                 // Bit 23 = POPCNT Instruction
            TSCDEADLINE = Bits.Bit24,            // Bit 24 = Time Stamp Counter Deadline
            AES = Bits.Bit25,                    // Bit 25 = AES Instruction Extensions
            XSAVE = Bits.Bit26,                  // Bit 26 = XSAVE/XSTOR States
            OSXSAVE = Bits.Bit27,                // Bit 27 = OS-Enabled Extended State Management
            AVX = Bits.Bit28,                    // Bit 28 = Advanced Vector Extensions
            F16C = Bits.Bit29,                   // Bit 29 = Half-Precision Convert
            RDRAND = Bits.Bit30,					// Bit 30 = Read Random Number
            HV = Bits.Bit31						// Bit 31 = HyperVisor Present (and intercepting this bit, to advertise its presence)
        }

        // Returned by CPUID(7).EBX; Information taken from http://sandpile.org/x86/cpuid.htm
        private enum StandardFlags7_EBX : uint
        {
            FSGSBASE = Bits.Bit00,               // Bit 00 = CR4.FSGSBASE and [RD|WR][FS|GS]BASE
            TSC_ADJUST = Bits.Bit01,             // Bit 01 = TSC_ADJUST
            SGX = Bits.Bit02,                // Bit 02 = CR4.SEE, PRMRR, ENCLS and ENCLU, standard level 0000_0012h
            BMI1 = Bits.Bit03,               // Bit 03 = BMI1 and TZCNT
            HLE = Bits.Bit04,                // Bit 04 = XAQUIRE:, XRELEASE:, XTEST
            AVX2 = Bits.Bit05,               // Bit 05 = AVX2 (including VSIB)
            FPDP = Bits.Bit06,               // Bit 06 = FP_DP for non-control instructions only if unmasked exception(s)
            SMEP = Bits.Bit07,               // Bit 07 = CR4.SMEP
            BMI2 = Bits.Bit08,               // Bit 08 = BMI2
            ERMS = Bits.Bit09,               // Bit 09 = enhanced REP MOVSB/STOSB (while MISC_ENABLE.FSE=1)
            INVPCID = Bits.Bit10,                // Bit 10 = INVPCID
            RTM = Bits.Bit11,                // Bit 11 = XBEGIN, XABORT, XEND, XTEST, DR7.RTM, DR6.RTM
            PQM = Bits.Bit12,                // Bit 12 = platform quality of service monitoring
            FPCSDS = Bits.Bit13,             // Bit 13 = FP_CS and FP_DS always saved as 0000h
            MPX = Bits.Bit14,                // Bit 14 = XCR0.Breg, XCR0.BNDCSR, BNDCFGS/BNDCFGU/BNDSTATUS and BND0...BND3, BND:, MPX
            PQE = Bits.Bit15,                // Bit 15 = platform quality of service enforcement
            AVX512F = Bits.Bit16,                // Bit 16 = AVX512F, EVEX, ZMM0...31, K0...7, modifiers, VSIB512, disp8*N
            AVX512DQ = Bits.Bit17,               // Bit 17 = AVX512DQ
            RDSEED = Bits.Bit18,             // Bit 18 = RDSEED
            ADX = Bits.Bit19,                // Bit 19 = ADCX and ADOX
            SMAP = Bits.Bit20,               // Bit 20 = CR4.SMAP, CLAC and STAC
            AVX512IFMA = Bits.Bit21,             // Bit 21 = AVX512IFMA
            PCOMMIT = Bits.Bit22,                // Bit 22 = PCOMMIT
            CLFLUSHOPT = Bits.Bit23,             // Bit 23 = CLFLUSHOPT
            CLWB = Bits.Bit24,               // Bit 24 = CLWB
            PT = Bits.Bit25,             // Bit 25 = processor trace, standard level 0000_0014h
            AVX512PF = Bits.Bit26,               // Bit 26 = AVX512PF
            AVX512ER = Bits.Bit27,               // Bit 27 = AVX512ER
            AVX512CD = Bits.Bit28,               // Bit 28 = AVX512CD
            SHA = Bits.Bit29,                // Bit 29 = SHA
            AVX512BW = Bits.Bit30,               // Bit 30 = AVX512BW
            AVX512VL = Bits.Bit31                // Bit 31 = AVX512VL
        }

        // Returned by CPUID(7).ECX
        private enum StandardFlags7_ECX : uint
        {
            PREFETCHWT1 = Bits.Bit00,            // Bit 00 = PREFETCHWT1
            AVX512VBMI = Bits.Bit01,         // Bit 01 = AVX512VBMI
            UMIP = Bits.Bit02,           // Bit 02 = CR4.UMIP for #GP on SGDT, SIDT, SLDT, STR, and SMSW if CPL>0
            PKU = Bits.Bit03,            // Bit 03 = XCR0.PKRU, CR4.PKE, PKRU, RDPKRU/WRPKRU, PxE.PK, #PF.PK
            OSPKE = Bits.Bit04,          // Bit 04 = non-privileged read-only copy of current CR4.PKE value
                                                // Bits 05-06 = Reserved			
            CET = Bits.Bit07,            // Bit 07 = CR4.CET, XSS.CET_{U,S}, {U,S}_CET MSRs, PL{0,1,2,3}_SSP MSRs, 
                                                // IST_SSP MSR and 8-entry interrupt SSP table, #CP, SSP, TSS32.SSP,INCSSP,
                                                // RDSSP, SAVESSP, RSTORSSP, SETSSBSY, CLRSSBSY, WRSS, WRUSS, ENDBR32, ENDBR64, CALL/JMP Rv + no track (3Eh)
                                                // Bits 08-13 = Reserved
            AVX512VPDQ = Bits.Bit14,         // Bit 14 = VPOPCNT{D,Q}
                                                    // Bit 15 = Reserved
            VA57 = Bits.Bit16,           // Bit 16 = 5-level paging, CR4.VA57
                                                // Bits 17-21 = Reserved
            RDPID = Bits.Bit22,          // Bit 22 = RDPID, TSC_AUX
                                                // Bits 23-29 = Reserved
            SGX_LC = Bits.Bit30              // Bit 30 = SGX launch configuration
                                                    // Bit 31 = Reserved
        }

        // Returned by CPUID(7).EDX
        private enum StandardFlags7_EDX : uint
        {
            // Bits 00-01 = Reserved
            AVX512QVNNIW = Bits.Bit02,           // Bit 02 = VP4DPWSSD[S]
            AVX512QFMA = Bits.Bit03          // Bit 03 = V4F[N]MADD{PS,SS}
                                                    // Bits 04-31 = Reserved
        }

        // Returned in CPUID(0x80000001).EDX (Intel)
        private enum IntelExtendedFlags1_EDX : uint
        {
            // Bits 00-10 = Reserved
            SYSCALLSYSRET = Bits.Bit11,          // Bit 11 = The processor supports the SYSCALL and SYSRET instructions
            // Bits 12-19 = Reserved
            NX = Bits.Bit20,                     // Bit 20 = Execution Disable Bit
            // Bits 21-25 = Reserved
            PAGE1GB = Bits.Bit26,                // Bit 26 = The processor supports 1-GB pages
            RDTSCP = Bits.Bit27,                 // Bit 27 = The processor supports RDTSCP and IA32_TSC_AUX
            // Bit 28 = Reserved
            INTEL64 = Bits.Bit29,                // Bit 29 = The processor supports Intel® 64 Architecture extensions to the IA-32 Architecture
            // Bit 30 = Reserved
            // Bit 31 = Reserved
        }

        // Returned in CPUID(0x80000001).ECX (Intel)
        private enum IntelExtendedFlags1_ECX : uint
        {
            LAHFSAHF = Bits.Bit00,               // Bit 00 = LAHF and SAHF instruction support
            // Bits 01-31 = Reserved
        }

        // Returned in CPUID(0x80000001).EDX (AMD)
        private enum AMDExtendedFlags1_EDX : uint
        {
            // Bit 00 = FPU, same as CPUID(1).EDX
            // Bit 01 = VME, same as CPUID(1).EDX
            // Bit 02 = DE, same as CPUID(1).EDX
            // Bit 03 = PSE, same as CPUID(1).EDX
            // Bit 04 = TSC, same as CPUID(1).EDX
            // Bit 05 = MSR, same as CPUID(1).EDX
            // Bit 06 = PAE, same as CPUID(1).EDX
            // Bit 07 = MCE, same as CPUID(1).EDX
            // Bit 08 = CMPXCHG8B, same as CPUID(1).EDX
            // Bit 09 = APIC, same as CPUID(1).EDX
            // Bit 10 = Reserved
            SYSCALLSYSRET = Bits.Bit11,          // Bit 11 = SYSCALL and SYSRET instructions
            // Bit 12 = MTRR, same as CPUID(1).EDX
            // Bit 13 = PGE, same as CPUID(1).EDX
            // Bit 14 = MCA, same as CPUID(1).EDX
            // Bit 15 = CMOV, same as CPUID(1).EDX
            // Bit 16 = PAT, same as CPUID(1).EDX
            // Bit 17 = PSE36, same as CPUID(1).EDX
            // Bit 18 = Reserved
            // Bit 19 = Reserved
            NX = Bits.Bit20,                     // Bit 20 = No Execute page protection
            // Bit 21 = Reserved
            MMXEXT = Bits.Bit22,                 // Bit 22 = AMD MMX Extensions
            // Bit 23 = MMX, same as CPUID(1).EDX
            // Bit 24 = FXSR, same as CPUID(1).EDX
            FFXSR = Bits.Bit25,                  // Bit 25 = Fast FXSR
            PAGE1GB = Bits.Bit26,                // Bit 26 = 1 GB large page support
            RDTSCP = Bits.Bit27,                 // Bit 27 = RDTSCP instruction support
            // Bit 28 = Reserved
            LM = Bits.Bit29,                     // Bit 29 = Long Mode
            THREEDNOWEXT = Bits.Bit30,           // Bit 30 = 3DNOW! Extension Instructions
            THREEDNOW = Bits.Bit31               // Bit 31 = 3DNOW! Instructions
        }

        // Returned in CPUID(0x80000001).ECX (AMD)
        private enum AMDExtendedFlags1_ECX : uint
        {
            LAHFSAHF = Bits.Bit00,               // Bit 00 = LAHF and SAHF instruction support in 64-bit mode
            CMPLEGACY = Bits.Bit01,              // Bit 01 = Core multi-processing legacy mode
            SVM = Bits.Bit02,                    // Bit 02 = Secure Virtual Machine
            EXTAPICSPACE = Bits.Bit03,           // Bit 03 = extended APIC space
            ALTMOVCR8 = Bits.Bit04,              // Bit 04 = LOCK MOV CR0 means MOV CR8
            ABM = Bits.Bit05,                    // Bit 05 = advanced bit manipulation. LZCNT instruction support
            SSE4A = Bits.Bit06,                  // Bit 06 = EXTRQ, INSERTQ, MOVNTSS, and MOVNTSD instruction support
            MISALIGNSSE = Bits.Bit07,            // Bit 07 = misaligned SSE mode
            THREEDNOWPREFETCH = Bits.Bit08,      // Bit 08 = 3DNowPrefetch
            OSVW = Bits.Bit09,                   // Bit 09 = OS visible workaround
            IBS = Bits.Bit10,                    // Bit 10 = instruction based sampling
            XOP = Bits.Bit11,                    // Bit 11 = extended operation support
            SKINIT = Bits.Bit12,                 // Bit 12 = SKINIT and STGI are supported
            WDT = Bits.Bit13,                    // Bit 13 = watchdog timer support
            // Bit 14 = Reserved
            LWP = Bits.Bit15,                    // Bit 15 = lightweight profiling support
            FMA4 = Bits.Bit16,                   // Bit 16 = 4-operand FMA instruction support
            TCE = Bits.Bit17,					// Bit 17 = translation cache extension***
            // Bit 18 = Reserved
            NODEID = Bits.Bit19,                 // Bit 19 = Indicates support for MSRC001_100C[NodeId, NodesPerProcessor]
            // Bit 20 = Reserved
            TBM = Bits.Bit21,                    // Bit 21 = trailing bit manipulation instruction
            TOPOLOGYEXT = Bits.Bit22,            // Bit 22 = topology extensions support
            PERFCTREXTCORE = Bits.Bit23,         // Bit 23 = core performance counter extensions support***
            PERFCTREXTNB = Bits.Bit24,			// Bit 24 = NB performance counter extensions support***
            // Bit 25 = Reserved
            DATABREAKPOINTEXT = Bits.Bit26,		// Bit 26 = data breakpoint support***
            PERFTSC = Bits.Bit27,				// Bit 27 = performance time-stamp counter supported***
            PERFCTREXTL2I = Bits.Bit28			// Bit 28 = L2I performance counter extensions support***
            // Bit 29-31 = Reserved
        }

        public static SortedDictionary<string, bool> FeatureFlags = new SortedDictionary<string, bool>();
        public static List<string> IntelCacheDescriptors = new List<string>();

        private static Dictionary<byte, string> IntelCacheDefinitions = new Dictionary<byte, string>()
        {
            {0x00, "null descriptor (unused descriptor)"},
            {0x01, "code TLB, 4K pages, 4 ways, 32 entries"},
            {0x02, "code TLB, 4M pages, fully, 2 entries"},
            {0x03, "data TLB, 4K pages, 4 ways, 64 entries"},
            {0x04, "data TLB, 4M pages, 4 ways, 8 entries"},
            {0x05, "data TLB, 4M pages, 4 ways, 32 entries"},
            {0x06, "code L1 cache, 8 KB, 4 ways, 32 byte lines"},
            {0x08, "code L1 cache, 16 KB, 4 ways, 32 byte lines"},
            {0x09, "code L1 cache, 32 KB, 4 ways, 64 byte lines"},
            {0x0A, "data L1 cache, 8 KB, 2 ways, 32 byte lines"},
            {0x0B, "code TLB, 4M pages, 4 ways, 4 entries"},
            {0x0C, "data L1 cache, 16 KB, 4 ways, 32 byte lines"},
            {0x0D, "data L1 cache, 16 KB, 4 ways, 64 byte lines (ECC)"},
            {0x0E, "data L1 cache, 24 KB, 6 ways, 64 byte lines"},
            {0x10, "data L1 cache, 16 KB, 4 ways, 32 byte lines (IA-64)"},
            {0x15, "code L1 cache, 16 KB, 4 ways, 32 byte lines (IA-64)"},
            {0x1A, "code and data L2 cache, 96 KB, 6 ways, 64 byte lines (IA-64)"},
            {0x1D, "code and data L2 cache, 128 KB, 2 ways, 64 byte lines"},
            {0x21, "code and data L2 cache, 256 KB, 8 ways, 64 byte lines"},
            {0x22, "code and data L3 cache, 512 KB, 4 ways, 64 byte lines, dual-sectored"},
            {0x23, "code and data L3 cache, 1024 KB, 8 ways, 64 byte lines, dual-sectored"},
            {0x24, "code and data L2 cache, 1024 KB, 16 ways, 64 byte lines"},
            {0x25, "code and data L3 cache, 2048 KB, 8 ways, 64 byte lines, dual-sectored"},
            {0x29, "code and data L3 cache, 4096 KB, 8 ways, 64 byte lines, dual-sectored"},
            {0x2C, "data L1 cache, 32 KB, 8 ways, 64 byte lines"},
            {0x30, "code L1 cache, 32 KB, 8 ways, 64 byte lines"},
            {0x39, "code and data L2 cache, 128 KB, 4 ways, 64 byte lines, sectored"},
            {0x3A, "code and data L2 cache, 192 KB, 6 ways, 64 byte lines, sectored"},
            {0x3B, "code and data L2 cache, 128 KB, 2 ways, 64 byte lines, sectored"},
            {0x3C, "code and data L2 cache, 256 KB, 4 ways, 64 byte lines, sectored"},
            {0x3D, "code and data L2 cache, 384 KB, 6 ways, 64 byte lines, sectored"},
            {0x3E, "code and data L2 cache, 512 KB, 4 ways, 64 byte lines, sectored"},
            {0x40, "no integrated L2 cache (P6 core) or L3 cache (P4 core)"},
            {0x41, "code and data L2 cache, 128 KB, 4 ways, 32 byte lines"},
            {0x42, "code and data L2 cache, 256 KB, 4 ways, 32 byte lines"},
            {0x43, "code and data L2 cache, 512 KB, 4 ways, 32 byte lines"},
            {0x44, "code and data L2 cache, 1024 KB, 4 ways, 32 byte lines"},
            {0x45, "code and data L2 cache, 2048 KB, 4 ways, 32 byte lines"},
            {0x46, "code and data L3 cache, 4096 KB, 4 ways, 64 byte lines"},
            {0x47, "code and data L3 cache, 8192 KB, 8 ways, 64 byte lines"},
            {0x48, "code and data L2 cache, 3072 KB, 12 ways, 64 byte lines"},
            {0x49, "code and data L3 cache, 4096 KB, 16 ways, 64 byte lines (P4) or code and data L2 cache, 4096 KB, 16 ways, 64 byte lines (Core 2)"},
            {0x4A, "code and data L3 cache, 6144 KB, 12 ways, 64 byte lines"},
            {0x4B, "code and data L3 cache, 8192 KB, 16 ways, 64 byte lines"},
            {0x4C, "code and data L3 cache, 12288 KB, 12 ways, 64 byte lines"},
            {0x4D, "code and data L3 cache, 16384 KB, 16 ways, 64 byte lines"},
            {0x4E, "code and data L2 cache, 6144 KB, 24 ways, 64 byte lines"},
            {0x4F, "code TLB, 4K pages, ???, 32 entries"},
            {0x50, "code TLB, 4K/4M/2M pages, fully, 64 entries"},
            {0x51, "code TLB, 4K/4M/2M pages, fully, 128 entries"},
            {0x52, "code TLB, 4K/4M/2M pages, fully, 256 entries"},
            {0x55, "code TLB, 2M/4M, fully, 7 entries"},
            {0x56, "L0 data TLB, 4M pages, 4 ways, 16 entries"},
            {0x57, "L0 data TLB, 4K pages, 4 ways, 16 entries"},
            {0x59, "L0 data TLB, 4K pages, fully, 16 entries"},
            {0x5A, "L0 data TLB, 2M/4M, 4 ways, 32 entries"},
            {0x5B, "data TLB, 4K/4M pages, fully, 64 entries"},
            {0x5C, "data TLB, 4K/4M pages, fully, 128 entries"},
            {0x5D, "data TLB, 4K/4M pages, fully, 256 entries"},
            {0x60, "data L1 cache, 16 KB, 8 ways, 64 byte lines, sectored"},
            {0x61, "code TLB, 4K pages, fully, 48 entries"},
            {0x63, "data TLB, 2M/4M pages, 4-way, 32-entries, and data TLB, 1G pages, 4-way, 4 entries"},
            {0x64, "data TLB, 4K pages, 4-way, 512 entries"},
            {0x66, "data L1 cache, 8 KB, 4 ways, 64 byte lines, sectored"},
            {0x67, "data L1 cache, 16 KB, 4 ways, 64 byte lines, sectored"},
            {0x68, "data L1 cache, 32 KB, 4 ways, 64 byte lines, sectored"},
            {0x6A, "L0 data TLB, 4K pages, 8-way, 64 entries"},
            {0x6B, "data TLB, 4K pages, 8-way, 256 entries"},
            {0x6C, "data TLB, 2M/4M pages, 8-way, 126 entries"},
            {0x6D, "data TLB, 1G pages, fully, 16 entries"},
            {0x70, "trace L1 cache, 12 KµOPs, 8 ways"},
            {0x71, "trace L1 cache, 16 KµOPs, 8 ways"},
            {0x72, "trace L1 cache, 32 KµOPs, 8 ways"},
            {0x73, "trace L1 cache, 64 KµOPs, 8 ways"},
            {0x76, "code TLB, 2M/4M pages, fully, 8 entries"},
            {0x77, "code L1 cache, 16 KB, 4 ways, 64 byte lines, sectored (IA-64)"},
            {0x78, "code and data L2 cache, 1024 KB, 4 ways, 64 byte lines"},
            {0x79, "code and data L2 cache, 128 KB, 8 ways, 64 byte lines, dual-sectored"},
            {0x7A, "code and data L2 cache, 256 KB, 8 ways, 64 byte lines, dual-sectored"},
            {0x7B, "code and data L2 cache, 512 KB, 8 ways, 64 byte lines, dual-sectored"},
            {0x7C, "code and data L2 cache, 1024 KB, 8 ways, 64 byte lines, dual-sectored"},
            {0x7D, "code and data L2 cache, 2048 KB, 8 ways, 64 byte lines"},
            {0x7E, "code and data L2 cache, 256 KB, 8 ways, 128 byte lines, sect. (IA-64)"},
            {0x7F, "code and data L2 cache, 512 KB, 2 ways, 64 byte lines"},
            {0x80, "code and data L2 cache, 512 KB, 8 ways, 64 byte lines"},
            {0x81, "code and data L2 cache, 128 KB, 8 ways, 32 byte lines"},
            {0x82, "code and data L2 cache, 256 KB, 8 ways, 32 byte lines"},
            {0x83, "code and data L2 cache, 512 KB, 8 ways, 32 byte lines"},
            {0x84, "code and data L2 cache, 1024 KB, 8 ways, 32 byte lines"},
            {0x85, "code and data L2 cache, 2048 KB, 8 ways, 32 byte lines"},
            {0x86, "code and data L2 cache, 512 KB, 4 ways, 64 byte lines"},
            {0x87, "code and data L2 cache, 1024 KB, 8 ways, 64 byte lines"},
            {0x88, "code and data L3 cache, 2048 KB, 4 ways, 64 byte lines (IA-64)"},
            {0x89, "code and data L3 cache, 4096 KB, 4 ways, 64 byte lines (IA-64)"},
            {0x8A, "code and data L3 cache, 8192 KB, 4 ways, 64 byte lines (IA-64)"},
            {0x8D, "code and data L3 cache, 3072 KB, 12 ways, 128 byte lines (IA-64)"},
            {0x90, "code TLB, 4K...256M pages, fully, 64 entries (IA-64)"},
            {0x96, "data L1 TLB, 4K...256M pages, fully, 32 entries (IA-64)"},
            {0x9B, "data L2 TLB, 4K...256M pages, fully, 96 entries (IA-64)"},
            {0xA0, "data TLB, 4K pages, fully, 32 entries"},
            {0xB0, "code TLB, 4K pages, 4 ways, 128 entries"},
            {0xB1, "code TLB, 4M pages, 4 ways, 4 entries and code TLB, 2M pages, 4 ways, 8 entries"},
            {0xB2, "code TLB, 4K pages, 4 ways, 64 entries"},
            {0xB3, "data TLB, 4K pages, 4 ways, 128 entries"},
            {0xB4, "data TLB, 4K pages, 4 ways, 256 entries"},
            {0xB5, "code TLB, 4K pages, 8 ways, 64 entries"},
            {0xB6, "code TLB, 4K pages, 8 ways, 128 entries"},
            {0xBA, "data TLB, 4K pages, 4 ways, 64 entries"},
            {0xC0, "data TLB, 4K/4M pages, 4 ways, 8 entries"},
            {0xC1, "L2 code and data TLB, 4K/2M pages, 8 ways, 1024 entries"},
            {0xC2, "data TLB, 2M/4M pages, 4 ways, 16 entries"},
            {0xC3, "L2 code and data TLB, 4K/2M pages, 6 ways, 1536 entries and L2 code and data TLB, 1G pages, 4 ways, 16 entries"},
            {0xC4, "data TLB, 2M/4M pages, 4-way, 32 entries"},
            {0xCA, "L2 code and data TLB, 4K pages, 4 ways, 512 entries"},
            {0xD0, "code and data L3 cache, 512-kb, 4 ways, 64 byte lines"},
            {0xD1, "code and data L3 cache, 1024-kb, 4 ways, 64 byte lines"},
            {0xD2, "code and data L3 cache, 2048-kb, 4 ways, 64 byte lines"},
            {0xD6, "code and data L3 cache, 1024-kb, 8 ways, 64 byte lines"},
            {0xD7, "code and data L3 cache, 2048-kb, 8 ways, 64 byte lines"},
            {0xD8, "code and data L3 cache, 4096-kb, 8 ways, 64 byte lines"},
            {0xDC, "code and data L3 cache, 1536-kb, 12 ways, 64 byte lines"},
            {0xDD, "code and data L3 cache, 3072-kb, 12 ways, 64 byte lines"},
            {0xDE, "code and data L3 cache, 6144-kb, 12 ways, 64 byte lines"},
            {0xE2, "code and data L3 cache, 2048-kb, 16 ways, 64 byte lines"},
            {0xE3, "code and data L3 cache, 4096-kb, 16 ways, 64 byte lines"},
            {0xE4, "code and data L3 cache, 8192-kb, 16 ways, 64 byte lines"},
            {0xEA, "code and data L3 cache, 12288-kb, 24 ways, 64 byte lines"},
            {0xEB, "code and data L3 cache, 18432-kb, 24 ways, 64 byte lines"},
            {0xEC, "code and data L3 cache, 24576-kb, 24 ways, 64 byte lines"},
            {0xF0, "64 byte prefetching"},
            {0xF1, "128 byte prefetching"}
        };

        public static ulong ReadTSC()
        {
            uint edx = 0;
            uint eax = 0;

            __rdtsc();
            edx = __reg_edx();
            eax = __reg_eax();

            return ((ulong)edx << 32 | eax);
        }

        private static uint MaxStandardFunction
        {
            get
            {
                __cpuid(0, 0);
                return __reg_eax();
            }
        }

        private static uint MaxExtendedFunction
        {
            get
            {
                __cpuid(0x80000000, 0);
                return __reg_eax();
            }
        }

        public static string VendorString
        {
            get
            {
                uint _ebx, _ecx, _edx;

                __cpuid(0, 0);
                _ebx = __reg_ebx();
                _ecx = __reg_ecx();
                _edx = __reg_edx();

                return Value2String(_ebx, true) +
                       Value2String(_edx, true) +
                       Value2String(_ecx, true);
            }
        }

        public static VendorCompanies VendorCompany
        {
            get
            {
                switch (VendorString)
                {
                    case "AMDisbetter!":
                        return VendorCompanies.AMD;
                    case "AuthenticAMD":
                        return VendorCompanies.AMD;
                    case "CentaurHauls":
                        return VendorCompanies.Centaur;
                    case "CyrixInstead":
                        return VendorCompanies.Cyrix;
                    case "GenuineIntel":
                        return VendorCompanies.Intel;
                    case "TransmetaCPU":
                        return VendorCompanies.Transmeta;
                    case "GenuineTMx86":
                        return VendorCompanies.Transmeta;
                    case "Geode by NSC":
                        return VendorCompanies.NationalSemiconductor;
                    case "NexGenDriven":
                        return VendorCompanies.NexGen;
                    case "RiseRiseRise":
                        return VendorCompanies.Rise;
                    case "SiS SiS SiS ":
                        return VendorCompanies.SiS;
                    case "UMC UMC UMC ":
                        return VendorCompanies.UMC;
                    case "VIA VIA VIA ":
                        return VendorCompanies.VIA;
                    case "Vortex86 SoC":
                        return VendorCompanies.Vortex;
                    default:
                        return VendorCompanies.Unknown;

                }
            }
        }

        public static string CPUName
        {
            get
            {
                if (MaxExtendedFunction >= 0x80000004)
                {
                    uint _eax;
                    uint _ebx;
                    uint _ecx;
                    uint _edx;
                    string _cpuname;

                    __cpuid(0x80000002, 0);
                    _eax = __reg_eax();
                    _ebx = __reg_ebx();
                    _ecx = __reg_ecx();
                    _edx = __reg_edx();
                    _cpuname = Value2String(_eax, true) +
                               Value2String(_ebx, true) +
                               Value2String(_ecx, true) +
                               Value2String(_edx, true);

                    __cpuid(0x80000003, 0);
                    _eax = __reg_eax();
                    _ebx = __reg_ebx();
                    _ecx = __reg_ecx();
                    _edx = __reg_edx();
                    _cpuname += Value2String(_eax, true) +
                                Value2String(_ebx, true) +
                                Value2String(_ecx, true) +
                                Value2String(_edx, true);

                    __cpuid(0x80000004, 0);
                    _eax = __reg_eax();
                    _ebx = __reg_ebx();
                    _ecx = __reg_ecx();
                    _edx = __reg_edx();
                    _cpuname += Value2String(_eax, true) +
                                Value2String(_ebx, true) +
                                Value2String(_ecx, true) +
                                Value2String(_edx, true);

                    return _cpuname;
                }
                else
                {
                    return "";
                }
            }
        }

        private static uint ProcessorSignature
        {
            get
            {
                if (MaxStandardFunction >= 0x01)
                {
                    __cpuid(1, 0);
                    return __reg_eax();
                }
                else
                {
                    return 0;
                }
            }
        }

        private static uint StandardCPUID1_EDX
        {
            get
            {
                if (MaxStandardFunction >= 0x01)
                {
                    __cpuid(1, 0);
                    return __reg_edx();
                }
                else
                {
                    return 0;
                }
            }
        }

        private static uint StandardCPUID1_ECX
        {
            get
            {
                if (MaxStandardFunction >= 0x01)
                {
                    __cpuid(1, 0);
                    return __reg_ecx();
                }
                else
                {
                    return 0;
                }
            }
        }

        private static uint StandardCPUID7_EBX
        {
            get
            {
                if (MaxStandardFunction >= 0x07)
                {
                    __cpuid(7, 0);
                    return __reg_ebx();
                }
                else
                {
                    return 0;
                }
            }
        }

        private static uint StandardCPUID7_ECX
        {
            get
            {
                if (MaxStandardFunction >= 0x07)
                {
                    __cpuid(7, 0);
                    return __reg_ecx();
                }
                else
                {
                    return 0;
                }
            }
        }

        private static uint StandardCPUID7_EDX
        {
            get
            {
                if (MaxStandardFunction >= 0x07)
                {
                    __cpuid(7, 0);
                    return __reg_edx();
                }
                else
                {
                    return 0;
                }
            }
        }

        private static uint ExtendedCPUID1_EDX
        {
            get
            {
                if (MaxExtendedFunction >= 0x80000001)
                {
                    __cpuid(0x80000001, 0);
                    return __reg_edx();
                }
                else
                {
                    return 0;
                }
            }
        }

        private static uint ExtendedCPUID1_ECX
        {
            get
            {
                if (MaxExtendedFunction >= 0x80000001)
                {
                    __cpuid(0x80000001, 0);
                    return __reg_ecx();
                }
                else
                {
                    return 0;
                }
            }
        }

        static CPUInfo()
        {
            VendorCompanies _vendorcompany = VendorCompany;

            if (_vendorcompany == VendorCompanies.Intel || _vendorcompany == VendorCompanies.AMD)
            {
                uint _processorSignature = ProcessorSignature;

                CPUStepping = (byte)((_processorSignature >> 0) & 0x0F);
                CPUModel = (byte)((_processorSignature >> 4) & 0x0F);
                CPUFamily = (byte)((_processorSignature >> 8) & 0x0F);
                CPUType = (byte)((_processorSignature >> 12) & 0x03);
                CPUExtendedModel = (byte)((_processorSignature >> 16) & 0x0F);
                CPUExtendedFamily = (byte)((_processorSignature >> 20) & 0xFF);

                RegistryKey RKey = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
                CPUSpeed = ConvertX.ToUInt(RKey.GetValue("~MHz").ToString(), 0, "", "", 0);
                RKey.Close();

                uint _ebx = 0;
                uint _ecx = 0;
                uint _edx = 0;

                _edx = StandardCPUID1_EDX;

                FeatureFlags.Add("CPU_FPU", (_edx & (uint)StandardFlags1_EDX.FPU) > 0);
                FeatureFlags.Add("CPU_VME", (_edx & (uint)StandardFlags1_EDX.VME) > 0);
                FeatureFlags.Add("CPU_DE", (_edx & (uint)StandardFlags1_EDX.DE) > 0);
                FeatureFlags.Add("CPU_PSE", (_edx & (uint)StandardFlags1_EDX.PSE) > 0);
                FeatureFlags.Add("CPU_TSC", (_edx & (uint)StandardFlags1_EDX.TSC) > 0);
                FeatureFlags.Add("CPU_MSR", (_edx & (uint)StandardFlags1_EDX.MSR) > 0);
                FeatureFlags.Add("CPU_PAE", (_edx & (uint)StandardFlags1_EDX.PAE) > 0);
                FeatureFlags.Add("CPU_MCE", (_edx & (uint)StandardFlags1_EDX.MCE) > 0);
                FeatureFlags.Add("CPU_CX8", (_edx & (uint)StandardFlags1_EDX.CX8) > 0);
                FeatureFlags.Add("CPU_APIC", (_edx & (uint)StandardFlags1_EDX.APIC) > 0);
                FeatureFlags.Add("CPU_FSC", (_edx & (uint)StandardFlags1_EDX.FSC) > 0);
                FeatureFlags.Add("CPU_MTRR", (_edx & (uint)StandardFlags1_EDX.MTRR) > 0);
                FeatureFlags.Add("CPU_PGE", (_edx & (uint)StandardFlags1_EDX.PGE) > 0);
                FeatureFlags.Add("CPU_MCA", (_edx & (uint)StandardFlags1_EDX.MCA) > 0);
                FeatureFlags.Add("CPU_CMOV", (_edx & (uint)StandardFlags1_EDX.CMOV) > 0);
                FeatureFlags.Add("CPU_PAT", (_edx & (uint)StandardFlags1_EDX.PAT) > 0);
                FeatureFlags.Add("CPU_PSE36", (_edx & (uint)StandardFlags1_EDX.PSE36) > 0);
                FeatureFlags.Add("CPU_SERIAL", (_edx & (uint)StandardFlags1_EDX.SERIAL) > 0);
                FeatureFlags.Add("CPU_CLFSH", (_edx & (uint)StandardFlags1_EDX.CLFSH) > 0);
                FeatureFlags.Add("CPU_DS", (_edx & (uint)StandardFlags1_EDX.DS) > 0);
                FeatureFlags.Add("CPU_ACPI", (_edx & (uint)StandardFlags1_EDX.ACPI) > 0);
                FeatureFlags.Add("CPU_MMX", (_edx & (uint)StandardFlags1_EDX.MMX) > 0);
                FeatureFlags.Add("CPU_FXSR", (_edx & (uint)StandardFlags1_EDX.FXSR) > 0);
                FeatureFlags.Add("CPU_SSE", (_edx & (uint)StandardFlags1_EDX.SSE) > 0);
                FeatureFlags.Add("CPU_SSE2", (_edx & (uint)StandardFlags1_EDX.SSE2) > 0);
                FeatureFlags.Add("CPU_SS", (_edx & (uint)StandardFlags1_EDX.SS) > 0);
                FeatureFlags.Add("CPU_HTT", (_edx & (uint)StandardFlags1_EDX.HTT) > 0);
                FeatureFlags.Add("CPU_TM", (_edx & (uint)StandardFlags1_EDX.TM) > 0);
                FeatureFlags.Add("CPU_IA64", (_edx & (uint)StandardFlags1_EDX.IA64) > 0);
                FeatureFlags.Add("CPU_SBF", (_edx & (uint)StandardFlags1_EDX.SBF) > 0);

                _ecx = StandardCPUID1_ECX;

                FeatureFlags.Add("CPU_SSE3", (_ecx & (uint)StandardFlags1_ECX.SSE3) > 0);
                FeatureFlags.Add("CPU_PCLMULQDQ", (_ecx & (uint)StandardFlags1_ECX.PCLMULQDQ) > 0);
                FeatureFlags.Add("CPU_DS64", (_ecx & (uint)StandardFlags1_ECX.DS64) > 0);
                FeatureFlags.Add("CPU_MONITOR", (_ecx & (uint)StandardFlags1_ECX.MONITOR) > 0);
                FeatureFlags.Add("CPU_DSCPL", (_ecx & (uint)StandardFlags1_ECX.DSCPL) > 0);
                FeatureFlags.Add("CPU_VMX", (_ecx & (uint)StandardFlags1_ECX.VMX) > 0);
                FeatureFlags.Add("CPU_SMX", (_ecx & (uint)StandardFlags1_ECX.SMX) > 0);
                FeatureFlags.Add("CPU_ESS", (_ecx & (uint)StandardFlags1_ECX.ESS) > 0);
                FeatureFlags.Add("CPU_TM2", (_ecx & (uint)StandardFlags1_ECX.TM2) > 0);
                FeatureFlags.Add("CPU_SSSE3", (_ecx & (uint)StandardFlags1_ECX.SSSE3) > 0);
                FeatureFlags.Add("CPU_CNXTID", (_ecx & (uint)StandardFlags1_ECX.CNXTID) > 0);
                FeatureFlags.Add("CPU_FMA", (_ecx & (uint)StandardFlags1_ECX.FMA) > 0);
                FeatureFlags.Add("CPU_CX16", (_ecx & (uint)StandardFlags1_ECX.CX16) > 0);
                FeatureFlags.Add("CPU_XTPR", (_ecx & (uint)StandardFlags1_ECX.XTPR) > 0);
                FeatureFlags.Add("CPU_PDCM", (_ecx & (uint)StandardFlags1_ECX.PDCM) > 0);
                FeatureFlags.Add("CPU_PCID", (_ecx & (uint)StandardFlags1_ECX.PCID) > 0);
                FeatureFlags.Add("CPU_DCA", (_ecx & (uint)StandardFlags1_ECX.DCA) > 0);
                FeatureFlags.Add("CPU_SSE4_1", (_ecx & (uint)StandardFlags1_ECX.SSE4_1) > 0);
                FeatureFlags.Add("CPU_SSE4_2", (_ecx & (uint)StandardFlags1_ECX.SSE4_2) > 0);
                FeatureFlags.Add("CPU_X2APIC", (_ecx & (uint)StandardFlags1_ECX.X2APIC) > 0);
                FeatureFlags.Add("CPU_MOVBE", (_ecx & (uint)StandardFlags1_ECX.MOVBE) > 0);
                FeatureFlags.Add("CPU_POPCNT", (_ecx & (uint)StandardFlags1_ECX.POPCNT) > 0);
                FeatureFlags.Add("CPU_TSCDEADLINE", (_ecx & (uint)StandardFlags1_ECX.TSCDEADLINE) > 0);
                FeatureFlags.Add("CPU_AES", (_ecx & (uint)StandardFlags1_ECX.AES) > 0);
                FeatureFlags.Add("CPU_XSAVE", (_ecx & (uint)StandardFlags1_ECX.XSAVE) > 0);
                FeatureFlags.Add("CPU_OSXSAVE", (_ecx & (uint)StandardFlags1_ECX.OSXSAVE) > 0);
                FeatureFlags.Add("CPU_AVX", (_ecx & (uint)StandardFlags1_ECX.AVX) > 0);
                FeatureFlags.Add("CPU_F16C", (_ecx & (uint)StandardFlags1_ECX.F16C) > 0);
                FeatureFlags.Add("CPU_RDRAND", (_ecx & (uint)StandardFlags1_ECX.RDRAND) > 0);
                FeatureFlags.Add("CPU_HV", (_ecx & (uint)StandardFlags1_ECX.HV) > 0);

                _ebx = StandardCPUID7_EBX;

                FeatureFlags.Add("CPU_FSGSBASE", (_ebx & (uint)StandardFlags7_EBX.FSGSBASE) > 0);
                FeatureFlags.Add("CPU_TSC_ADJUST", (_ebx & (uint)StandardFlags7_EBX.TSC_ADJUST) > 0);
                FeatureFlags.Add("CPU_SGX", (_ebx & (uint)StandardFlags7_EBX.SGX) > 0);
                FeatureFlags.Add("CPU_BMI1", (_ebx & (uint)StandardFlags7_EBX.BMI1) > 0);
                FeatureFlags.Add("CPU_HLE", (_ebx & (uint)StandardFlags7_EBX.HLE) > 0);
                FeatureFlags.Add("CPU_AVX2", (_ebx & (uint)StandardFlags7_EBX.AVX2) > 0);
                FeatureFlags.Add("CPU_FPDP", (_ebx & (uint)StandardFlags7_EBX.FPDP) > 0);
                FeatureFlags.Add("CPU_SMEP", (_ebx & (uint)StandardFlags7_EBX.SMEP) > 0);
                FeatureFlags.Add("CPU_BMI2", (_ebx & (uint)StandardFlags7_EBX.BMI2) > 0);
                FeatureFlags.Add("CPU_ERMS", (_ebx & (uint)StandardFlags7_EBX.ERMS) > 0);
                FeatureFlags.Add("CPU_INVPCID", (_ebx & (uint)StandardFlags7_EBX.INVPCID) > 0);
                FeatureFlags.Add("CPU_RTM", (_ebx & (uint)StandardFlags7_EBX.RTM) > 0);
                FeatureFlags.Add("CPU_PQM", (_ebx & (uint)StandardFlags7_EBX.PQM) > 0);
                FeatureFlags.Add("CPU_FPCSDS", (_ebx & (uint)StandardFlags7_EBX.FPCSDS) > 0);
                FeatureFlags.Add("CPU_MPX", (_ebx & (uint)StandardFlags7_EBX.MPX) > 0);
                FeatureFlags.Add("CPU_PQE", (_ebx & (uint)StandardFlags7_EBX.PQE) > 0);
                FeatureFlags.Add("CPU_AVX512F", (_ebx & (uint)StandardFlags7_EBX.AVX512F) > 0);
                FeatureFlags.Add("CPU_AVX512DQ", (_ebx & (uint)StandardFlags7_EBX.AVX512DQ) > 0);
                FeatureFlags.Add("CPU_RDSEED", (_ebx & (uint)StandardFlags7_EBX.RDSEED) > 0);
                FeatureFlags.Add("CPU_ADX", (_ebx & (uint)StandardFlags7_EBX.ADX) > 0);
                FeatureFlags.Add("CPU_SMAP", (_ebx & (uint)StandardFlags7_EBX.SMAP) > 0);
                FeatureFlags.Add("CPU_AVX512IFMA", (_ebx & (uint)StandardFlags7_EBX.AVX512IFMA) > 0);
                FeatureFlags.Add("CPU_PCOMMIT", (_ebx & (uint)StandardFlags7_EBX.PCOMMIT) > 0);
                FeatureFlags.Add("CPU_CLFLUSHOPT", (_ebx & (uint)StandardFlags7_EBX.CLFLUSHOPT) > 0);
                FeatureFlags.Add("CPU_CLWB", (_ebx & (uint)StandardFlags7_EBX.CLWB) > 0);
                FeatureFlags.Add("CPU_PT", (_ebx & (uint)StandardFlags7_EBX.PT) > 0);
                FeatureFlags.Add("CPU_AVX512PF", (_ebx & (uint)StandardFlags7_EBX.AVX512PF) > 0);
                FeatureFlags.Add("CPU_AVX512ER", (_ebx & (uint)StandardFlags7_EBX.AVX512ER) > 0);
                FeatureFlags.Add("CPU_AVX512CD", (_ebx & (uint)StandardFlags7_EBX.AVX512CD) > 0);
                FeatureFlags.Add("CPU_SHA", (_ebx & (uint)StandardFlags7_EBX.SHA) > 0);
                FeatureFlags.Add("CPU_AVX512BW", (_ebx & (uint)StandardFlags7_EBX.AVX512BW) > 0);
                FeatureFlags.Add("CPU_AVX512VL", (_ebx & (uint)StandardFlags7_EBX.AVX512VL) > 0);

                _ecx = StandardCPUID7_ECX;

                FeatureFlags.Add("CPU_PREFETCHWT1", (_ecx & (uint)StandardFlags7_ECX.PREFETCHWT1) > 0);
                FeatureFlags.Add("CPU_AVX512VBMI", (_ecx & (uint)StandardFlags7_ECX.AVX512VBMI) > 0);
                FeatureFlags.Add("CPU_UMIP", (_ecx & (uint)StandardFlags7_ECX.UMIP) > 0);
                FeatureFlags.Add("CPU_PKU", (_ecx & (uint)StandardFlags7_ECX.PKU) > 0);
                FeatureFlags.Add("CPU_OSPKE", (_ecx & (uint)StandardFlags7_ECX.OSPKE) > 0);
                FeatureFlags.Add("CPU_CET", (_ecx & (uint)StandardFlags7_ECX.CET) > 0);
                FeatureFlags.Add("CPU_AVX512VPDQ", (_ecx & (uint)StandardFlags7_ECX.AVX512VPDQ) > 0);
                FeatureFlags.Add("CPU_VA57", (_ecx & (uint)StandardFlags7_ECX.VA57) > 0);
                FeatureFlags.Add("CPU_RDPID", (_ecx & (uint)StandardFlags7_ECX.RDPID) > 0);
                FeatureFlags.Add("CPU_SGX_LC", (_ecx & (uint)StandardFlags7_ECX.SGX_LC) > 0);

                _edx = StandardCPUID7_EDX;

                FeatureFlags.Add("CPU_AVX512QVNNIW", (_edx & (uint)StandardFlags7_EDX.AVX512QVNNIW) > 0);
                FeatureFlags.Add("CPU_AVX512QFMA", (_edx & (uint)StandardFlags7_EDX.AVX512QFMA) > 0);

            }

            if (_vendorcompany == VendorCompanies.Intel)
            {
                uint _edx = ExtendedCPUID1_EDX;

                FeatureFlags.Add("CPU_INTEL_SYSCALLSYSRET", (_edx & (uint)IntelExtendedFlags1_EDX.SYSCALLSYSRET) > 0);
                FeatureFlags.Add("CPU_INTEL_NX", (_edx & (uint)IntelExtendedFlags1_EDX.NX) > 0);
                FeatureFlags.Add("CPU_INTEL_PAGE1GB", (_edx & (uint)IntelExtendedFlags1_EDX.PAGE1GB) > 0);
                FeatureFlags.Add("CPU_INTEL_RDTSCP", (_edx & (uint)IntelExtendedFlags1_EDX.RDTSCP) > 0);
                FeatureFlags.Add("CPU_INTEL_INTEL64", (_edx & (uint)IntelExtendedFlags1_EDX.INTEL64) > 0);

                uint _ecx = ExtendedCPUID1_ECX;

                FeatureFlags.Add("CPU_INTEL_LAHFSAHF", (_ecx & (uint)IntelExtendedFlags1_ECX.LAHFSAHF) > 0);
            }

            if (_vendorcompany == VendorCompanies.AMD)
            {
                uint _edx = ExtendedCPUID1_EDX;

                // Returned in CPUID:0x80000001.EDX (AMD)
                FeatureFlags.Add("CPU_AMD_SYSCALLSYSRET", (_edx & (uint)AMDExtendedFlags1_EDX.SYSCALLSYSRET) > 0);
                FeatureFlags.Add("CPU_AMD_NX", (_edx & (uint)AMDExtendedFlags1_EDX.NX) > 0);
                FeatureFlags.Add("CPU_AMD_MMXEXT", (_edx & (uint)AMDExtendedFlags1_EDX.MMXEXT) > 0);
                FeatureFlags.Add("CPU_AMD_FFXSR", (_edx & (uint)AMDExtendedFlags1_EDX.FFXSR) > 0);
                FeatureFlags.Add("CPU_AMD_PAGE1GB", (_edx & (uint)AMDExtendedFlags1_EDX.PAGE1GB) > 0);
                FeatureFlags.Add("CPU_AMD_RDTSCP", (_edx & (uint)AMDExtendedFlags1_EDX.RDTSCP) > 0);
                FeatureFlags.Add("CPU_AMD_LM", (_edx & (uint)AMDExtendedFlags1_EDX.LM) > 0);
                FeatureFlags.Add("CPU_AMD_3DNOW", (_edx & (uint)AMDExtendedFlags1_EDX.THREEDNOW) > 0);
                FeatureFlags.Add("CPU_AMD_3DNOWEXT", (_edx & (uint)AMDExtendedFlags1_EDX.THREEDNOWEXT) > 0);

                uint _ecx = ExtendedCPUID1_ECX;

                // Returned in CPUID:0x80000001.ECX (AMD)
                FeatureFlags.Add("CPU_AMD_LAHFSAHF", (_ecx & (uint)AMDExtendedFlags1_ECX.LAHFSAHF) > 0);
                FeatureFlags.Add("CPU_AMD_CMPLEGACY", (_ecx & (uint)AMDExtendedFlags1_ECX.CMPLEGACY) > 0);
                FeatureFlags.Add("CPU_AMD_SVM", (_ecx & (uint)AMDExtendedFlags1_ECX.SVM) > 0);
                FeatureFlags.Add("CPU_AMD_EXTAPICSPACE", (_ecx & (uint)AMDExtendedFlags1_ECX.EXTAPICSPACE) > 0);
                FeatureFlags.Add("CPU_AMD_ALTMOVCR8", (_ecx & (uint)AMDExtendedFlags1_ECX.ALTMOVCR8) > 0);
                FeatureFlags.Add("CPU_AMD_ABM", (_ecx & (uint)AMDExtendedFlags1_ECX.ABM) > 0);
                FeatureFlags.Add("CPU_AMD_SSE4A", (_ecx & (uint)AMDExtendedFlags1_ECX.SSE4A) > 0);
                FeatureFlags.Add("CPU_AMD_MISALIGNSSE", (_ecx & (uint)AMDExtendedFlags1_ECX.MISALIGNSSE) > 0);
                FeatureFlags.Add("CPU_AMD_3DNOWPREFETCH", (_ecx & (uint)AMDExtendedFlags1_ECX.THREEDNOWPREFETCH) > 0);
                FeatureFlags.Add("CPU_AMD_OSVW", (_ecx & (uint)AMDExtendedFlags1_ECX.OSVW) > 0);
                FeatureFlags.Add("CPU_AMD_IBS", (_ecx & (uint)AMDExtendedFlags1_ECX.IBS) > 0);
                FeatureFlags.Add("CPU_AMD_XOP", (_ecx & (uint)AMDExtendedFlags1_ECX.XOP) > 0);
                FeatureFlags.Add("CPU_AMD_SKINIT", (_ecx & (uint)AMDExtendedFlags1_ECX.SKINIT) > 0);
                FeatureFlags.Add("CPU_AMD_WDT", (_ecx & (uint)AMDExtendedFlags1_ECX.WDT) > 0);
                FeatureFlags.Add("CPU_AMD_LWP", (_ecx & (uint)AMDExtendedFlags1_ECX.LWP) > 0);
                FeatureFlags.Add("CPU_AMD_FMA4", (_ecx & (uint)AMDExtendedFlags1_ECX.FMA4) > 0);
                FeatureFlags.Add("CPU_AMD_TCE", (_ecx & (uint)AMDExtendedFlags1_ECX.TCE) > 0);
                FeatureFlags.Add("CPU_AMD_NODEID", (_ecx & (uint)AMDExtendedFlags1_ECX.NODEID) > 0);
                FeatureFlags.Add("CPU_AMD_TBM", (_ecx & (uint)AMDExtendedFlags1_ECX.TBM) > 0);
                FeatureFlags.Add("CPU_AMD_TOPOLOGYEXT", (_ecx & (uint)AMDExtendedFlags1_ECX.TOPOLOGYEXT) > 0);
                FeatureFlags.Add("CPU_AMD_PERFCTREXTCORE", (_ecx & (uint)AMDExtendedFlags1_ECX.PERFCTREXTCORE) > 0);
                FeatureFlags.Add("CPU_AMD_PERFCTREXTNB", (_ecx & (uint)AMDExtendedFlags1_ECX.PERFCTREXTNB) > 0);
                FeatureFlags.Add("CPU_AMD_DATABREAKPOINTEXT", (_ecx & (uint)AMDExtendedFlags1_ECX.DATABREAKPOINTEXT) > 0);
                FeatureFlags.Add("CPU_AMD_PERFTSC", (_ecx & (uint)AMDExtendedFlags1_ECX.PERFTSC) > 0);
                FeatureFlags.Add("CPU_AMD_PERFCTREXTL2I", (_ecx & (uint)AMDExtendedFlags1_ECX.PERFCTREXTL2I) > 0);
            }

            if (_vendorcompany == VendorCompanies.Intel)
            {
                if (MaxStandardFunction >= 0x02)
                {
                    byte _cachedescriptor = 0;

                    __cpuid(0x02, 0);
                    uint _eax = __reg_eax();
                    uint _ebx = __reg_ebx();
                    uint _ecx = __reg_ecx();
                    uint _edx = __reg_edx();

                    byte _nroftimestoreadall = (byte)((_eax >> 00) & 0xFF);

                    for (byte counter = 0; counter < _nroftimestoreadall; counter++)
                    {
                        // Check if _eax is a valid descriptor
                        if (((_eax >> 31) & 0x01) == 0)
                        {
                            _cachedescriptor = (byte)((_eax >> 08) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_eax >> 16) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_eax >> 24) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                        }

                        // Check if _ebx is a valid descriptor
                        if (((_ebx >> 31) & 0x01) == 0)
                        {
                            _cachedescriptor = (byte)((_ebx >> 00) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_ebx >> 08) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_ebx >> 16) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_ebx >> 24) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                        }

                        // Check if _ecx is a valid descriptor
                        if (((_ecx >> 31) & 0x01) == 0)
                        {
                            _cachedescriptor = (byte)((_ecx >> 00) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_ecx >> 08) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_ecx >> 16) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_ecx >> 24) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                        }

                        // Check if _edx is a valid descriptor
                        if (((_edx >> 31) & 0x01) == 0)
                        {
                            _cachedescriptor = (byte)((_edx >> 00) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_edx >> 08) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_edx >> 16) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                            _cachedescriptor = (byte)((_edx >> 24) & 0xFF);
                            AddCacheDescriptor(_cachedescriptor);
                        }

                        __cpuid(0x02, 0);
                        _eax = __reg_eax();
                        _ebx = __reg_ebx();
                        _ecx = __reg_ecx();
                        _edx = __reg_edx();
                    }
                }
            }
        }

        private static void AddCacheDescriptor(byte CacheDescriptor)
        {
            if (CacheDescriptor > 0x00)
            {
                if (IntelCacheDefinitions.ContainsKey(CacheDescriptor))
                {
                    IntelCacheDescriptors.Add(String.Format("0x{0:X2} : ", CacheDescriptor) + IntelCacheDefinitions[CacheDescriptor]);
                }
                else
                {
                    IntelCacheDescriptors.Add(String.Format("0x{0:X2} : Unknown Cache Descriptor", CacheDescriptor));
                }
            }
        }

        private static string Value2String(byte value)
        {
            return Convert.ToString((char)value);
        }

        private static string Value2String(ushort value, bool LowNibbleFirst = false)
        {
            if (LowNibbleFirst == false)
            {
                return Value2String(MathHelper.HighNibble(value)) + Value2String(MathHelper.LowNibble(value));
            }
            else
            {
                return Value2String(MathHelper.LowNibble(value)) + Value2String(MathHelper.HighNibble(value));
            }
        }

        private static string Value2String(uint value, bool LowNibbleFirst = false)
        {
            if (LowNibbleFirst == false)
            {
                return Value2String(MathHelper.HighNibble(value), LowNibbleFirst) + Value2String(MathHelper.LowNibble(value), LowNibbleFirst);
            }
            else
            {
                return Value2String(MathHelper.LowNibble(value), LowNibbleFirst) + Value2String(MathHelper.HighNibble(value), LowNibbleFirst);
            }
        }

        private static string Value2String(ulong value, bool LowNibbleFirst = false)
        {
            if (LowNibbleFirst == false)
            {
                return Value2String(MathHelper.HighNibble(value), LowNibbleFirst) + Value2String(MathHelper.LowNibble(value), LowNibbleFirst);
            }
            else
            {
                return Value2String(MathHelper.LowNibble(value), LowNibbleFirst) + Value2String(MathHelper.HighNibble(value), LowNibbleFirst);
            }
        }
    }
}
