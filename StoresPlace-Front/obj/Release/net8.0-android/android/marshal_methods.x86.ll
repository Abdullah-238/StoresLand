; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [214 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [428 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 156
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 155
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 75
	i32 42639949, ; 3: System.Threading.Thread => 0x28aa24d => 199
	i32 57725457, ; 4: it\Microsoft.Data.SqlClient.resources => 0x370d211 => 4
	i32 57727992, ; 5: ja\Microsoft.Data.SqlClient.resources => 0x370dbf8 => 5
	i32 66541672, ; 6: System.Diagnostics.StackTrace => 0x3f75868 => 138
	i32 67008169, ; 7: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 44
	i32 68219467, ; 8: System.Security.Cryptography.Primitives => 0x410f24b => 188
	i32 72070932, ; 9: Microsoft.Maui.Graphics.dll => 0x44bb714 => 73
	i32 99482158, ; 10: StoresPlace-Front.dll => 0x5edfa2e => 121
	i32 117431740, ; 11: System.Runtime.InteropServices => 0x6ffddbc => 174
	i32 122350210, ; 12: System.Threading.Channels.dll => 0x74aea82 => 197
	i32 139659294, ; 13: ja/Microsoft.Data.SqlClient.resources.dll => 0x853081e => 5
	i32 142721839, ; 14: System.Net.WebHeaderCollection => 0x881c32f => 163
	i32 149972175, ; 15: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 188
	i32 165246403, ; 16: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 95
	i32 166535111, ; 17: ru/Microsoft.Data.SqlClient.resources.dll => 0x9ed1fc7 => 8
	i32 182336117, ; 18: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 113
	i32 191043783, ; 19: ar\StoresPlace-Front.resources => 0xb6318c7 => 0
	i32 195452805, ; 20: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 41
	i32 199333315, ; 21: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 42
	i32 205061960, ; 22: System.ComponentModel => 0xc38ff48 => 133
	i32 209399409, ; 23: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 93
	i32 230752869, ; 24: Microsoft.CSharp.dll => 0xdc10265 => 122
	i32 246610117, ; 25: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 171
	i32 264223668, ; 26: zh-Hans\Microsoft.Data.SqlClient.resources => 0xfbfbbb4 => 9
	i32 280992041, ; 27: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 13
	i32 317674968, ; 28: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 41
	i32 318968648, ; 29: Xamarin.AndroidX.Activity.dll => 0x13031348 => 90
	i32 330147069, ; 30: Microsoft.SqlServer.Server => 0x13ada4fd => 74
	i32 336156722, ; 31: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 26
	i32 342366114, ; 32: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 102
	i32 347068432, ; 33: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 80
	i32 356389973, ; 34: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 25
	i32 367780167, ; 35: System.IO.Pipes => 0x15ebe147 => 149
	i32 374914964, ; 36: System.Transactions.Local => 0x1658bf94 => 202
	i32 375677976, ; 37: System.Net.ServicePoint.dll => 0x16646418 => 160
	i32 379916513, ; 38: System.Threading.Thread.dll => 0x16a510e1 => 199
	i32 385762202, ; 39: System.Memory.dll => 0x16fe439a => 152
	i32 392610295, ; 40: System.Threading.ThreadPool.dll => 0x1766c1f7 => 200
	i32 395744057, ; 41: _Microsoft.Android.Resource.Designer => 0x17969339 => 45
	i32 435591531, ; 42: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 37
	i32 442565967, ; 43: System.Collections => 0x1a61054f => 129
	i32 450948140, ; 44: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 101
	i32 451504562, ; 45: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 189
	i32 456227837, ; 46: System.Web.HttpUtility.dll => 0x1b317bfd => 203
	i32 459347974, ; 47: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 179
	i32 469710990, ; 48: System.dll => 0x1bff388e => 208
	i32 485463106, ; 49: Microsoft.IdentityModel.Abstractions => 0x1cef9442 => 63
	i32 498788369, ; 50: System.ObjectModel => 0x1dbae811 => 165
	i32 500358224, ; 51: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 24
	i32 503918385, ; 52: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 18
	i32 513247710, ; 53: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 60
	i32 539058512, ; 54: Microsoft.Extensions.Logging => 0x20216150 => 57
	i32 546455878, ; 55: System.Runtime.Serialization.Xml => 0x20924146 => 180
	i32 548916678, ; 56: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 50
	i32 577335427, ; 57: System.Security.Cryptography.Cng => 0x22697083 => 185
	i32 592146354, ; 58: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 32
	i32 597488923, ; 59: CommunityToolkit.Maui => 0x239cf51b => 48
	i32 604400286, ; 60: StoresPlace-Business.dll => 0x24066a9e => 119
	i32 613668793, ; 61: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 184
	i32 627609679, ; 62: Xamarin.AndroidX.CustomView => 0x2568904f => 99
	i32 627931235, ; 63: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 30
	i32 639912106, ; 64: StoresPlace-Business => 0x262448aa => 119
	i32 662205335, ; 65: System.Text.Encodings.Web.dll => 0x27787397 => 194
	i32 672442732, ; 66: System.Collections.Concurrent => 0x2814a96c => 125
	i32 683518922, ; 67: System.Net.Security => 0x28bdabca => 159
	i32 688181140, ; 68: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 12
	i32 690569205, ; 69: System.Xml.Linq.dll => 0x29293ff5 => 204
	i32 706645707, ; 70: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 27
	i32 709557578, ; 71: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 15
	i32 722857257, ; 72: System.Runtime.Loader.dll => 0x2b15ed29 => 175
	i32 723796036, ; 73: System.ClientModel.dll => 0x2b244044 => 83
	i32 748832960, ; 74: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 78
	i32 759454413, ; 75: System.Net.Requests => 0x2d445acd => 158
	i32 762598435, ; 76: System.IO.Pipes.dll => 0x2d745423 => 149
	i32 775507847, ; 77: System.IO.Compression => 0x2e394f87 => 146
	i32 777317022, ; 78: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 36
	i32 789151979, ; 79: Microsoft.Extensions.Options => 0x2f0980eb => 59
	i32 804715423, ; 80: System.Data.Common => 0x2ff6fb9f => 135
	i32 823281589, ; 81: System.Private.Uri.dll => 0x311247b5 => 167
	i32 830298997, ; 82: System.IO.Compression.Brotli => 0x317d5b75 => 145
	i32 904024072, ; 83: System.ComponentModel.Primitives.dll => 0x35e25008 => 131
	i32 926902833, ; 84: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 39
	i32 955402788, ; 85: Newtonsoft.Json => 0x38f24a24 => 75
	i32 967690846, ; 86: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 102
	i32 975236339, ; 87: System.Diagnostics.Tracing => 0x3a20ecf3 => 141
	i32 975874589, ; 88: System.Xml.XDocument => 0x3a2aaa1d => 206
	i32 986514023, ; 89: System.Private.DataContractSerialization.dll => 0x3acd0267 => 166
	i32 992768348, ; 90: System.Collections.dll => 0x3b2c715c => 129
	i32 1012816738, ; 91: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 112
	i32 1019214401, ; 92: System.Drawing => 0x3cbffa41 => 143
	i32 1028951442, ; 93: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 56
	i32 1029334545, ; 94: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 14
	i32 1035644815, ; 95: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 91
	i32 1036536393, ; 96: System.Drawing.Primitives.dll => 0x3dc84a49 => 142
	i32 1044663988, ; 97: System.Linq.Expressions.dll => 0x3e444eb4 => 150
	i32 1048439329, ; 98: de/Microsoft.Data.SqlClient.resources.dll => 0x3e7dea21 => 1
	i32 1052210849, ; 99: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 104
	i32 1062017875, ; 100: Microsoft.Identity.Client.Extensions.Msal => 0x3f4d1b53 => 62
	i32 1082857460, ; 101: System.ComponentModel.TypeConverter => 0x408b17f4 => 132
	i32 1084122840, ; 102: Xamarin.Kotlin.StdLib => 0x409e66d8 => 117
	i32 1089913930, ; 103: System.Diagnostics.EventLog.dll => 0x40f6c44a => 85
	i32 1098259244, ; 104: System => 0x41761b2c => 208
	i32 1118262833, ; 105: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 27
	i32 1138436374, ; 106: Microsoft.Data.SqlClient.dll => 0x43db2916 => 51
	i32 1168523401, ; 107: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 33
	i32 1178241025, ; 108: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 109
	i32 1201029973, ; 109: StarkbankEcdsa => 0x47964355 => 82
	i32 1203215381, ; 110: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 31
	i32 1208641965, ; 111: System.Diagnostics.Process => 0x480a69ad => 137
	i32 1215846396, ; 112: StoresPlace-Front => 0x487857fc => 121
	i32 1234928153, ; 113: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 29
	i32 1260983243, ; 114: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 13
	i32 1292207520, ; 115: SQLitePCLRaw.core.dll => 0x4d0585a0 => 79
	i32 1293217323, ; 116: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 100
	i32 1309188875, ; 117: System.Private.DataContractSerialization => 0x4e08a30b => 166
	i32 1324164729, ; 118: System.Linq => 0x4eed2679 => 151
	i32 1335329327, ; 119: System.Runtime.Serialization.Json.dll => 0x4f97822f => 178
	i32 1373134921, ; 120: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 43
	i32 1376866003, ; 121: Xamarin.AndroidX.SavedState => 0x52114ed3 => 112
	i32 1406073936, ; 122: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 96
	i32 1408764838, ; 123: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 177
	i32 1430672901, ; 124: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 11
	i32 1433687999, ; 125: SendGrid.dll => 0x557457bf => 77
	i32 1452070440, ; 126: System.Formats.Asn1.dll => 0x568cd628 => 144
	i32 1458022317, ; 127: System.Net.Security.dll => 0x56e7a7ad => 159
	i32 1460893475, ; 128: System.IdentityModel.Tokens.Jwt => 0x57137723 => 86
	i32 1461004990, ; 129: es\Microsoft.Maui.Controls.resources => 0x57152abe => 17
	i32 1461234159, ; 130: System.Collections.Immutable.dll => 0x5718a9ef => 126
	i32 1462112819, ; 131: System.IO.Compression.dll => 0x57261233 => 146
	i32 1469204771, ; 132: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 92
	i32 1470490898, ; 133: Microsoft.Extensions.Primitives => 0x57a5e912 => 60
	i32 1479771757, ; 134: System.Collections.Immutable => 0x5833866d => 126
	i32 1480492111, ; 135: System.IO.Compression.Brotli.dll => 0x583e844f => 145
	i32 1487239319, ; 136: Microsoft.Win32.Primitives => 0x58a57897 => 123
	i32 1490351284, ; 137: Microsoft.Data.Sqlite.dll => 0x58d4f4b4 => 52
	i32 1493001747, ; 138: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 21
	i32 1498168481, ; 139: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 64
	i32 1514721132, ; 140: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 16
	i32 1536373174, ; 141: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 139
	i32 1543031311, ; 142: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 196
	i32 1551623176, ; 143: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 36
	i32 1565310744, ; 144: System.Runtime.Caching => 0x5d4cbf18 => 88
	i32 1573704789, ; 145: System.Runtime.Serialization.Json => 0x5dccd455 => 178
	i32 1582305585, ; 146: Azure.Identity => 0x5e501131 => 47
	i32 1596263029, ; 147: zh-Hant\Microsoft.Data.SqlClient.resources => 0x5f250a75 => 10
	i32 1604827217, ; 148: System.Net.WebClient => 0x5fa7b851 => 162
	i32 1622152042, ; 149: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 106
	i32 1624863272, ; 150: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 115
	i32 1628113371, ; 151: Microsoft.IdentityModel.Protocols.OpenIdConnect => 0x610b09db => 67
	i32 1634654947, ; 152: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 49
	i32 1636350590, ; 153: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 98
	i32 1639515021, ; 154: System.Net.Http.dll => 0x61b9038d => 153
	i32 1639986890, ; 155: System.Text.RegularExpressions => 0x61c036ca => 196
	i32 1641389582, ; 156: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 130
	i32 1657153582, ; 157: System.Runtime => 0x62c6282e => 181
	i32 1658251792, ; 158: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 116
	i32 1677501392, ; 159: System.Net.Primitives.dll => 0x63fca3d0 => 157
	i32 1679769178, ; 160: System.Security.Cryptography => 0x641f3e5a => 190
	i32 1688112883, ; 161: Microsoft.Data.Sqlite => 0x649e8ef3 => 52
	i32 1696967625, ; 162: System.Security.Cryptography.Csp => 0x6525abc9 => 186
	i32 1711441057, ; 163: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 80
	i32 1729485958, ; 164: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 94
	i32 1736233607, ; 165: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 34
	i32 1743415430, ; 166: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 12
	i32 1744735666, ; 167: System.Transactions.Local.dll => 0x67fe8db2 => 202
	i32 1750313021, ; 168: Microsoft.Win32.Primitives.dll => 0x6853a83d => 123
	i32 1763938596, ; 169: System.Diagnostics.TraceSource.dll => 0x69239124 => 140
	i32 1766324549, ; 170: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 113
	i32 1770582343, ; 171: Microsoft.Extensions.Logging.dll => 0x6988f147 => 57
	i32 1780572499, ; 172: Mono.Android.Runtime.dll => 0x6a216153 => 212
	i32 1782862114, ; 173: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 28
	i32 1788241197, ; 174: Xamarin.AndroidX.Fragment => 0x6a96652d => 101
	i32 1793755602, ; 175: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 20
	i32 1794500907, ; 176: Microsoft.Identity.Client.dll => 0x6af5e92b => 61
	i32 1796167890, ; 177: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 50
	i32 1808609942, ; 178: Xamarin.AndroidX.Loader => 0x6bcd3296 => 106
	i32 1813058853, ; 179: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 117
	i32 1813201214, ; 180: Xamarin.Google.Android.Material => 0x6c13413e => 116
	i32 1818569960, ; 181: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 110
	i32 1824175904, ; 182: System.Text.Encoding.Extensions => 0x6cbab720 => 193
	i32 1824722060, ; 183: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 177
	i32 1828688058, ; 184: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 58
	i32 1842015223, ; 185: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 40
	i32 1853025655, ; 186: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 37
	i32 1858542181, ; 187: System.Linq.Expressions => 0x6ec71a65 => 150
	i32 1870277092, ; 188: System.Reflection.Primitives => 0x6f7a29e4 => 172
	i32 1871986876, ; 189: Microsoft.IdentityModel.Protocols.OpenIdConnect.dll => 0x6f9440bc => 67
	i32 1875935024, ; 190: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 19
	i32 1910275211, ; 191: System.Collections.NonGeneric.dll => 0x71dc7c8b => 127
	i32 1939592360, ; 192: System.Private.Xml.Linq => 0x739bd4a8 => 168
	i32 1968388702, ; 193: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 53
	i32 1986222447, ; 194: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 68
	i32 2003115576, ; 195: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 16
	i32 2011961780, ; 196: System.Buffers.dll => 0x77ec19b4 => 124
	i32 2019465201, ; 197: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 104
	i32 2025202353, ; 198: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 11
	i32 2040764568, ; 199: Microsoft.Identity.Client.Extensions.Msal.dll => 0x79a39898 => 62
	i32 2045470958, ; 200: System.Private.Xml => 0x79eb68ee => 169
	i32 2055257422, ; 201: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 103
	i32 2066184531, ; 202: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 15
	i32 2070888862, ; 203: System.Diagnostics.TraceSource => 0x7b6f419e => 140
	i32 2079903147, ; 204: System.Runtime.dll => 0x7bf8cdab => 181
	i32 2090596640, ; 205: System.Numerics.Vectors => 0x7c9bf920 => 164
	i32 2103459038, ; 206: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 81
	i32 2127167465, ; 207: System.Console => 0x7ec9ffe9 => 134
	i32 2142473426, ; 208: System.Collections.Specialized => 0x7fb38cd2 => 128
	i32 2143790110, ; 209: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 207
	i32 2159891885, ; 210: Microsoft.Maui => 0x80bd55ad => 71
	i32 2169148018, ; 211: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 23
	i32 2181898931, ; 212: Microsoft.Extensions.Options.dll => 0x820d22b3 => 59
	i32 2192057212, ; 213: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 58
	i32 2193016926, ; 214: System.ObjectModel.dll => 0x82b6c85e => 165
	i32 2201107256, ; 215: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 118
	i32 2201231467, ; 216: System.Net.Http => 0x8334206b => 153
	i32 2207618523, ; 217: it\Microsoft.Maui.Controls.resources => 0x839595db => 25
	i32 2210798277, ; 218: SendGrid => 0x83c61ac5 => 77
	i32 2228745826, ; 219: pt-BR\Microsoft.Data.SqlClient.resources => 0x84d7f662 => 7
	i32 2253551641, ; 220: Microsoft.IdentityModel.Protocols => 0x86527819 => 66
	i32 2265110946, ; 221: System.Security.AccessControl.dll => 0x8702d9a2 => 182
	i32 2266799131, ; 222: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 54
	i32 2270573516, ; 223: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 19
	i32 2279755925, ; 224: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 111
	i32 2295906218, ; 225: System.Net.Sockets => 0x88d8bfaa => 161
	i32 2298471582, ; 226: System.Net.Mail => 0x88ffe49e => 154
	i32 2303942373, ; 227: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 29
	i32 2305521784, ; 228: System.Private.CoreLib.dll => 0x896b7878 => 210
	i32 2309278602, ; 229: ko\Microsoft.Data.SqlClient.resources => 0x89a4cb8a => 6
	i32 2340441535, ; 230: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 173
	i32 2353062107, ; 231: System.Net.Primitives => 0x8c40e0db => 157
	i32 2368005991, ; 232: System.Xml.ReaderWriter.dll => 0x8d24e767 => 205
	i32 2369706906, ; 233: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 65
	i32 2371007202, ; 234: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 53
	i32 2378619854, ; 235: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 186
	i32 2383496789, ; 236: System.Security.Principal.Windows.dll => 0x8e114655 => 191
	i32 2395872292, ; 237: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 24
	i32 2401565422, ; 238: System.Web.HttpUtility => 0x8f24faee => 203
	i32 2427813419, ; 239: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 21
	i32 2435356389, ; 240: System.Console.dll => 0x912896e5 => 134
	i32 2458678730, ; 241: System.Net.Sockets.dll => 0x928c75ca => 161
	i32 2465273461, ; 242: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 78
	i32 2471841756, ; 243: netstandard.dll => 0x93554fdc => 209
	i32 2475788418, ; 244: Java.Interop.dll => 0x93918882 => 211
	i32 2480646305, ; 245: Microsoft.Maui.Controls => 0x93dba8a1 => 69
	i32 2483903535, ; 246: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 130
	i32 2484371297, ; 247: System.Net.ServicePoint => 0x94147f61 => 160
	i32 2509217888, ; 248: System.Diagnostics.EventLog => 0x958fa060 => 85
	i32 2538310050, ; 249: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 171
	i32 2550873716, ; 250: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 22
	i32 2562349572, ; 251: Microsoft.CSharp => 0x98ba5a04 => 122
	i32 2570120770, ; 252: System.Text.Encodings.Web => 0x9930ee42 => 194
	i32 2585220780, ; 253: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 193
	i32 2589602615, ; 254: System.Threading.ThreadPool => 0x9a5a3337 => 200
	i32 2593496499, ; 255: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 31
	i32 2605712449, ; 256: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 118
	i32 2617129537, ; 257: System.Private.Xml.dll => 0x9bfe3a41 => 169
	i32 2620871830, ; 258: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 98
	i32 2626831493, ; 259: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 26
	i32 2627185994, ; 260: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 139
	i32 2628210652, ; 261: System.Memory.Data => 0x9ca74fdc => 87
	i32 2640290731, ; 262: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 65
	i32 2640706905, ; 263: Azure.Core => 0x9d65fd59 => 46
	i32 2660759594, ; 264: System.Security.Cryptography.ProtectedData.dll => 0x9e97f82a => 89
	i32 2663698177, ; 265: System.Runtime.Loader => 0x9ec4cf01 => 175
	i32 2664396074, ; 266: System.Xml.XDocument.dll => 0x9ecf752a => 206
	i32 2665622720, ; 267: System.Drawing.Primitives => 0x9ee22cc0 => 142
	i32 2676780864, ; 268: System.Data.Common.dll => 0x9f8c6f40 => 135
	i32 2677098746, ; 269: Azure.Identity.dll => 0x9f9148fa => 47
	i32 2686887180, ; 270: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 180
	i32 2717744543, ; 271: System.Security.Claims => 0xa1fd7d9f => 183
	i32 2719963679, ; 272: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 185
	i32 2724373263, ; 273: System.Runtime.Numerics.dll => 0xa262a30f => 176
	i32 2732626843, ; 274: Xamarin.AndroidX.Activity => 0xa2e0939b => 90
	i32 2735172069, ; 275: System.Threading.Channels => 0xa30769e5 => 197
	i32 2737747696, ; 276: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 92
	i32 2740051746, ; 277: Microsoft.Identity.Client => 0xa351df22 => 61
	i32 2752995522, ; 278: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 32
	i32 2755098380, ; 279: Microsoft.SqlServer.Server.dll => 0xa437770c => 74
	i32 2758225723, ; 280: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 70
	i32 2764765095, ; 281: Microsoft.Maui.dll => 0xa4caf7a7 => 71
	i32 2765824710, ; 282: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 192
	i32 2778768386, ; 283: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 114
	i32 2785988530, ; 284: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 38
	i32 2801831435, ; 285: Microsoft.Maui.Graphics => 0xa7008e0b => 73
	i32 2804509662, ; 286: es/Microsoft.Data.SqlClient.resources.dll => 0xa7296bde => 2
	i32 2806116107, ; 287: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 17
	i32 2810250172, ; 288: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 96
	i32 2831556043, ; 289: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 30
	i32 2841937114, ; 290: it/Microsoft.Data.SqlClient.resources.dll => 0xa96484da => 4
	i32 2853208004, ; 291: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 114
	i32 2856443450, ; 292: ar/StoresPlace-Front.resources.dll => 0xaa41de3a => 0
	i32 2861189240, ; 293: Microsoft.Maui.Essentials => 0xaa8a4878 => 72
	i32 2867946736, ; 294: System.Security.Cryptography.ProtectedData => 0xaaf164f0 => 89
	i32 2868488919, ; 295: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 49
	i32 2893329082, ; 296: StoresPlace-DataAccess => 0xac74b2ba => 120
	i32 2909740682, ; 297: System.Private.CoreLib => 0xad6f1e8a => 210
	i32 2916838712, ; 298: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 115
	i32 2919462931, ; 299: System.Numerics.Vectors.dll => 0xae037813 => 164
	i32 2940926066, ; 300: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 138
	i32 2944313911, ; 301: System.Configuration.ConfigurationManager.dll => 0xaf7eaa37 => 84
	i32 2959614098, ; 302: System.ComponentModel.dll => 0xb0682092 => 133
	i32 2968338931, ; 303: System.Security.Principal.Windows => 0xb0ed41f3 => 191
	i32 2972252294, ; 304: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 184
	i32 2978675010, ; 305: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 100
	i32 3012788804, ; 306: System.Configuration.ConfigurationManager => 0xb3938244 => 84
	i32 3023511517, ; 307: ru\Microsoft.Data.SqlClient.resources => 0xb4371fdd => 8
	i32 3033605958, ; 308: System.Memory.Data.dll => 0xb4d12746 => 87
	i32 3038032645, ; 309: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 45
	i32 3057625584, ; 310: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 107
	i32 3059408633, ; 311: Mono.Android.Runtime => 0xb65adef9 => 212
	i32 3059793426, ; 312: System.ComponentModel.Primitives => 0xb660be12 => 131
	i32 3077302341, ; 313: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 23
	i32 3084678329, ; 314: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 68
	i32 3090735792, ; 315: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 189
	i32 3099732863, ; 316: System.Security.Claims.dll => 0xb8c22b7f => 183
	i32 3103600923, ; 317: System.Formats.Asn1 => 0xb8fd311b => 144
	i32 3121463068, ; 318: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 147
	i32 3124832203, ; 319: System.Threading.Tasks.Extensions => 0xba4127cb => 198
	i32 3132293585, ; 320: System.Security.AccessControl => 0xbab301d1 => 182
	i32 3147165239, ; 321: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 141
	i32 3158628304, ; 322: zh-Hant/Microsoft.Data.SqlClient.resources.dll => 0xbc44d7d0 => 10
	i32 3159123045, ; 323: System.Reflection.Primitives.dll => 0xbc4c6465 => 172
	i32 3178803400, ; 324: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 108
	i32 3220365878, ; 325: System.Threading => 0xbff2e236 => 201
	i32 3249260365, ; 326: RestSharp.dll => 0xc1abc74d => 76
	i32 3258312781, ; 327: Xamarin.AndroidX.CardView => 0xc235e84d => 94
	i32 3265893370, ; 328: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 198
	i32 3268887220, ; 329: fr/Microsoft.Data.SqlClient.resources.dll => 0xc2d742b4 => 3
	i32 3271840132, ; 330: StarkbankEcdsa.dll => 0xc3045184 => 82
	i32 3276600297, ; 331: pt-BR/Microsoft.Data.SqlClient.resources.dll => 0xc34cf3e9 => 7
	i32 3290767353, ; 332: System.Security.Cryptography.Encoding => 0xc4251ff9 => 187
	i32 3305363605, ; 333: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 18
	i32 3312457198, ; 334: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 64
	i32 3316684772, ; 335: System.Net.Requests.dll => 0xc5b097e4 => 158
	i32 3317135071, ; 336: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 99
	i32 3343947874, ; 337: fr\Microsoft.Data.SqlClient.resources => 0xc7509862 => 3
	i32 3346324047, ; 338: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 109
	i32 3357674450, ; 339: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 35
	i32 3358260929, ; 340: System.Text.Json => 0xc82afec1 => 195
	i32 3360279109, ; 341: SQLitePCLRaw.core => 0xc849ca45 => 79
	i32 3362522851, ; 342: Xamarin.AndroidX.Core => 0xc86c06e3 => 97
	i32 3366347497, ; 343: Java.Interop => 0xc8a662e9 => 211
	i32 3374879918, ; 344: Microsoft.IdentityModel.Protocols.dll => 0xc92894ae => 66
	i32 3374999561, ; 345: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 111
	i32 3381016424, ; 346: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 14
	i32 3428513518, ; 347: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 55
	i32 3430777524, ; 348: netstandard => 0xcc7d82b4 => 209
	i32 3463511458, ; 349: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 22
	i32 3471940407, ; 350: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 132
	i32 3476120550, ; 351: Mono.Android => 0xcf3163e6 => 213
	i32 3479583265, ; 352: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 35
	i32 3484440000, ; 353: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 34
	i32 3485117614, ; 354: System.Text.Json.dll => 0xcfbaacae => 195
	i32 3509114376, ; 355: System.Xml.Linq => 0xd128d608 => 204
	i32 3545306353, ; 356: Microsoft.Data.SqlClient => 0xd35114f1 => 51
	i32 3555084973, ; 357: de\Microsoft.Data.SqlClient.resources => 0xd3e64aad => 1
	i32 3558648585, ; 358: System.ClientModel => 0xd41cab09 => 83
	i32 3561949811, ; 359: Azure.Core.dll => 0xd44f0a73 => 46
	i32 3570554715, ; 360: System.IO.FileSystem.AccessControl => 0xd4d2575b => 147
	i32 3570608287, ; 361: System.Runtime.Caching.dll => 0xd4d3289f => 88
	i32 3580758918, ; 362: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 42
	i32 3608519521, ; 363: System.Linq.dll => 0xd715a361 => 151
	i32 3624195450, ; 364: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 173
	i32 3641597786, ; 365: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 103
	i32 3643446276, ; 366: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 39
	i32 3643854240, ; 367: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 108
	i32 3657292374, ; 368: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 54
	i32 3660523487, ; 369: System.Net.NetworkInformation => 0xda2f27df => 156
	i32 3672681054, ; 370: Mono.Android.dll => 0xdae8aa5e => 213
	i32 3682565725, ; 371: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 93
	i32 3693958177, ; 372: StoresPlace-DataAccess.dll => 0xdc2d5421 => 120
	i32 3697841164, ; 373: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 44
	i32 3700591436, ; 374: Microsoft.IdentityModel.Abstractions.dll => 0xdc928b4c => 63
	i32 3724971120, ; 375: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 107
	i32 3732100267, ; 376: System.Net.NameResolution => 0xde7354ab => 155
	i32 3748608112, ; 377: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 136
	i32 3754567612, ; 378: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 81
	i32 3786282454, ; 379: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 95
	i32 3792276235, ; 380: System.Collections.NonGeneric => 0xe2098b0b => 127
	i32 3802395368, ; 381: System.Collections.Specialized.dll => 0xe2a3f2e8 => 128
	i32 3803019198, ; 382: zh-Hans/Microsoft.Data.SqlClient.resources.dll => 0xe2ad77be => 9
	i32 3816437471, ; 383: RestSharp => 0xe37a36df => 76
	i32 3817368567, ; 384: CommunityToolkit.Maui.dll => 0xe3886bf7 => 48
	i32 3823082795, ; 385: System.Security.Cryptography.dll => 0xe3df9d2b => 190
	i32 3841636137, ; 386: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 56
	i32 3844307129, ; 387: System.Net.Mail.dll => 0xe52378b9 => 154
	i32 3848348906, ; 388: es\Microsoft.Data.SqlClient.resources => 0xe56124ea => 2
	i32 3849253459, ; 389: System.Runtime.InteropServices.dll => 0xe56ef253 => 174
	i32 3875112723, ; 390: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 187
	i32 3885497537, ; 391: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 163
	i32 3889960447, ; 392: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 43
	i32 3896106733, ; 393: System.Collections.Concurrent.dll => 0xe839deed => 125
	i32 3896760992, ; 394: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 97
	i32 3928044579, ; 395: System.Xml.ReaderWriter => 0xea213423 => 205
	i32 3931092270, ; 396: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 110
	i32 3953953790, ; 397: System.Text.Encoding.CodePages => 0xebac8bfe => 192
	i32 3955647286, ; 398: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 91
	i32 3980434154, ; 399: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 38
	i32 3987592930, ; 400: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 20
	i32 4003436829, ; 401: System.Diagnostics.Process.dll => 0xee9f991d => 137
	i32 4025784931, ; 402: System.Memory => 0xeff49a63 => 152
	i32 4046471985, ; 403: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 70
	i32 4054681211, ; 404: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 170
	i32 4068434129, ; 405: System.Private.Xml.Linq.dll => 0xf27f60d1 => 168
	i32 4073602200, ; 406: System.Threading.dll => 0xf2ce3c98 => 201
	i32 4094352644, ; 407: Microsoft.Maui.Essentials.dll => 0xf40add04 => 72
	i32 4099507663, ; 408: System.Drawing.dll => 0xf45985cf => 143
	i32 4100113165, ; 409: System.Private.Uri => 0xf462c30d => 167
	i32 4102112229, ; 410: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 33
	i32 4125707920, ; 411: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 28
	i32 4126470640, ; 412: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 55
	i32 4127667938, ; 413: System.IO.FileSystem.Watcher => 0xf60736e2 => 148
	i32 4147896353, ; 414: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 170
	i32 4150914736, ; 415: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 40
	i32 4159265925, ; 416: System.Xml.XmlSerializer => 0xf7e95c85 => 207
	i32 4164802419, ; 417: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 148
	i32 4181436372, ; 418: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 179
	i32 4182413190, ; 419: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 105
	i32 4196529839, ; 420: System.Net.WebClient.dll => 0xfa21f6af => 162
	i32 4213026141, ; 421: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 136
	i32 4257443520, ; 422: ko/Microsoft.Data.SqlClient.resources.dll => 0xfdc36ec0 => 6
	i32 4260525087, ; 423: System.Buffers => 0xfdf2741f => 124
	i32 4263231520, ; 424: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 86
	i32 4271975918, ; 425: Microsoft.Maui.Controls.dll => 0xfea12dee => 69
	i32 4274976490, ; 426: System.Runtime.Numerics => 0xfecef6ea => 176
	i32 4292120959 ; 427: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 105
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [428 x i32] [
	i32 156, ; 0
	i32 155, ; 1
	i32 75, ; 2
	i32 199, ; 3
	i32 4, ; 4
	i32 5, ; 5
	i32 138, ; 6
	i32 44, ; 7
	i32 188, ; 8
	i32 73, ; 9
	i32 121, ; 10
	i32 174, ; 11
	i32 197, ; 12
	i32 5, ; 13
	i32 163, ; 14
	i32 188, ; 15
	i32 95, ; 16
	i32 8, ; 17
	i32 113, ; 18
	i32 0, ; 19
	i32 41, ; 20
	i32 42, ; 21
	i32 133, ; 22
	i32 93, ; 23
	i32 122, ; 24
	i32 171, ; 25
	i32 9, ; 26
	i32 13, ; 27
	i32 41, ; 28
	i32 90, ; 29
	i32 74, ; 30
	i32 26, ; 31
	i32 102, ; 32
	i32 80, ; 33
	i32 25, ; 34
	i32 149, ; 35
	i32 202, ; 36
	i32 160, ; 37
	i32 199, ; 38
	i32 152, ; 39
	i32 200, ; 40
	i32 45, ; 41
	i32 37, ; 42
	i32 129, ; 43
	i32 101, ; 44
	i32 189, ; 45
	i32 203, ; 46
	i32 179, ; 47
	i32 208, ; 48
	i32 63, ; 49
	i32 165, ; 50
	i32 24, ; 51
	i32 18, ; 52
	i32 60, ; 53
	i32 57, ; 54
	i32 180, ; 55
	i32 50, ; 56
	i32 185, ; 57
	i32 32, ; 58
	i32 48, ; 59
	i32 119, ; 60
	i32 184, ; 61
	i32 99, ; 62
	i32 30, ; 63
	i32 119, ; 64
	i32 194, ; 65
	i32 125, ; 66
	i32 159, ; 67
	i32 12, ; 68
	i32 204, ; 69
	i32 27, ; 70
	i32 15, ; 71
	i32 175, ; 72
	i32 83, ; 73
	i32 78, ; 74
	i32 158, ; 75
	i32 149, ; 76
	i32 146, ; 77
	i32 36, ; 78
	i32 59, ; 79
	i32 135, ; 80
	i32 167, ; 81
	i32 145, ; 82
	i32 131, ; 83
	i32 39, ; 84
	i32 75, ; 85
	i32 102, ; 86
	i32 141, ; 87
	i32 206, ; 88
	i32 166, ; 89
	i32 129, ; 90
	i32 112, ; 91
	i32 143, ; 92
	i32 56, ; 93
	i32 14, ; 94
	i32 91, ; 95
	i32 142, ; 96
	i32 150, ; 97
	i32 1, ; 98
	i32 104, ; 99
	i32 62, ; 100
	i32 132, ; 101
	i32 117, ; 102
	i32 85, ; 103
	i32 208, ; 104
	i32 27, ; 105
	i32 51, ; 106
	i32 33, ; 107
	i32 109, ; 108
	i32 82, ; 109
	i32 31, ; 110
	i32 137, ; 111
	i32 121, ; 112
	i32 29, ; 113
	i32 13, ; 114
	i32 79, ; 115
	i32 100, ; 116
	i32 166, ; 117
	i32 151, ; 118
	i32 178, ; 119
	i32 43, ; 120
	i32 112, ; 121
	i32 96, ; 122
	i32 177, ; 123
	i32 11, ; 124
	i32 77, ; 125
	i32 144, ; 126
	i32 159, ; 127
	i32 86, ; 128
	i32 17, ; 129
	i32 126, ; 130
	i32 146, ; 131
	i32 92, ; 132
	i32 60, ; 133
	i32 126, ; 134
	i32 145, ; 135
	i32 123, ; 136
	i32 52, ; 137
	i32 21, ; 138
	i32 64, ; 139
	i32 16, ; 140
	i32 139, ; 141
	i32 196, ; 142
	i32 36, ; 143
	i32 88, ; 144
	i32 178, ; 145
	i32 47, ; 146
	i32 10, ; 147
	i32 162, ; 148
	i32 106, ; 149
	i32 115, ; 150
	i32 67, ; 151
	i32 49, ; 152
	i32 98, ; 153
	i32 153, ; 154
	i32 196, ; 155
	i32 130, ; 156
	i32 181, ; 157
	i32 116, ; 158
	i32 157, ; 159
	i32 190, ; 160
	i32 52, ; 161
	i32 186, ; 162
	i32 80, ; 163
	i32 94, ; 164
	i32 34, ; 165
	i32 12, ; 166
	i32 202, ; 167
	i32 123, ; 168
	i32 140, ; 169
	i32 113, ; 170
	i32 57, ; 171
	i32 212, ; 172
	i32 28, ; 173
	i32 101, ; 174
	i32 20, ; 175
	i32 61, ; 176
	i32 50, ; 177
	i32 106, ; 178
	i32 117, ; 179
	i32 116, ; 180
	i32 110, ; 181
	i32 193, ; 182
	i32 177, ; 183
	i32 58, ; 184
	i32 40, ; 185
	i32 37, ; 186
	i32 150, ; 187
	i32 172, ; 188
	i32 67, ; 189
	i32 19, ; 190
	i32 127, ; 191
	i32 168, ; 192
	i32 53, ; 193
	i32 68, ; 194
	i32 16, ; 195
	i32 124, ; 196
	i32 104, ; 197
	i32 11, ; 198
	i32 62, ; 199
	i32 169, ; 200
	i32 103, ; 201
	i32 15, ; 202
	i32 140, ; 203
	i32 181, ; 204
	i32 164, ; 205
	i32 81, ; 206
	i32 134, ; 207
	i32 128, ; 208
	i32 207, ; 209
	i32 71, ; 210
	i32 23, ; 211
	i32 59, ; 212
	i32 58, ; 213
	i32 165, ; 214
	i32 118, ; 215
	i32 153, ; 216
	i32 25, ; 217
	i32 77, ; 218
	i32 7, ; 219
	i32 66, ; 220
	i32 182, ; 221
	i32 54, ; 222
	i32 19, ; 223
	i32 111, ; 224
	i32 161, ; 225
	i32 154, ; 226
	i32 29, ; 227
	i32 210, ; 228
	i32 6, ; 229
	i32 173, ; 230
	i32 157, ; 231
	i32 205, ; 232
	i32 65, ; 233
	i32 53, ; 234
	i32 186, ; 235
	i32 191, ; 236
	i32 24, ; 237
	i32 203, ; 238
	i32 21, ; 239
	i32 134, ; 240
	i32 161, ; 241
	i32 78, ; 242
	i32 209, ; 243
	i32 211, ; 244
	i32 69, ; 245
	i32 130, ; 246
	i32 160, ; 247
	i32 85, ; 248
	i32 171, ; 249
	i32 22, ; 250
	i32 122, ; 251
	i32 194, ; 252
	i32 193, ; 253
	i32 200, ; 254
	i32 31, ; 255
	i32 118, ; 256
	i32 169, ; 257
	i32 98, ; 258
	i32 26, ; 259
	i32 139, ; 260
	i32 87, ; 261
	i32 65, ; 262
	i32 46, ; 263
	i32 89, ; 264
	i32 175, ; 265
	i32 206, ; 266
	i32 142, ; 267
	i32 135, ; 268
	i32 47, ; 269
	i32 180, ; 270
	i32 183, ; 271
	i32 185, ; 272
	i32 176, ; 273
	i32 90, ; 274
	i32 197, ; 275
	i32 92, ; 276
	i32 61, ; 277
	i32 32, ; 278
	i32 74, ; 279
	i32 70, ; 280
	i32 71, ; 281
	i32 192, ; 282
	i32 114, ; 283
	i32 38, ; 284
	i32 73, ; 285
	i32 2, ; 286
	i32 17, ; 287
	i32 96, ; 288
	i32 30, ; 289
	i32 4, ; 290
	i32 114, ; 291
	i32 0, ; 292
	i32 72, ; 293
	i32 89, ; 294
	i32 49, ; 295
	i32 120, ; 296
	i32 210, ; 297
	i32 115, ; 298
	i32 164, ; 299
	i32 138, ; 300
	i32 84, ; 301
	i32 133, ; 302
	i32 191, ; 303
	i32 184, ; 304
	i32 100, ; 305
	i32 84, ; 306
	i32 8, ; 307
	i32 87, ; 308
	i32 45, ; 309
	i32 107, ; 310
	i32 212, ; 311
	i32 131, ; 312
	i32 23, ; 313
	i32 68, ; 314
	i32 189, ; 315
	i32 183, ; 316
	i32 144, ; 317
	i32 147, ; 318
	i32 198, ; 319
	i32 182, ; 320
	i32 141, ; 321
	i32 10, ; 322
	i32 172, ; 323
	i32 108, ; 324
	i32 201, ; 325
	i32 76, ; 326
	i32 94, ; 327
	i32 198, ; 328
	i32 3, ; 329
	i32 82, ; 330
	i32 7, ; 331
	i32 187, ; 332
	i32 18, ; 333
	i32 64, ; 334
	i32 158, ; 335
	i32 99, ; 336
	i32 3, ; 337
	i32 109, ; 338
	i32 35, ; 339
	i32 195, ; 340
	i32 79, ; 341
	i32 97, ; 342
	i32 211, ; 343
	i32 66, ; 344
	i32 111, ; 345
	i32 14, ; 346
	i32 55, ; 347
	i32 209, ; 348
	i32 22, ; 349
	i32 132, ; 350
	i32 213, ; 351
	i32 35, ; 352
	i32 34, ; 353
	i32 195, ; 354
	i32 204, ; 355
	i32 51, ; 356
	i32 1, ; 357
	i32 83, ; 358
	i32 46, ; 359
	i32 147, ; 360
	i32 88, ; 361
	i32 42, ; 362
	i32 151, ; 363
	i32 173, ; 364
	i32 103, ; 365
	i32 39, ; 366
	i32 108, ; 367
	i32 54, ; 368
	i32 156, ; 369
	i32 213, ; 370
	i32 93, ; 371
	i32 120, ; 372
	i32 44, ; 373
	i32 63, ; 374
	i32 107, ; 375
	i32 155, ; 376
	i32 136, ; 377
	i32 81, ; 378
	i32 95, ; 379
	i32 127, ; 380
	i32 128, ; 381
	i32 9, ; 382
	i32 76, ; 383
	i32 48, ; 384
	i32 190, ; 385
	i32 56, ; 386
	i32 154, ; 387
	i32 2, ; 388
	i32 174, ; 389
	i32 187, ; 390
	i32 163, ; 391
	i32 43, ; 392
	i32 125, ; 393
	i32 97, ; 394
	i32 205, ; 395
	i32 110, ; 396
	i32 192, ; 397
	i32 91, ; 398
	i32 38, ; 399
	i32 20, ; 400
	i32 137, ; 401
	i32 152, ; 402
	i32 70, ; 403
	i32 170, ; 404
	i32 168, ; 405
	i32 201, ; 406
	i32 72, ; 407
	i32 143, ; 408
	i32 167, ; 409
	i32 33, ; 410
	i32 28, ; 411
	i32 55, ; 412
	i32 148, ; 413
	i32 170, ; 414
	i32 40, ; 415
	i32 207, ; 416
	i32 148, ; 417
	i32 179, ; 418
	i32 105, ; 419
	i32 162, ; 420
	i32 136, ; 421
	i32 6, ; 422
	i32 124, ; 423
	i32 86, ; 424
	i32 69, ; 425
	i32 176, ; 426
	i32 105 ; 427
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

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
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
