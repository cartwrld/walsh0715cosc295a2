; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [204 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 51
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 80
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 75
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 65
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 65
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 32
	i32 182336117, ; 6: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 66
	i32 209399409, ; 7: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 30
	i32 220171995, ; 8: System.Diagnostics.Debug => 0xd1f8edb => 88
	i32 230216969, ; 9: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 46
	i32 231814094, ; 10: System.Globalization => 0xdd133ce => 92
	i32 232815796, ; 11: System.Web.Services => 0xde07cb4 => 101
	i32 261689757, ; 12: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 35
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 50
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 44
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 22
	i32 321597661, ; 16: System.Numerics => 0x132b30dd => 16
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 48
	i32 441335492, ; 18: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 34
	i32 442521989, ; 19: Xamarin.Essentials => 0x1a605985 => 74
	i32 442565967, ; 20: System.Collections => 0x1a61054f => 84
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 43
	i32 465846621, ; 22: mscorlib => 0x1bc4415d => 7
	i32 469710990, ; 23: System.dll => 0x1bff388e => 15
	i32 476646585, ; 24: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 44
	i32 486930444, ; 25: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 55
	i32 526420162, ; 26: System.Transactions.dll => 0x1f6088c2 => 97
	i32 545304856, ; 27: System.Runtime.Extensions => 0x2080b118 => 85
	i32 605376203, ; 28: System.IO.Compression.FileSystem => 0x24154ecb => 100
	i32 627609679, ; 29: Xamarin.AndroidX.CustomView => 0x2568904f => 39
	i32 663517072, ; 30: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 71
	i32 666292255, ; 31: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 27
	i32 672442732, ; 32: System.Collections.Concurrent => 0x2814a96c => 83
	i32 690569205, ; 33: System.Xml.Linq.dll => 0x29293ff5 => 20
	i32 748832960, ; 34: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 10
	i32 775507847, ; 35: System.IO.Compression => 0x2e394f87 => 99
	i32 795785251, ; 36: walsh0715cosc295a2.Android.dll => 0x2f6eb823 => 0
	i32 809851609, ; 37: System.Drawing.Common.dll => 0x30455ad9 => 82
	i32 843511501, ; 38: Xamarin.AndroidX.Print => 0x3246f6cd => 62
	i32 877678880, ; 39: System.Globalization.dll => 0x34505120 => 92
	i32 928116545, ; 40: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 80
	i32 967690846, ; 41: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 48
	i32 974778368, ; 42: FormsViewGroup.dll => 0x3a19f000 => 4
	i32 992768348, ; 43: System.Collections.dll => 0x3b2c715c => 84
	i32 1012816738, ; 44: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 64
	i32 1035644815, ; 45: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 26
	i32 1042160112, ; 46: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 77
	i32 1044663988, ; 47: System.Linq.Expressions.dll => 0x3e444eb4 => 86
	i32 1052210849, ; 48: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 52
	i32 1098259244, ; 49: System => 0x41761b2c => 15
	i32 1175144683, ; 50: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 69
	i32 1178241025, ; 51: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 59
	i32 1204270330, ; 52: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 27
	i32 1267360935, ; 53: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 70
	i32 1292207520, ; 54: SQLitePCLRaw.core.dll => 0x4d0585a0 => 11
	i32 1293217323, ; 55: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 41
	i32 1324164729, ; 56: System.Linq => 0x4eed2679 => 90
	i32 1365406463, ; 57: System.ServiceModel.Internals.dll => 0x516272ff => 81
	i32 1376866003, ; 58: Xamarin.AndroidX.SavedState => 0x52114ed3 => 64
	i32 1395857551, ; 59: Xamarin.AndroidX.Media.dll => 0x5333188f => 56
	i32 1406073936, ; 60: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 36
	i32 1454233054, ; 61: SQLitePCLRaw.lib.e_sqlite3.dll => 0x56add5de => 12
	i32 1457743152, ; 62: System.Runtime.Extensions.dll => 0x56e36530 => 85
	i32 1460219004, ; 63: Xamarin.Forms.Xaml => 0x57092c7c => 78
	i32 1462112819, ; 64: System.IO.Compression.dll => 0x57261233 => 99
	i32 1469204771, ; 65: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 25
	i32 1550322496, ; 66: System.Reflection.Extensions.dll => 0x5c680b40 => 1
	i32 1582372066, ; 67: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 40
	i32 1592978981, ; 68: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1622152042, ; 69: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 54
	i32 1624863272, ; 70: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 73
	i32 1636350590, ; 71: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 38
	i32 1639515021, ; 72: System.Net.Http.dll => 0x61b9038d => 2
	i32 1657153582, ; 73: System.Runtime => 0x62c6282e => 18
	i32 1658241508, ; 74: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 67
	i32 1658251792, ; 75: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 79
	i32 1670060433, ; 76: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 35
	i32 1701541528, ; 77: System.Diagnostics.Debug.dll => 0x656b7698 => 88
	i32 1726116996, ; 78: System.Reflection.dll => 0x66e27484 => 87
	i32 1729485958, ; 79: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 31
	i32 1765942094, ; 80: System.Reflection.Extensions => 0x6942234e => 1
	i32 1766324549, ; 81: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 66
	i32 1776026572, ; 82: System.Core.dll => 0x69dc03cc => 14
	i32 1788241197, ; 83: Xamarin.AndroidX.Fragment => 0x6a96652d => 43
	i32 1808609942, ; 84: Xamarin.AndroidX.Loader => 0x6bcd3296 => 54
	i32 1813201214, ; 85: Xamarin.Google.Android.Material => 0x6c13413e => 79
	i32 1818569960, ; 86: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 60
	i32 1858542181, ; 87: System.Linq.Expressions => 0x6ec71a65 => 86
	i32 1867746548, ; 88: Xamarin.Essentials.dll => 0x6f538cf4 => 74
	i32 1878053835, ; 89: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 78
	i32 1885316902, ; 90: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 28
	i32 1891248011, ; 91: walsh0715cosc295a2.Android => 0x70ba278b => 0
	i32 1919157823, ; 92: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 57
	i32 2019465201, ; 93: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 52
	i32 2019533804, ; 94: SQLitePCLRaw.lib.e_sqlite3 => 0x785fa3ec => 12
	i32 2055257422, ; 95: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 49
	i32 2079903147, ; 96: System.Runtime.dll => 0x7bf8cdab => 18
	i32 2090596640, ; 97: System.Numerics.Vectors => 0x7c9bf920 => 17
	i32 2097448633, ; 98: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 45
	i32 2103459038, ; 99: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 13
	i32 2126786730, ; 100: Xamarin.Forms.Platform.Android => 0x7ec430aa => 76
	i32 2201231467, ; 101: System.Net.Http => 0x8334206b => 2
	i32 2217644978, ; 102: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 69
	i32 2244775296, ; 103: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 55
	i32 2256548716, ; 104: Xamarin.AndroidX.MultiDex => 0x8680336c => 57
	i32 2261435625, ; 105: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 47
	i32 2279755925, ; 106: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 63
	i32 2283762841, ; 107: walsh0715cosc295a2 => 0x881f7499 => 21
	i32 2315684594, ; 108: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 23
	i32 2409053734, ; 109: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 61
	i32 2465273461, ; 110: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 10
	i32 2465532216, ; 111: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 34
	i32 2471841756, ; 112: netstandard.dll => 0x93554fdc => 95
	i32 2475788418, ; 113: Java.Interop.dll => 0x93918882 => 5
	i32 2501346920, ; 114: System.Data.DataSetExtensions => 0x95178668 => 98
	i32 2505896520, ; 115: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 51
	i32 2581819634, ; 116: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 70
	i32 2620871830, ; 117: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 38
	i32 2624644809, ; 118: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 42
	i32 2633051222, ; 119: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 50
	i32 2701096212, ; 120: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 67
	i32 2715334215, ; 121: System.Threading.Tasks.dll => 0xa1d8b647 => 89
	i32 2732626843, ; 122: Xamarin.AndroidX.Activity => 0xa2e0939b => 22
	i32 2737747696, ; 123: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 25
	i32 2766581644, ; 124: Xamarin.Forms.Core => 0xa4e6af8c => 75
	i32 2778768386, ; 125: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 72
	i32 2810250172, ; 126: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 36
	i32 2819470561, ; 127: System.Xml.dll => 0xa80db4e1 => 19
	i32 2853208004, ; 128: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 72
	i32 2855708567, ; 129: Xamarin.AndroidX.Transition => 0xaa36a797 => 68
	i32 2901442782, ; 130: System.Reflection => 0xacf080de => 87
	i32 2903344695, ; 131: System.ComponentModel.Composition => 0xad0d8637 => 94
	i32 2905242038, ; 132: mscorlib.dll => 0xad2a79b6 => 7
	i32 2916838712, ; 133: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 73
	i32 2919462931, ; 134: System.Numerics.Vectors.dll => 0xae037813 => 17
	i32 2921128767, ; 135: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 24
	i32 2978675010, ; 136: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 41
	i32 3024354802, ; 137: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 46
	i32 3044182254, ; 138: FormsViewGroup => 0xb57288ee => 4
	i32 3057625584, ; 139: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 58
	i32 3075834255, ; 140: System.Threading.Tasks => 0xb755818f => 89
	i32 3111772706, ; 141: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3204380047, ; 142: System.Data.dll => 0xbefef58f => 96
	i32 3211777861, ; 143: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 40
	i32 3220365878, ; 144: System.Threading => 0xbff2e236 => 91
	i32 3247949154, ; 145: Mono.Security => 0xc197c562 => 93
	i32 3258312781, ; 146: Xamarin.AndroidX.CardView => 0xc235e84d => 31
	i32 3267021929, ; 147: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 29
	i32 3286872994, ; 148: SQLite-net.dll => 0xc3e9b3a2 => 8
	i32 3317135071, ; 149: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 39
	i32 3317144872, ; 150: System.Data => 0xc5b79d28 => 96
	i32 3340431453, ; 151: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 28
	i32 3346324047, ; 152: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 59
	i32 3353484488, ; 153: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 45
	i32 3360279109, ; 154: SQLitePCLRaw.core => 0xc849ca45 => 11
	i32 3362522851, ; 155: Xamarin.AndroidX.Core => 0xc86c06e3 => 37
	i32 3366347497, ; 156: Java.Interop => 0xc8a662e9 => 5
	i32 3374999561, ; 157: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 63
	i32 3404865022, ; 158: System.ServiceModel.Internals => 0xcaf21dfe => 81
	i32 3429136800, ; 159: System.Xml => 0xcc6479a0 => 19
	i32 3430777524, ; 160: netstandard => 0xcc7d82b4 => 95
	i32 3441283291, ; 161: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 42
	i32 3476120550, ; 162: Mono.Android => 0xcf3163e6 => 6
	i32 3486566296, ; 163: System.Transactions => 0xcfd0c798 => 97
	i32 3493954962, ; 164: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 33
	i32 3501239056, ; 165: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 29
	i32 3509114376, ; 166: System.Xml.Linq => 0xd128d608 => 20
	i32 3536029504, ; 167: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 76
	i32 3543730307, ; 168: SQLitePCLRaw.batteries_green.dll => 0xd3390883 => 9
	i32 3567349600, ; 169: System.ComponentModel.Composition.dll => 0xd4a16f60 => 94
	i32 3608519521, ; 170: System.Linq.dll => 0xd715a361 => 90
	i32 3618140916, ; 171: Xamarin.AndroidX.Preference => 0xd7a872f4 => 61
	i32 3627220390, ; 172: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 62
	i32 3632359727, ; 173: Xamarin.Forms.Platform => 0xd881692f => 77
	i32 3633644679, ; 174: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 24
	i32 3641597786, ; 175: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 49
	i32 3641967938, ; 176: SQLitePCLRaw.batteries_green => 0xd9140542 => 9
	i32 3672681054, ; 177: Mono.Android.dll => 0xdae8aa5e => 6
	i32 3676310014, ; 178: System.Web.Services.dll => 0xdb2009fe => 101
	i32 3682565725, ; 179: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 30
	i32 3684561358, ; 180: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 33
	i32 3689375977, ; 181: System.Drawing.Common => 0xdbe768e9 => 82
	i32 3718780102, ; 182: Xamarin.AndroidX.Annotation => 0xdda814c6 => 23
	i32 3724971120, ; 183: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 58
	i32 3754567612, ; 184: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 13
	i32 3758932259, ; 185: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 47
	i32 3786282454, ; 186: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 32
	i32 3822602673, ; 187: Xamarin.AndroidX.Media => 0xe3d849b1 => 56
	i32 3829621856, ; 188: System.Numerics.dll => 0xe4436460 => 16
	i32 3876362041, ; 189: SQLite-net => 0xe70c9739 => 8
	i32 3885922214, ; 190: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 68
	i32 3896106733, ; 191: System.Collections.Concurrent.dll => 0xe839deed => 83
	i32 3896760992, ; 192: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 37
	i32 3920810846, ; 193: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 100
	i32 3921031405, ; 194: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 71
	i32 3931092270, ; 195: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 60
	i32 3945713374, ; 196: System.Data.DataSetExtensions.dll => 0xeb2ecede => 98
	i32 3955647286, ; 197: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 26
	i32 4073602200, ; 198: System.Threading.dll => 0xf2ce3c98 => 91
	i32 4105002889, ; 199: Mono.Security.dll => 0xf4ad5f89 => 93
	i32 4151237749, ; 200: System.Core => 0xf76edc75 => 14
	i32 4182413190, ; 201: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 53
	i32 4233648686, ; 202: walsh0715cosc295a2.dll => 0xfc585a2e => 21
	i32 4292120959 ; 203: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 53
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [204 x i32] [
	i32 51, i32 80, i32 75, i32 65, i32 65, i32 32, i32 66, i32 30, ; 0..7
	i32 88, i32 46, i32 92, i32 101, i32 35, i32 50, i32 44, i32 22, ; 8..15
	i32 16, i32 48, i32 34, i32 74, i32 84, i32 43, i32 7, i32 15, ; 16..23
	i32 44, i32 55, i32 97, i32 85, i32 100, i32 39, i32 71, i32 27, ; 24..31
	i32 83, i32 20, i32 10, i32 99, i32 0, i32 82, i32 62, i32 92, ; 32..39
	i32 80, i32 48, i32 4, i32 84, i32 64, i32 26, i32 77, i32 86, ; 40..47
	i32 52, i32 15, i32 69, i32 59, i32 27, i32 70, i32 11, i32 41, ; 48..55
	i32 90, i32 81, i32 64, i32 56, i32 36, i32 12, i32 85, i32 78, ; 56..63
	i32 99, i32 25, i32 1, i32 40, i32 3, i32 54, i32 73, i32 38, ; 64..71
	i32 2, i32 18, i32 67, i32 79, i32 35, i32 88, i32 87, i32 31, ; 72..79
	i32 1, i32 66, i32 14, i32 43, i32 54, i32 79, i32 60, i32 86, ; 80..87
	i32 74, i32 78, i32 28, i32 0, i32 57, i32 52, i32 12, i32 49, ; 88..95
	i32 18, i32 17, i32 45, i32 13, i32 76, i32 2, i32 69, i32 55, ; 96..103
	i32 57, i32 47, i32 63, i32 21, i32 23, i32 61, i32 10, i32 34, ; 104..111
	i32 95, i32 5, i32 98, i32 51, i32 70, i32 38, i32 42, i32 50, ; 112..119
	i32 67, i32 89, i32 22, i32 25, i32 75, i32 72, i32 36, i32 19, ; 120..127
	i32 72, i32 68, i32 87, i32 94, i32 7, i32 73, i32 17, i32 24, ; 128..135
	i32 41, i32 46, i32 4, i32 58, i32 89, i32 3, i32 96, i32 40, ; 136..143
	i32 91, i32 93, i32 31, i32 29, i32 8, i32 39, i32 96, i32 28, ; 144..151
	i32 59, i32 45, i32 11, i32 37, i32 5, i32 63, i32 81, i32 19, ; 152..159
	i32 95, i32 42, i32 6, i32 97, i32 33, i32 29, i32 20, i32 76, ; 160..167
	i32 9, i32 94, i32 90, i32 61, i32 62, i32 77, i32 24, i32 49, ; 168..175
	i32 9, i32 6, i32 101, i32 30, i32 33, i32 82, i32 23, i32 58, ; 176..183
	i32 13, i32 47, i32 32, i32 56, i32 16, i32 8, i32 68, i32 83, ; 184..191
	i32 37, i32 100, i32 71, i32 60, i32 98, i32 26, i32 91, i32 93, ; 192..199
	i32 14, i32 53, i32 21, i32 53 ; 200..203
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}