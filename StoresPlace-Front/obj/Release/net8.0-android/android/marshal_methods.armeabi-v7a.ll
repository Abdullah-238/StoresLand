; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [151 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [302 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 116
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 115
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 52
	i32 42639949, ; 3: System.Threading.Thread => 0x28aa24d => 141
	i32 67008169, ; 4: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 34
	i32 72070932, ; 5: Microsoft.Maui.Graphics.dll => 0x44bb714 => 51
	i32 99482158, ; 6: StoresPlace-Front.dll => 0x5edfa2e => 89
	i32 117431740, ; 7: System.Runtime.InteropServices => 0x6ffddbc => 130
	i32 122350210, ; 8: System.Threading.Channels.dll => 0x74aea82 => 140
	i32 142721839, ; 9: System.Net.WebHeaderCollection => 0x881c32f => 123
	i32 165246403, ; 10: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 64
	i32 182336117, ; 11: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 82
	i32 191043783, ; 12: ar\StoresPlace-Front.resources => 0xb6318c7 => 0
	i32 195452805, ; 13: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 31
	i32 199333315, ; 14: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 32
	i32 205061960, ; 15: System.ComponentModel => 0xc38ff48 => 99
	i32 209399409, ; 16: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 62
	i32 230752869, ; 17: Microsoft.CSharp.dll => 0xdc10265 => 90
	i32 280992041, ; 18: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 3
	i32 317674968, ; 19: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 31
	i32 318968648, ; 20: Xamarin.AndroidX.Activity.dll => 0x13031348 => 59
	i32 336156722, ; 21: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 16
	i32 342366114, ; 22: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 71
	i32 347068432, ; 23: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 56
	i32 356389973, ; 24: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 15
	i32 375677976, ; 25: System.Net.ServicePoint.dll => 0x16646418 => 120
	i32 379916513, ; 26: System.Threading.Thread.dll => 0x16a510e1 => 141
	i32 385762202, ; 27: System.Memory.dll => 0x16fe439a => 111
	i32 395744057, ; 28: _Microsoft.Android.Resource.Designer => 0x17969339 => 35
	i32 435591531, ; 29: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 27
	i32 442565967, ; 30: System.Collections => 0x1a61054f => 95
	i32 450948140, ; 31: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 70
	i32 459347974, ; 32: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 134
	i32 469710990, ; 33: System.dll => 0x1bff388e => 145
	i32 498788369, ; 34: System.ObjectModel => 0x1dbae811 => 125
	i32 500358224, ; 35: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 14
	i32 503918385, ; 36: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 8
	i32 513247710, ; 37: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 46
	i32 539058512, ; 38: Microsoft.Extensions.Logging => 0x20216150 => 43
	i32 592146354, ; 39: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 22
	i32 597488923, ; 40: CommunityToolkit.Maui => 0x239cf51b => 36
	i32 627609679, ; 41: Xamarin.AndroidX.CustomView => 0x2568904f => 68
	i32 627931235, ; 42: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 20
	i32 662205335, ; 43: System.Text.Encodings.Web.dll => 0x27787397 => 137
	i32 672442732, ; 44: System.Collections.Concurrent => 0x2814a96c => 91
	i32 683518922, ; 45: System.Net.Security => 0x28bdabca => 119
	i32 688181140, ; 46: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 2
	i32 690569205, ; 47: System.Xml.Linq.dll => 0x29293ff5 => 143
	i32 706645707, ; 48: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 17
	i32 709557578, ; 49: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 5
	i32 722857257, ; 50: System.Runtime.Loader.dll => 0x2b15ed29 => 131
	i32 748832960, ; 51: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 54
	i32 759454413, ; 52: System.Net.Requests => 0x2d445acd => 118
	i32 775507847, ; 53: System.IO.Compression => 0x2e394f87 => 108
	i32 777317022, ; 54: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 26
	i32 789151979, ; 55: Microsoft.Extensions.Options => 0x2f0980eb => 45
	i32 804715423, ; 56: System.Data.Common => 0x2ff6fb9f => 101
	i32 823281589, ; 57: System.Private.Uri.dll => 0x311247b5 => 126
	i32 830298997, ; 58: System.IO.Compression.Brotli => 0x317d5b75 => 107
	i32 878954865, ; 59: System.Net.Http.Json => 0x3463c971 => 112
	i32 904024072, ; 60: System.ComponentModel.Primitives.dll => 0x35e25008 => 97
	i32 926902833, ; 61: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 29
	i32 955402788, ; 62: Newtonsoft.Json => 0x38f24a24 => 52
	i32 967690846, ; 63: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 71
	i32 992768348, ; 64: System.Collections.dll => 0x3b2c715c => 95
	i32 1012816738, ; 65: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 81
	i32 1019214401, ; 66: System.Drawing => 0x3cbffa41 => 105
	i32 1028951442, ; 67: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 42
	i32 1029334545, ; 68: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 4
	i32 1035644815, ; 69: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 60
	i32 1036536393, ; 70: System.Drawing.Primitives.dll => 0x3dc84a49 => 104
	i32 1044663988, ; 71: System.Linq.Expressions.dll => 0x3e444eb4 => 109
	i32 1052210849, ; 72: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 73
	i32 1082857460, ; 73: System.ComponentModel.TypeConverter => 0x408b17f4 => 98
	i32 1084122840, ; 74: Xamarin.Kotlin.StdLib => 0x409e66d8 => 86
	i32 1098259244, ; 75: System => 0x41761b2c => 145
	i32 1118262833, ; 76: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 17
	i32 1157397433, ; 77: StoresLand-API => 0x44fc7bb9 => 88
	i32 1168523401, ; 78: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 23
	i32 1178241025, ; 79: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 78
	i32 1201029973, ; 80: StarkbankEcdsa => 0x47964355 => 58
	i32 1203215381, ; 81: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 21
	i32 1215846396, ; 82: StoresPlace-Front => 0x487857fc => 89
	i32 1234928153, ; 83: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 19
	i32 1260983243, ; 84: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 3
	i32 1292207520, ; 85: SQLitePCLRaw.core.dll => 0x4d0585a0 => 55
	i32 1293217323, ; 86: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 69
	i32 1324164729, ; 87: System.Linq => 0x4eed2679 => 110
	i32 1373134921, ; 88: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 33
	i32 1376866003, ; 89: Xamarin.AndroidX.SavedState => 0x52114ed3 => 81
	i32 1406073936, ; 90: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 65
	i32 1408764838, ; 91: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 133
	i32 1430672901, ; 92: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 1
	i32 1433687999, ; 93: SendGrid.dll => 0x557457bf => 53
	i32 1452070440, ; 94: System.Formats.Asn1.dll => 0x568cd628 => 106
	i32 1458022317, ; 95: System.Net.Security.dll => 0x56e7a7ad => 119
	i32 1461004990, ; 96: es\Microsoft.Maui.Controls.resources => 0x57152abe => 7
	i32 1461234159, ; 97: System.Collections.Immutable.dll => 0x5718a9ef => 92
	i32 1462112819, ; 98: System.IO.Compression.dll => 0x57261233 => 108
	i32 1469204771, ; 99: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 61
	i32 1470490898, ; 100: Microsoft.Extensions.Primitives => 0x57a5e912 => 46
	i32 1479771757, ; 101: System.Collections.Immutable => 0x5833866d => 92
	i32 1480492111, ; 102: System.IO.Compression.Brotli.dll => 0x583e844f => 107
	i32 1490351284, ; 103: Microsoft.Data.Sqlite.dll => 0x58d4f4b4 => 38
	i32 1493001747, ; 104: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 11
	i32 1514721132, ; 105: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 6
	i32 1543031311, ; 106: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 139
	i32 1551623176, ; 107: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 26
	i32 1604827217, ; 108: System.Net.WebClient => 0x5fa7b851 => 122
	i32 1622152042, ; 109: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 75
	i32 1624863272, ; 110: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 84
	i32 1634654947, ; 111: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 37
	i32 1636350590, ; 112: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 67
	i32 1639515021, ; 113: System.Net.Http.dll => 0x61b9038d => 113
	i32 1639986890, ; 114: System.Text.RegularExpressions => 0x61c036ca => 139
	i32 1641389582, ; 115: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 96
	i32 1657153582, ; 116: System.Runtime => 0x62c6282e => 135
	i32 1658251792, ; 117: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 85
	i32 1677501392, ; 118: System.Net.Primitives.dll => 0x63fca3d0 => 117
	i32 1679769178, ; 119: System.Security.Cryptography => 0x641f3e5a => 136
	i32 1688112883, ; 120: Microsoft.Data.Sqlite => 0x649e8ef3 => 38
	i32 1711441057, ; 121: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 56
	i32 1729485958, ; 122: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 63
	i32 1736233607, ; 123: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 24
	i32 1743415430, ; 124: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 2
	i32 1763938596, ; 125: System.Diagnostics.TraceSource.dll => 0x69239124 => 103
	i32 1766324549, ; 126: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 82
	i32 1770582343, ; 127: Microsoft.Extensions.Logging.dll => 0x6988f147 => 43
	i32 1780572499, ; 128: Mono.Android.Runtime.dll => 0x6a216153 => 149
	i32 1782862114, ; 129: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 18
	i32 1788241197, ; 130: Xamarin.AndroidX.Fragment => 0x6a96652d => 70
	i32 1793755602, ; 131: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 10
	i32 1808609942, ; 132: Xamarin.AndroidX.Loader => 0x6bcd3296 => 75
	i32 1813058853, ; 133: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 86
	i32 1813201214, ; 134: Xamarin.Google.Android.Material => 0x6c13413e => 85
	i32 1818569960, ; 135: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 79
	i32 1824722060, ; 136: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 133
	i32 1828688058, ; 137: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 44
	i32 1842015223, ; 138: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 30
	i32 1853025655, ; 139: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 27
	i32 1858542181, ; 140: System.Linq.Expressions => 0x6ec71a65 => 109
	i32 1875935024, ; 141: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 9
	i32 1910275211, ; 142: System.Collections.NonGeneric.dll => 0x71dc7c8b => 93
	i32 1939592360, ; 143: System.Private.Xml.Linq => 0x739bd4a8 => 127
	i32 1968388702, ; 144: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 39
	i32 2003115576, ; 145: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 6
	i32 2019465201, ; 146: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 73
	i32 2025202353, ; 147: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 1
	i32 2045470958, ; 148: System.Private.Xml => 0x79eb68ee => 128
	i32 2055257422, ; 149: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 72
	i32 2066184531, ; 150: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 5
	i32 2070888862, ; 151: System.Diagnostics.TraceSource => 0x7b6f419e => 103
	i32 2079903147, ; 152: System.Runtime.dll => 0x7bf8cdab => 135
	i32 2090596640, ; 153: System.Numerics.Vectors => 0x7c9bf920 => 124
	i32 2103459038, ; 154: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 57
	i32 2127167465, ; 155: System.Console => 0x7ec9ffe9 => 100
	i32 2142473426, ; 156: System.Collections.Specialized => 0x7fb38cd2 => 94
	i32 2159891885, ; 157: Microsoft.Maui => 0x80bd55ad => 49
	i32 2169148018, ; 158: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 13
	i32 2181898931, ; 159: Microsoft.Extensions.Options.dll => 0x820d22b3 => 45
	i32 2192057212, ; 160: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 44
	i32 2193016926, ; 161: System.ObjectModel.dll => 0x82b6c85e => 125
	i32 2201107256, ; 162: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 87
	i32 2201231467, ; 163: System.Net.Http => 0x8334206b => 113
	i32 2207618523, ; 164: it\Microsoft.Maui.Controls.resources => 0x839595db => 15
	i32 2210798277, ; 165: SendGrid => 0x83c61ac5 => 53
	i32 2266799131, ; 166: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 40
	i32 2270573516, ; 167: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 9
	i32 2279755925, ; 168: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 80
	i32 2295906218, ; 169: System.Net.Sockets => 0x88d8bfaa => 121
	i32 2298471582, ; 170: System.Net.Mail => 0x88ffe49e => 114
	i32 2303942373, ; 171: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 19
	i32 2305521784, ; 172: System.Private.CoreLib.dll => 0x896b7878 => 147
	i32 2340441535, ; 173: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 129
	i32 2353062107, ; 174: System.Net.Primitives => 0x8c40e0db => 117
	i32 2368005991, ; 175: System.Xml.ReaderWriter.dll => 0x8d24e767 => 144
	i32 2371007202, ; 176: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 39
	i32 2395872292, ; 177: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 14
	i32 2427813419, ; 178: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 11
	i32 2435356389, ; 179: System.Console.dll => 0x912896e5 => 100
	i32 2458678730, ; 180: System.Net.Sockets.dll => 0x928c75ca => 121
	i32 2465273461, ; 181: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 54
	i32 2471841756, ; 182: netstandard.dll => 0x93554fdc => 146
	i32 2475788418, ; 183: Java.Interop.dll => 0x93918882 => 148
	i32 2480646305, ; 184: Microsoft.Maui.Controls => 0x93dba8a1 => 47
	i32 2483903535, ; 185: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 96
	i32 2484371297, ; 186: System.Net.ServicePoint => 0x94147f61 => 120
	i32 2550873716, ; 187: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 12
	i32 2562349572, ; 188: Microsoft.CSharp => 0x98ba5a04 => 90
	i32 2570120770, ; 189: System.Text.Encodings.Web => 0x9930ee42 => 137
	i32 2593496499, ; 190: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 21
	i32 2605712449, ; 191: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 87
	i32 2617129537, ; 192: System.Private.Xml.dll => 0x9bfe3a41 => 128
	i32 2620871830, ; 193: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 67
	i32 2626831493, ; 194: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 16
	i32 2663698177, ; 195: System.Runtime.Loader => 0x9ec4cf01 => 131
	i32 2665622720, ; 196: System.Drawing.Primitives => 0x9ee22cc0 => 104
	i32 2676780864, ; 197: System.Data.Common.dll => 0x9f8c6f40 => 101
	i32 2724373263, ; 198: System.Runtime.Numerics.dll => 0xa262a30f => 132
	i32 2732626843, ; 199: Xamarin.AndroidX.Activity => 0xa2e0939b => 59
	i32 2735172069, ; 200: System.Threading.Channels => 0xa30769e5 => 140
	i32 2737747696, ; 201: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 61
	i32 2752995522, ; 202: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 22
	i32 2758225723, ; 203: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 48
	i32 2764765095, ; 204: Microsoft.Maui.dll => 0xa4caf7a7 => 49
	i32 2778768386, ; 205: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 83
	i32 2785988530, ; 206: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 28
	i32 2801831435, ; 207: Microsoft.Maui.Graphics => 0xa7008e0b => 51
	i32 2806116107, ; 208: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 7
	i32 2810250172, ; 209: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 65
	i32 2831556043, ; 210: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 20
	i32 2853208004, ; 211: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 83
	i32 2856443450, ; 212: ar/StoresPlace-Front.resources.dll => 0xaa41de3a => 0
	i32 2861189240, ; 213: Microsoft.Maui.Essentials => 0xaa8a4878 => 50
	i32 2868488919, ; 214: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 37
	i32 2909740682, ; 215: System.Private.CoreLib => 0xad6f1e8a => 147
	i32 2916838712, ; 216: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 84
	i32 2919462931, ; 217: System.Numerics.Vectors.dll => 0xae037813 => 124
	i32 2959614098, ; 218: System.ComponentModel.dll => 0xb0682092 => 99
	i32 2978675010, ; 219: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 69
	i32 3038032645, ; 220: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 35
	i32 3057625584, ; 221: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 76
	i32 3059408633, ; 222: Mono.Android.Runtime => 0xb65adef9 => 149
	i32 3059793426, ; 223: System.ComponentModel.Primitives => 0xb660be12 => 97
	i32 3077302341, ; 224: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 13
	i32 3103600923, ; 225: System.Formats.Asn1 => 0xb8fd311b => 106
	i32 3178803400, ; 226: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 77
	i32 3220365878, ; 227: System.Threading => 0xbff2e236 => 142
	i32 3258312781, ; 228: Xamarin.AndroidX.CardView => 0xc235e84d => 63
	i32 3271840132, ; 229: StarkbankEcdsa.dll => 0xc3045184 => 58
	i32 3305363605, ; 230: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 8
	i32 3316684772, ; 231: System.Net.Requests.dll => 0xc5b097e4 => 118
	i32 3317135071, ; 232: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 68
	i32 3334456641, ; 233: StoresLand-API.dll => 0xc6bfc541 => 88
	i32 3346324047, ; 234: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 78
	i32 3357674450, ; 235: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 25
	i32 3358260929, ; 236: System.Text.Json => 0xc82afec1 => 138
	i32 3360279109, ; 237: SQLitePCLRaw.core => 0xc849ca45 => 55
	i32 3362522851, ; 238: Xamarin.AndroidX.Core => 0xc86c06e3 => 66
	i32 3366347497, ; 239: Java.Interop => 0xc8a662e9 => 148
	i32 3374999561, ; 240: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 80
	i32 3381016424, ; 241: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 4
	i32 3428513518, ; 242: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 41
	i32 3430777524, ; 243: netstandard => 0xcc7d82b4 => 146
	i32 3463511458, ; 244: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 12
	i32 3471940407, ; 245: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 98
	i32 3476120550, ; 246: Mono.Android => 0xcf3163e6 => 150
	i32 3479583265, ; 247: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 25
	i32 3484440000, ; 248: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 24
	i32 3485117614, ; 249: System.Text.Json.dll => 0xcfbaacae => 138
	i32 3509114376, ; 250: System.Xml.Linq => 0xd128d608 => 143
	i32 3580758918, ; 251: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 32
	i32 3608519521, ; 252: System.Linq.dll => 0xd715a361 => 110
	i32 3624195450, ; 253: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 129
	i32 3641597786, ; 254: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 72
	i32 3643446276, ; 255: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 29
	i32 3643854240, ; 256: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 77
	i32 3657292374, ; 257: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 40
	i32 3660523487, ; 258: System.Net.NetworkInformation => 0xda2f27df => 116
	i32 3672681054, ; 259: Mono.Android.dll => 0xdae8aa5e => 150
	i32 3682565725, ; 260: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 62
	i32 3697841164, ; 261: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 34
	i32 3724971120, ; 262: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 76
	i32 3732100267, ; 263: System.Net.NameResolution => 0xde7354ab => 115
	i32 3737834244, ; 264: System.Net.Http.Json.dll => 0xdecad304 => 112
	i32 3748608112, ; 265: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 102
	i32 3754567612, ; 266: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 57
	i32 3786282454, ; 267: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 64
	i32 3792276235, ; 268: System.Collections.NonGeneric => 0xe2098b0b => 93
	i32 3802395368, ; 269: System.Collections.Specialized.dll => 0xe2a3f2e8 => 94
	i32 3817368567, ; 270: CommunityToolkit.Maui.dll => 0xe3886bf7 => 36
	i32 3823082795, ; 271: System.Security.Cryptography.dll => 0xe3df9d2b => 136
	i32 3841636137, ; 272: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 42
	i32 3844307129, ; 273: System.Net.Mail.dll => 0xe52378b9 => 114
	i32 3849253459, ; 274: System.Runtime.InteropServices.dll => 0xe56ef253 => 130
	i32 3885497537, ; 275: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 123
	i32 3889960447, ; 276: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 33
	i32 3896106733, ; 277: System.Collections.Concurrent.dll => 0xe839deed => 91
	i32 3896760992, ; 278: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 66
	i32 3928044579, ; 279: System.Xml.ReaderWriter => 0xea213423 => 144
	i32 3931092270, ; 280: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 79
	i32 3955647286, ; 281: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 60
	i32 3980434154, ; 282: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 28
	i32 3987592930, ; 283: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 10
	i32 4025784931, ; 284: System.Memory => 0xeff49a63 => 111
	i32 4046471985, ; 285: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 48
	i32 4068434129, ; 286: System.Private.Xml.Linq.dll => 0xf27f60d1 => 127
	i32 4073602200, ; 287: System.Threading.dll => 0xf2ce3c98 => 142
	i32 4094352644, ; 288: Microsoft.Maui.Essentials.dll => 0xf40add04 => 50
	i32 4099507663, ; 289: System.Drawing.dll => 0xf45985cf => 105
	i32 4100113165, ; 290: System.Private.Uri => 0xf462c30d => 126
	i32 4102112229, ; 291: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 23
	i32 4125707920, ; 292: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 18
	i32 4126470640, ; 293: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 41
	i32 4150914736, ; 294: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 30
	i32 4181436372, ; 295: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 134
	i32 4182413190, ; 296: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 74
	i32 4196529839, ; 297: System.Net.WebClient.dll => 0xfa21f6af => 122
	i32 4213026141, ; 298: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 102
	i32 4271975918, ; 299: Microsoft.Maui.Controls.dll => 0xfea12dee => 47
	i32 4274976490, ; 300: System.Runtime.Numerics => 0xfecef6ea => 132
	i32 4292120959 ; 301: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 74
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [302 x i32] [
	i32 116, ; 0
	i32 115, ; 1
	i32 52, ; 2
	i32 141, ; 3
	i32 34, ; 4
	i32 51, ; 5
	i32 89, ; 6
	i32 130, ; 7
	i32 140, ; 8
	i32 123, ; 9
	i32 64, ; 10
	i32 82, ; 11
	i32 0, ; 12
	i32 31, ; 13
	i32 32, ; 14
	i32 99, ; 15
	i32 62, ; 16
	i32 90, ; 17
	i32 3, ; 18
	i32 31, ; 19
	i32 59, ; 20
	i32 16, ; 21
	i32 71, ; 22
	i32 56, ; 23
	i32 15, ; 24
	i32 120, ; 25
	i32 141, ; 26
	i32 111, ; 27
	i32 35, ; 28
	i32 27, ; 29
	i32 95, ; 30
	i32 70, ; 31
	i32 134, ; 32
	i32 145, ; 33
	i32 125, ; 34
	i32 14, ; 35
	i32 8, ; 36
	i32 46, ; 37
	i32 43, ; 38
	i32 22, ; 39
	i32 36, ; 40
	i32 68, ; 41
	i32 20, ; 42
	i32 137, ; 43
	i32 91, ; 44
	i32 119, ; 45
	i32 2, ; 46
	i32 143, ; 47
	i32 17, ; 48
	i32 5, ; 49
	i32 131, ; 50
	i32 54, ; 51
	i32 118, ; 52
	i32 108, ; 53
	i32 26, ; 54
	i32 45, ; 55
	i32 101, ; 56
	i32 126, ; 57
	i32 107, ; 58
	i32 112, ; 59
	i32 97, ; 60
	i32 29, ; 61
	i32 52, ; 62
	i32 71, ; 63
	i32 95, ; 64
	i32 81, ; 65
	i32 105, ; 66
	i32 42, ; 67
	i32 4, ; 68
	i32 60, ; 69
	i32 104, ; 70
	i32 109, ; 71
	i32 73, ; 72
	i32 98, ; 73
	i32 86, ; 74
	i32 145, ; 75
	i32 17, ; 76
	i32 88, ; 77
	i32 23, ; 78
	i32 78, ; 79
	i32 58, ; 80
	i32 21, ; 81
	i32 89, ; 82
	i32 19, ; 83
	i32 3, ; 84
	i32 55, ; 85
	i32 69, ; 86
	i32 110, ; 87
	i32 33, ; 88
	i32 81, ; 89
	i32 65, ; 90
	i32 133, ; 91
	i32 1, ; 92
	i32 53, ; 93
	i32 106, ; 94
	i32 119, ; 95
	i32 7, ; 96
	i32 92, ; 97
	i32 108, ; 98
	i32 61, ; 99
	i32 46, ; 100
	i32 92, ; 101
	i32 107, ; 102
	i32 38, ; 103
	i32 11, ; 104
	i32 6, ; 105
	i32 139, ; 106
	i32 26, ; 107
	i32 122, ; 108
	i32 75, ; 109
	i32 84, ; 110
	i32 37, ; 111
	i32 67, ; 112
	i32 113, ; 113
	i32 139, ; 114
	i32 96, ; 115
	i32 135, ; 116
	i32 85, ; 117
	i32 117, ; 118
	i32 136, ; 119
	i32 38, ; 120
	i32 56, ; 121
	i32 63, ; 122
	i32 24, ; 123
	i32 2, ; 124
	i32 103, ; 125
	i32 82, ; 126
	i32 43, ; 127
	i32 149, ; 128
	i32 18, ; 129
	i32 70, ; 130
	i32 10, ; 131
	i32 75, ; 132
	i32 86, ; 133
	i32 85, ; 134
	i32 79, ; 135
	i32 133, ; 136
	i32 44, ; 137
	i32 30, ; 138
	i32 27, ; 139
	i32 109, ; 140
	i32 9, ; 141
	i32 93, ; 142
	i32 127, ; 143
	i32 39, ; 144
	i32 6, ; 145
	i32 73, ; 146
	i32 1, ; 147
	i32 128, ; 148
	i32 72, ; 149
	i32 5, ; 150
	i32 103, ; 151
	i32 135, ; 152
	i32 124, ; 153
	i32 57, ; 154
	i32 100, ; 155
	i32 94, ; 156
	i32 49, ; 157
	i32 13, ; 158
	i32 45, ; 159
	i32 44, ; 160
	i32 125, ; 161
	i32 87, ; 162
	i32 113, ; 163
	i32 15, ; 164
	i32 53, ; 165
	i32 40, ; 166
	i32 9, ; 167
	i32 80, ; 168
	i32 121, ; 169
	i32 114, ; 170
	i32 19, ; 171
	i32 147, ; 172
	i32 129, ; 173
	i32 117, ; 174
	i32 144, ; 175
	i32 39, ; 176
	i32 14, ; 177
	i32 11, ; 178
	i32 100, ; 179
	i32 121, ; 180
	i32 54, ; 181
	i32 146, ; 182
	i32 148, ; 183
	i32 47, ; 184
	i32 96, ; 185
	i32 120, ; 186
	i32 12, ; 187
	i32 90, ; 188
	i32 137, ; 189
	i32 21, ; 190
	i32 87, ; 191
	i32 128, ; 192
	i32 67, ; 193
	i32 16, ; 194
	i32 131, ; 195
	i32 104, ; 196
	i32 101, ; 197
	i32 132, ; 198
	i32 59, ; 199
	i32 140, ; 200
	i32 61, ; 201
	i32 22, ; 202
	i32 48, ; 203
	i32 49, ; 204
	i32 83, ; 205
	i32 28, ; 206
	i32 51, ; 207
	i32 7, ; 208
	i32 65, ; 209
	i32 20, ; 210
	i32 83, ; 211
	i32 0, ; 212
	i32 50, ; 213
	i32 37, ; 214
	i32 147, ; 215
	i32 84, ; 216
	i32 124, ; 217
	i32 99, ; 218
	i32 69, ; 219
	i32 35, ; 220
	i32 76, ; 221
	i32 149, ; 222
	i32 97, ; 223
	i32 13, ; 224
	i32 106, ; 225
	i32 77, ; 226
	i32 142, ; 227
	i32 63, ; 228
	i32 58, ; 229
	i32 8, ; 230
	i32 118, ; 231
	i32 68, ; 232
	i32 88, ; 233
	i32 78, ; 234
	i32 25, ; 235
	i32 138, ; 236
	i32 55, ; 237
	i32 66, ; 238
	i32 148, ; 239
	i32 80, ; 240
	i32 4, ; 241
	i32 41, ; 242
	i32 146, ; 243
	i32 12, ; 244
	i32 98, ; 245
	i32 150, ; 246
	i32 25, ; 247
	i32 24, ; 248
	i32 138, ; 249
	i32 143, ; 250
	i32 32, ; 251
	i32 110, ; 252
	i32 129, ; 253
	i32 72, ; 254
	i32 29, ; 255
	i32 77, ; 256
	i32 40, ; 257
	i32 116, ; 258
	i32 150, ; 259
	i32 62, ; 260
	i32 34, ; 261
	i32 76, ; 262
	i32 115, ; 263
	i32 112, ; 264
	i32 102, ; 265
	i32 57, ; 266
	i32 64, ; 267
	i32 93, ; 268
	i32 94, ; 269
	i32 36, ; 270
	i32 136, ; 271
	i32 42, ; 272
	i32 114, ; 273
	i32 130, ; 274
	i32 123, ; 275
	i32 33, ; 276
	i32 91, ; 277
	i32 66, ; 278
	i32 144, ; 279
	i32 79, ; 280
	i32 60, ; 281
	i32 28, ; 282
	i32 10, ; 283
	i32 111, ; 284
	i32 48, ; 285
	i32 127, ; 286
	i32 142, ; 287
	i32 50, ; 288
	i32 105, ; 289
	i32 126, ; 290
	i32 23, ; 291
	i32 18, ; 292
	i32 41, ; 293
	i32 30, ; 294
	i32 134, ; 295
	i32 74, ; 296
	i32 122, ; 297
	i32 102, ; 298
	i32 47, ; 299
	i32 132, ; 300
	i32 74 ; 301
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ df9aaf29a52042a4fbf800daf2f3a38964b9e958"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
