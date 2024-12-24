; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [214 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [428 x i64] [
	i64 98382396393917666, ; 0: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 60
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 213
	i64 131669012237370309, ; 2: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 72
	i64 196720943101637631, ; 3: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 150
	i64 210515253464952879, ; 4: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 95
	i64 232391251801502327, ; 5: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 112
	i64 545109961164950392, ; 6: fi/Microsoft.Maui.Controls.resources.dll => 0x7909e9f1ec38b78 => 18
	i64 560278790331054453, ; 7: System.Reflection.Primitives => 0x7c6829760de3975 => 172
	i64 670564002081277297, ; 8: Microsoft.Identity.Client.dll => 0x94e526837380571 => 61
	i64 750875890346172408, ; 9: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 199
	i64 769231974326215379, ; 10: ja/Microsoft.Data.SqlClient.resources.dll => 0xaacdc67b39622d3 => 5
	i64 799765834175365804, ; 11: System.ComponentModel.dll => 0xb1956c9f18442ac => 133
	i64 849051935479314978, ; 12: hi/Microsoft.Maui.Controls.resources.dll => 0xbc8703ca21a3a22 => 21
	i64 870603111519317375, ; 13: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 80
	i64 872800313462103108, ; 14: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 100
	i64 937459790420187032, ; 15: Microsoft.SqlServer.Server.dll => 0xd0286b667351798 => 74
	i64 1010599046655515943, ; 16: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 172
	i64 1060858978308751610, ; 17: Azure.Core.dll => 0xeb8ed9ebee080fa => 46
	i64 1120440138749646132, ; 18: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 116
	i64 1121665720830085036, ; 19: nb/Microsoft.Maui.Controls.resources.dll => 0xf90f507becf47ac => 29
	i64 1150430735170971895, ; 20: ru\Microsoft.Data.SqlClient.resources => 0xff726a88c8ea8f7 => 8
	i64 1268860745194512059, ; 21: System.Drawing.dll => 0x119be62002c19ebb => 143
	i64 1301485588176585670, ; 22: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 79
	i64 1369545283391376210, ; 23: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 108
	i64 1404195534211153682, ; 24: System.IO.FileSystem.Watcher.dll => 0x137cb4660bd87f12 => 148
	i64 1476839205573959279, ; 25: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 157
	i64 1486715745332614827, ; 26: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 69
	i64 1513467482682125403, ; 27: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 212
	i64 1518315023656898250, ; 28: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 81
	i64 1537168428375924959, ; 29: System.Threading.Thread.dll => 0x15551e8a954ae0df => 199
	i64 1556147632182429976, ; 30: ko/Microsoft.Maui.Controls.resources.dll => 0x15988c06d24c8918 => 27
	i64 1624659445732251991, ; 31: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 92
	i64 1628611045998245443, ; 32: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 105
	i64 1672383392659050004, ; 33: Microsoft.Data.Sqlite.dll => 0x17357fd5bfb48e14 => 52
	i64 1731380447121279447, ; 34: Newtonsoft.Json => 0x18071957e9b889d7 => 75
	i64 1735388228521408345, ; 35: System.Net.Mail.dll => 0x181556663c69b759 => 154
	i64 1743969030606105336, ; 36: System.Memory.dll => 0x1833d297e88f2af8 => 152
	i64 1767386781656293639, ; 37: System.Private.Uri.dll => 0x188704e9f5582107 => 167
	i64 1795316252682057001, ; 38: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 91
	i64 1825687700144851180, ; 39: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 173
	i64 1835311033149317475, ; 40: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 17
	i64 1836611346387731153, ; 41: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 112
	i64 1865037103900624886, ; 42: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 50
	i64 1875417405349196092, ; 43: System.Drawing.Primitives => 0x1a06d2319b6c713c => 142
	i64 1881198190668717030, ; 44: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 39
	i64 1920760634179481754, ; 45: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 70
	i64 1959996714666907089, ; 46: tr/Microsoft.Maui.Controls.resources.dll => 0x1b334ea0a2a755d1 => 39
	i64 1972385128188460614, ; 47: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 184
	i64 1981742497975770890, ; 48: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 104
	i64 1983698669889758782, ; 49: cs/Microsoft.Maui.Controls.resources.dll => 0x1b87836e2031a63e => 13
	i64 2019660174692588140, ; 50: pl/Microsoft.Maui.Controls.resources.dll => 0x1c07463a6f8e1a6c => 31
	i64 2040001226662520565, ; 51: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 198
	i64 2102659300918482391, ; 52: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 142
	i64 2133195048986300728, ; 53: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 75
	i64 2165725771938924357, ; 54: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 93
	i64 2262844636196693701, ; 55: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 100
	i64 2287834202362508563, ; 56: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 125
	i64 2302323944321350744, ; 57: ru/Microsoft.Maui.Controls.resources.dll => 0x1ff37f6ddb267c58 => 35
	i64 2316229908869312383, ; 58: Microsoft.IdentityModel.Protocols.OpenIdConnect => 0x2024e6d4884a6f7f => 67
	i64 2329709569556905518, ; 59: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 103
	i64 2335503487726329082, ; 60: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 194
	i64 2470498323731680442, ; 61: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 96
	i64 2497223385847772520, ; 62: System.Runtime => 0x22a7eb7046413568 => 181
	i64 2547086958574651984, ; 63: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 90
	i64 2554797818648757682, ; 64: System.Runtime.Caching.dll => 0x23747714858085b2 => 88
	i64 2602673633151553063, ; 65: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 38
	i64 2612152650457191105, ; 66: Microsoft.IdentityModel.Tokens.dll => 0x24403afeed9892c1 => 68
	i64 2632269733008246987, ; 67: System.Net.NameResolution => 0x2487b36034f808cb => 155
	i64 2656907746661064104, ; 68: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 55
	i64 2662981627730767622, ; 69: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 13
	i64 2789714023057451704, ; 70: Microsoft.IdentityModel.JsonWebTokens.dll => 0x26b70e1f9943eab8 => 64
	i64 2815524396660695947, ; 71: System.Security.AccessControl => 0x2712c0857f68238b => 182
	i64 2851879596360956261, ; 72: System.Configuration.ConfigurationManager => 0x2793e9620b477965 => 84
	i64 2895129759130297543, ; 73: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 18
	i64 3004558106879253741, ; 74: ja\Microsoft.Data.SqlClient.resources => 0x29b255adeb8edced => 5
	i64 3017704767998173186, ; 75: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 116
	i64 3063847325783385934, ; 76: System.ClientModel.dll => 0x2a84f8e8eb59674e => 83
	i64 3106852385031680087, ; 77: System.Runtime.Serialization.Xml => 0x2b1dc1c88b637057 => 180
	i64 3110390492489056344, ; 78: System.Security.Cryptography.Csp.dll => 0x2b2a53ac61900058 => 186
	i64 3289520064315143713, ; 79: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 102
	i64 3311221304742556517, ; 80: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 164
	i64 3325875462027654285, ; 81: System.Runtime.Numerics => 0x2e27e21c8958b48d => 176
	i64 3328853167529574890, ; 82: System.Net.Sockets.dll => 0x2e327651a008c1ea => 161
	i64 3344514922410554693, ; 83: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 118
	i64 3402534845034375023, ; 84: System.IdentityModel.Tokens.Jwt.dll => 0x2f383b6a0629a76f => 86
	i64 3429672777697402584, ; 85: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 72
	i64 3494946837667399002, ; 86: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 53
	i64 3522470458906976663, ; 87: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 113
	i64 3551103847008531295, ; 88: System.Private.CoreLib.dll => 0x31480e226177735f => 210
	i64 3567343442040498961, ; 89: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 33
	i64 3571415421602489686, ; 90: System.Runtime.dll => 0x319037675df7e556 => 181
	i64 3610052191230710096, ; 91: StarkbankEcdsa => 0x32197b574eed5150 => 82
	i64 3638003163729360188, ; 92: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 54
	i64 3647754201059316852, ; 93: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 205
	i64 3655542548057982301, ; 94: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 53
	i64 3716579019761409177, ; 95: netstandard.dll => 0x3393f0ed5c8c5c99 => 209
	i64 3727469159507183293, ; 96: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 111
	i64 3869221888984012293, ; 97: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 57
	i64 3890352374528606784, ; 98: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 70
	i64 3919223565570527920, ; 99: System.Security.Cryptography.Encoding => 0x3663e111652bd2b0 => 187
	i64 3933965368022646939, ; 100: System.Net.Requests => 0x369840a8bfadc09b => 158
	i64 3966267475168208030, ; 101: System.Memory => 0x370b03412596249e => 152
	i64 4009997192427317104, ; 102: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 179
	i64 4073500526318903918, ; 103: System.Private.Xml.dll => 0x3887fb25779ae26e => 169
	i64 4090066110372993390, ; 104: fr/Microsoft.Data.SqlClient.resources.dll => 0x38c2d57510a5596e => 3
	i64 4120493066591692148, ; 105: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 44
	i64 4154383907710350974, ; 106: System.ComponentModel => 0x39a7562737acb67e => 133
	i64 4167269041631776580, ; 107: System.Threading.ThreadPool => 0x39d51d1d3df1cf44 => 200
	i64 4168469861834746866, ; 108: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 183
	i64 4187479170553454871, ; 109: System.Linq.Expressions => 0x3a1cea1e912fa117 => 150
	i64 4205801962323029395, ; 110: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 132
	i64 4321865999928413850, ; 111: System.Diagnostics.EventLog.dll => 0x3bfa5a3a8c924e9a => 85
	i64 4337444564132831293, ; 112: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 78
	i64 4343083164021660430, ; 113: zh-Hans/Microsoft.Data.SqlClient.resources.dll => 0x3c45bb20857d9b0e => 9
	i64 4356591372459378815, ; 114: vi/Microsoft.Maui.Controls.resources.dll => 0x3c75b8c562f9087f => 41
	i64 4373617458794931033, ; 115: System.IO.Pipes.dll => 0x3cb235e806eb2359 => 149
	i64 4477672992252076438, ; 116: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 203
	i64 4672453897036726049, ; 117: System.IO.FileSystem.Watcher => 0x40d7e4104a437f21 => 148
	i64 4679594760078841447, ; 118: ar/Microsoft.Maui.Controls.resources.dll => 0x40f142a407475667 => 11
	i64 4716677666592453464, ; 119: System.Xml.XmlSerializer => 0x417501590542f358 => 207
	i64 4794310189461587505, ; 120: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 90
	i64 4795410492532947900, ; 121: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 113
	i64 4809057822547766521, ; 122: System.Drawing => 0x42bd349c3145ecf9 => 143
	i64 4814660307502931973, ; 123: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 155
	i64 4853321196694829351, ; 124: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 175
	i64 5103417709280584325, ; 125: System.Collections.Specialized => 0x46d2fb5e161b6285 => 128
	i64 5129462924058778861, ; 126: Microsoft.Data.Sqlite => 0x472f835a350f5ced => 52
	i64 5182934613077526976, ; 127: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 128
	i64 5278787618751394462, ; 128: System.Net.WebClient.dll => 0x4942055efc68329e => 162
	i64 5290786973231294105, ; 129: System.Runtime.Loader => 0x496ca6b869b72699 => 175
	i64 5423376490970181369, ; 130: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 173
	i64 5471532531798518949, ; 131: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 37
	i64 5522859530602327440, ; 132: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 40
	i64 5570799893513421663, ; 133: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 145
	i64 5573260873512690141, ; 134: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 190
	i64 5650097808083101034, ; 135: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 184
	i64 5692067934154308417, ; 136: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 115
	i64 5979151488806146654, ; 137: System.Formats.Asn1 => 0x52fa3699a489d25e => 144
	i64 5984759512290286505, ; 138: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 188
	i64 6068057819846744445, ; 139: ro/Microsoft.Maui.Controls.resources.dll => 0x5436126fec7f197d => 34
	i64 6183170893902868313, ; 140: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 78
	i64 6200764641006662125, ; 141: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 34
	i64 6222399776351216807, ; 142: System.Text.Json.dll => 0x565a67a0ffe264a7 => 195
	i64 6251069312384999852, ; 143: System.Transactions.Local => 0x56c0426b870da1ac => 202
	i64 6278736998281604212, ; 144: System.Private.DataContractSerialization => 0x57228e08a4ad6c74 => 166
	i64 6284145129771520194, ; 145: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 170
	i64 6357457916754632952, ; 146: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 45
	i64 6401687960814735282, ; 147: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 103
	i64 6478287442656530074, ; 148: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 22
	i64 6504860066809920875, ; 149: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 93
	i64 6548213210057960872, ; 150: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 99
	i64 6560151584539558821, ; 151: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 59
	i64 6617685658146568858, ; 152: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 192
	i64 6667137106064718713, ; 153: ru/Microsoft.Data.SqlClient.resources.dll => 0x5c866ddfbbd03b79 => 8
	i64 6743165466166707109, ; 154: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 30
	i64 6765560235250500673, ; 155: StoresPlace-Business.dll => 0x5de41930409d4441 => 119
	i64 6777482997383978746, ; 156: pt/Microsoft.Maui.Controls.resources.dll => 0x5e0e74e0a2525efa => 33
	i64 6786606130239981554, ; 157: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 140
	i64 6814185388980153342, ; 158: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 206
	i64 6876862101832370452, ; 159: System.Xml.Linq => 0x5f6f85a57d108914 => 204
	i64 6894844156784520562, ; 160: System.Numerics.Vectors => 0x5faf683aead1ad72 => 164
	i64 7055072420069764613, ; 161: pt-BR/Microsoft.Data.SqlClient.resources.dll => 0x61e8a6fc96e9ee05 => 7
	i64 7083547580668757502, ; 162: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 168
	i64 7104805312999509849, ; 163: StoresPlace-Front.dll => 0x629956ca0fa4cf59 => 121
	i64 7220009545223068405, ; 164: sv/Microsoft.Maui.Controls.resources.dll => 0x6432a06d99f35af5 => 37
	i64 7270811800166795866, ; 165: System.Linq => 0x64e71ccf51a90a5a => 151
	i64 7316205155833392065, ; 166: Microsoft.Win32.Primitives => 0x658861d38954abc1 => 123
	i64 7348123982286201829, ; 167: System.Memory.Data.dll => 0x65f9c7d471b2a3e5 => 87
	i64 7363333649714591606, ; 168: StoresPlace-Front => 0x662fd0f119eb3776 => 121
	i64 7377312882064240630, ; 169: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 132
	i64 7488575175965059935, ; 170: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 204
	i64 7489048572193775167, ; 171: System.ObjectModel => 0x67ee71ff6b419e3f => 165
	i64 7496222613193209122, ; 172: System.IdentityModel.Tokens.Jwt => 0x6807eec000a1b522 => 86
	i64 7592577537120840276, ; 173: System.Diagnostics.Process => 0x695e410af5b2aa54 => 137
	i64 7654504624184590948, ; 174: System.Net.Http => 0x6a3a4366801b8264 => 153
	i64 7694700312542370399, ; 175: System.Net.Mail => 0x6ac9112a7e2cda5f => 154
	i64 7708790323521193081, ; 176: ms/Microsoft.Maui.Controls.resources.dll => 0x6afb1ff4d1730479 => 28
	i64 7714652370974252055, ; 177: System.Private.CoreLib => 0x6b0ff375198b9c17 => 210
	i64 7735176074855944702, ; 178: Microsoft.CSharp => 0x6b58dda848e391fe => 122
	i64 7735352534559001595, ; 179: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 117
	i64 7791074099216502080, ; 180: System.IO.FileSystem.AccessControl.dll => 0x6c1f749d468bcd40 => 147
	i64 7836164640616011524, ; 181: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 92
	i64 8064050204834738623, ; 182: System.Collections.dll => 0x6fe942efa61731bf => 129
	i64 8083354569033831015, ; 183: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 102
	i64 8087206902342787202, ; 184: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 136
	i64 8167236081217502503, ; 185: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 211
	i64 8185542183669246576, ; 186: System.Collections => 0x7198e33f4794aa70 => 129
	i64 8234598844743906698, ; 187: Microsoft.Identity.Client.Extensions.Msal.dll => 0x72472c0540cd758a => 62
	i64 8246048515196606205, ; 188: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 73
	i64 8264926008854159966, ; 189: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 137
	i64 8368701292315763008, ; 190: System.Security.Cryptography => 0x7423997c6fd56140 => 190
	i64 8400357532724379117, ; 191: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 110
	i64 8410671156615598628, ; 192: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 171
	i64 8513291706828295435, ; 193: Microsoft.SqlServer.Server => 0x762549b3b6c78d0b => 74
	i64 8518412311883997971, ; 194: System.Collections.Immutable => 0x76377add7c28e313 => 126
	i64 8563666267364444763, ; 195: System.Private.Uri => 0x76d841191140ca5b => 167
	i64 8599632406834268464, ; 196: CommunityToolkit.Maui => 0x7758081c784b4930 => 48
	i64 8614108721271900878, ; 197: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x778b763e14018ace => 32
	i64 8626175481042262068, ; 198: Java.Interop => 0x77b654e585b55834 => 211
	i64 8638972117149407195, ; 199: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 122
	i64 8639588376636138208, ; 200: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 109
	i64 8677882282824630478, ; 201: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 32
	i64 8725526185868997716, ; 202: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 136
	i64 8882398187484578781, ; 203: de/Microsoft.Data.SqlClient.resources.dll => 0x7b449e172e9783dd => 1
	i64 8941376889969657626, ; 204: System.Xml.XDocument => 0x7c1626e87187471a => 206
	i64 8954753533646919997, ; 205: System.Runtime.Serialization.Json => 0x7c45ace50032d93d => 178
	i64 8955323522379913726, ; 206: Microsoft.Identity.Client => 0x7c47b34bd82799fe => 61
	i64 9045785047181495996, ; 207: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 42
	i64 9052662452269567435, ; 208: Microsoft.IdentityModel.Protocols => 0x7da184898b0b4dcb => 66
	i64 9138683372487561558, ; 209: System.Security.Cryptography.Csp => 0x7ed3201bc3e3d156 => 186
	i64 9142599542861431285, ; 210: ar\StoresPlace-Front.resources => 0x7ee109d83be781f5 => 0
	i64 9153910511549984549, ; 211: SendGrid.dll => 0x7f09391c5aa6af25 => 77
	i64 9312692141327339315, ; 212: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 115
	i64 9324707631942237306, ; 213: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 91
	i64 9389258210823261255, ; 214: it/Microsoft.Data.SqlClient.resources.dll => 0x824d5898a88a4c47 => 4
	i64 9427266486299436557, ; 215: Microsoft.IdentityModel.Logging.dll => 0x82d460ebe6d2a60d => 65
	i64 9513793942805897923, ; 216: zh-Hans\Microsoft.Data.SqlClient.resources => 0x8407c92f4b3562c3 => 9
	i64 9632394721105987142, ; 217: StoresPlace-DataAccess.dll => 0x85ad23f6d7dec646 => 120
	i64 9659729154652888475, ; 218: System.Text.RegularExpressions => 0x860e407c9991dd9b => 196
	i64 9667360217193089419, ; 219: System.Diagnostics.StackTrace => 0x86295ce5cd89898b => 138
	i64 9678050649315576968, ; 220: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 96
	i64 9702891218465930390, ; 221: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 127
	i64 9769375692094236398, ; 222: StoresPlace-DataAccess => 0x8793cb6e7c9ce6ee => 120
	i64 9808709177481450983, ; 223: Mono.Android.dll => 0x881f890734e555e7 => 213
	i64 9819168441846169364, ; 224: Microsoft.IdentityModel.Protocols.dll => 0x8844b1ac75f77f14 => 66
	i64 9956195530459977388, ; 225: Microsoft.Maui => 0x8a2b8315b36616ac => 71
	i64 9991543690424095600, ; 226: es/Microsoft.Maui.Controls.resources.dll => 0x8aa9180c89861370 => 17
	i64 10038780035334861115, ; 227: System.Net.Http.dll => 0x8b50e941206af13b => 153
	i64 10051358222726253779, ; 228: System.Private.Xml => 0x8b7d990c97ccccd3 => 169
	i64 10089571585547156312, ; 229: System.IO.FileSystem.AccessControl => 0x8c055be67469bb58 => 147
	i64 10092835686693276772, ; 230: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 69
	i64 10143853363526200146, ; 231: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 14
	i64 10229024438826829339, ; 232: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 99
	i64 10236703004850800690, ; 233: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 160
	i64 10245369515835430794, ; 234: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 171
	i64 10364469296367737616, ; 235: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 170
	i64 10406448008575299332, ; 236: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 118
	i64 10430153318873392755, ; 237: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 97
	i64 10447083246144586668, ; 238: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 50
	i64 10506226065143327199, ; 239: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 12
	i64 10546663366131771576, ; 240: System.Runtime.Serialization.Json.dll => 0x925d4673efe8e8b8 => 178
	i64 10670374202010151210, ; 241: Microsoft.Win32.Primitives.dll => 0x9414c8cd7b4ea92a => 123
	i64 10785150219063592792, ; 242: System.Net.Primitives => 0x95ac8cfb68830758 => 157
	i64 10880838204485145808, ; 243: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 48
	i64 10889380495983713167, ; 244: Microsoft.Data.SqlClient.dll => 0x971ed9dddf2d1b8f => 51
	i64 10964653383833615866, ; 245: System.Diagnostics.Tracing => 0x982a4628ccaffdfa => 141
	i64 11002576679268595294, ; 246: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 58
	i64 11009005086950030778, ; 247: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 71
	i64 11038974641380222378, ; 248: zh-Hant/Microsoft.Data.SqlClient.resources.dll => 0x993250f3080365aa => 10
	i64 11103970607964515343, ; 249: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 23
	i64 11162124722117608902, ; 250: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 114
	i64 11183417087873056340, ; 251: ko\Microsoft.Data.SqlClient.resources => 0x9b337a96d1b4fe54 => 6
	i64 11220793807500858938, ; 252: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 26
	i64 11226290749488709958, ; 253: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 59
	i64 11340910727871153756, ; 254: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 98
	i64 11341245327015630248, ; 255: System.Configuration.ConfigurationManager.dll => 0x9d643289535355a8 => 84
	i64 11347436699239206956, ; 256: System.Xml.XmlSerializer.dll => 0x9d7a318e8162502c => 207
	i64 11369118378396596751, ; 257: de\Microsoft.Data.SqlClient.resources => 0x9dc738edd1b1ba0f => 1
	i64 11448276831755070604, ; 258: System.Diagnostics.TextWriterTraceListener => 0x9ee0731f77186c8c => 139
	i64 11485890710487134646, ; 259: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 174
	i64 11517440453979132662, ; 260: Microsoft.IdentityModel.Abstractions.dll => 0x9fd62b122523d2f6 => 63
	i64 11518296021396496455, ; 261: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 24
	i64 11529969570048099689, ; 262: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 114
	i64 11530571088791430846, ; 263: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 57
	i64 11597940890313164233, ; 264: netstandard => 0xa0f429ca8d1805c9 => 209
	i64 11705530742807338875, ; 265: he/Microsoft.Maui.Controls.resources.dll => 0xa272663128721f7b => 20
	i64 11806871145320508000, ; 266: StarkbankEcdsa.dll => 0xa3da6ec04da36a60 => 82
	i64 12011556116648931059, ; 267: System.Security.Cryptography.ProtectedData => 0xa6b19ea5ec87aef3 => 89
	i64 12040886584167504988, ; 268: System.Net.ServicePoint => 0xa719d28d8e121c5c => 160
	i64 12094367927612810875, ; 269: it\Microsoft.Data.SqlClient.resources => 0xa7d7d38d2c3d267b => 4
	i64 12102847907131387746, ; 270: System.Buffers => 0xa7f5f40c43256f62 => 124
	i64 12145679461940342714, ; 271: System.Text.Json => 0xa88e1f1ebcb62fba => 195
	i64 12198439281774268251, ; 272: Microsoft.IdentityModel.Protocols.OpenIdConnect.dll => 0xa9498fe58c538f5b => 67
	i64 12201331334810686224, ; 273: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 179
	i64 12269460666702402136, ; 274: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 126
	i64 12279246230491828964, ; 275: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 81
	i64 12341818387765915815, ; 276: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 49
	i64 12439275739440478309, ; 277: Microsoft.IdentityModel.JsonWebTokens => 0xaca12f61007bf865 => 64
	i64 12451044538927396471, ; 278: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 101
	i64 12466513435562512481, ; 279: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 106
	i64 12475113361194491050, ; 280: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 45
	i64 12493213219680520345, ; 281: Microsoft.Data.SqlClient => 0xad60cf3b3e458899 => 51
	i64 12517810545449516888, ; 282: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 140
	i64 12538491095302438457, ; 283: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 94
	i64 12550732019250633519, ; 284: System.IO.Compression => 0xae2d28465e8e1b2f => 146
	i64 12681088699309157496, ; 285: it/Microsoft.Maui.Controls.resources.dll => 0xaffc46fc178aec78 => 25
	i64 12699999919562409296, ; 286: System.Diagnostics.StackTrace.dll => 0xb03f76a3ad01c550 => 138
	i64 12700543734426720211, ; 287: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 95
	i64 12708922737231849740, ; 288: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 193
	i64 12717050818822477433, ; 289: System.Runtime.Serialization.Xml.dll => 0xb07c0a5786811679 => 180
	i64 12823819093633476069, ; 290: th/Microsoft.Maui.Controls.resources.dll => 0xb1f75b85abe525e5 => 38
	i64 12835242264250840079, ; 291: System.IO.Pipes => 0xb21ff0d5d6c0740f => 149
	i64 12843321153144804894, ; 292: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 60
	i64 12859557719246324186, ; 293: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 163
	i64 12948205494791172641, ; 294: ar/StoresPlace-Front.resources.dll => 0xb3b1444b83c9f221 => 0
	i64 13068258254871114833, ; 295: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 177
	i64 13221551921002590604, ; 296: ca/Microsoft.Maui.Controls.resources.dll => 0xb77c636bdebe318c => 12
	i64 13222659110913276082, ; 297: ja/Microsoft.Maui.Controls.resources.dll => 0xb78052679c1178b2 => 26
	i64 13343850469010654401, ; 298: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 212
	i64 13381594904270902445, ; 299: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 20
	i64 13431476299110033919, ; 300: System.Net.WebClient => 0xba663087f18829ff => 162
	i64 13463706743370286408, ; 301: System.Private.DataContractSerialization.dll => 0xbad8b1f3069e0548 => 166
	i64 13465488254036897740, ; 302: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 117
	i64 13467053111158216594, ; 303: uk/Microsoft.Maui.Controls.resources.dll => 0xbae49573fde79792 => 40
	i64 13540124433173649601, ; 304: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 41
	i64 13545416393490209236, ; 305: id/Microsoft.Maui.Controls.resources.dll => 0xbbfafc7174bc99d4 => 24
	i64 13572454107664307259, ; 306: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 111
	i64 13595456055014782591, ; 307: SendGrid => 0xbcacc3400e96f67f => 77
	i64 13710614125866346983, ; 308: System.Security.AccessControl.dll => 0xbe45e2e7d0b769e7 => 182
	i64 13717397318615465333, ; 309: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 131
	i64 13742054908850494594, ; 310: Azure.Identity => 0xbeb596218df25c82 => 47
	i64 13755568601956062840, ; 311: fr/Microsoft.Maui.Controls.resources.dll => 0xbee598c36b1b9678 => 19
	i64 13814445057219246765, ; 312: hr/Microsoft.Maui.Controls.resources.dll => 0xbfb6c49664b43aad => 22
	i64 13881769479078963060, ; 313: System.Console.dll => 0xc0a5f3cade5c6774 => 134
	i64 13959074834287824816, ; 314: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 101
	i64 14100563506285742564, ; 315: da/Microsoft.Maui.Controls.resources.dll => 0xc3af43cd0cff89e4 => 14
	i64 14124974489674258913, ; 316: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 94
	i64 14125464355221830302, ; 317: System.Threading.dll => 0xc407bafdbc707a9e => 201
	i64 14212104595480609394, ; 318: System.Security.Cryptography.Cng.dll => 0xc53b89d4a4518272 => 185
	i64 14254574811015963973, ; 319: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 193
	i64 14327709162229390963, ; 320: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 189
	i64 14438260825521943376, ; 321: RestSharp.dll => 0xc85f01b93fac7350 => 76
	i64 14461014870687870182, ; 322: System.Net.Requests.dll => 0xc8afd8683afdece6 => 158
	i64 14464374589798375073, ; 323: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 35
	i64 14522721392235705434, ; 324: el/Microsoft.Maui.Controls.resources.dll => 0xc98b12295c2cf45a => 16
	i64 14533141687369379279, ; 325: zh-Hant\Microsoft.Data.SqlClient.resources => 0xc9b0175d6212adcf => 10
	i64 14551742072151931844, ; 326: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 194
	i64 14556034074661724008, ; 327: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 49
	i64 14561513370130550166, ; 328: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 188
	i64 14622043554576106986, ; 329: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 177
	i64 14648804764802849406, ; 330: Azure.Identity.dll => 0xcb4b0252261f9a7e => 47
	i64 14669215534098758659, ; 331: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 55
	i64 14690985099581930927, ; 332: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 203
	i64 14705122255218365489, ; 333: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 27
	i64 14744092281598614090, ; 334: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 43
	i64 14832630590065248058, ; 335: System.Security.Claims => 0xcdd816ef5d6e873a => 183
	i64 14852515768018889994, ; 336: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 98
	i64 14892012299694389861, ; 337: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xceab0e490a083a65 => 44
	i64 14904040806490515477, ; 338: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 11
	i64 14912225920358050525, ; 339: System.Security.Principal.Windows => 0xcef2de7759506add => 191
	i64 14921072373058723558, ; 340: ko/Microsoft.Data.SqlClient.resources.dll => 0xcf124c44a00f5ee6 => 6
	i64 14935719434541007538, ; 341: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 192
	i64 14954917835170835695, ; 342: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 56
	i64 14984936317414011727, ; 343: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 163
	i64 14987728460634540364, ; 344: System.IO.Compression.dll => 0xcfff1ba06622494c => 146
	i64 15015154896917945444, ; 345: System.Net.Security.dll => 0xd0608bd33642dc64 => 159
	i64 15076659072870671916, ; 346: System.ObjectModel.dll => 0xd13b0d8c1620662c => 165
	i64 15111608613780139878, ; 347: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 28
	i64 15115185479366240210, ; 348: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 145
	i64 15133485256822086103, ; 349: System.Linq.dll => 0xd204f0a9127dd9d7 => 151
	i64 15138356091203993725, ; 350: Microsoft.IdentityModel.Abstractions => 0xd2163ea89395c07d => 63
	i64 15227001540531775957, ; 351: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 54
	i64 15370334346939861994, ; 352: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 97
	i64 15383240894167415497, ; 353: System.Memory.Data => 0xd57c4016df1c7ac9 => 87
	i64 15391712275433856905, ; 354: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 56
	i64 15440042012048828209, ; 355: pt-BR\Microsoft.Data.SqlClient.resources => 0xd6460c67b5472731 => 7
	i64 15475196252089753159, ; 356: System.Diagnostics.EventLog => 0xd6c2f1000b441e47 => 85
	i64 15527772828719725935, ; 357: System.Console => 0xd77dbb1e38cd3d6f => 134
	i64 15536481058354060254, ; 358: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 15
	i64 15541854775306130054, ; 359: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 189
	i64 15557562860424774966, ; 360: System.Net.Sockets => 0xd7e790fe7a6dc536 => 161
	i64 15582737692548360875, ; 361: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 105
	i64 15609085926864131306, ; 362: System.dll => 0xd89e9cf3334914ea => 208
	i64 15661133872274321916, ; 363: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 205
	i64 15664356999916475676, ; 364: de/Microsoft.Maui.Controls.resources.dll => 0xd962f9b2b6ecd51c => 15
	i64 15718684508147848364, ; 365: es/Microsoft.Data.SqlClient.resources.dll => 0xda23fc476c9694ac => 2
	i64 15743187114543869802, ; 366: hu/Microsoft.Maui.Controls.resources.dll => 0xda7b09450ae4ef6a => 23
	i64 15783653065526199428, ; 367: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 16
	i64 15847085070278954535, ; 368: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 197
	i64 15937190497610202713, ; 369: System.Security.Cryptography.Cng => 0xdd2c465197c97e59 => 185
	i64 15963349826457351533, ; 370: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 198
	i64 16018552496348375205, ; 371: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 156
	i64 16154507427712707110, ; 372: System => 0xe03056ea4e39aa26 => 208
	i64 16219561732052121626, ; 373: System.Net.Security => 0xe1177575db7c781a => 159
	i64 16288847719894691167, ; 374: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 29
	i64 16321164108206115771, ; 375: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 58
	i64 16337011941688632206, ; 376: System.Security.Principal.Windows.dll => 0xe2b8b9cdc3aa638e => 191
	i64 16454459195343277943, ; 377: System.Net.NetworkInformation => 0xe459fb756d988f77 => 156
	i64 16540916324946374984, ; 378: fr\Microsoft.Data.SqlClient.resources => 0xe58d23c28fe37148 => 3
	i64 16593842024386336260, ; 379: StoresPlace-Business => 0xe6492b673a7f1604 => 119
	i64 16649148416072044166, ; 380: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 73
	i64 16677317093839702854, ; 381: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 110
	i64 16755018182064898362, ; 382: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 79
	i64 16765015072123548030, ; 383: System.Diagnostics.TextWriterTraceListener.dll => 0xe8a94c621bfe717e => 139
	i64 16856067890322379635, ; 384: System.Data.Common.dll => 0xe9ecc87060889373 => 135
	i64 16890310621557459193, ; 385: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 196
	i64 16942731696432749159, ; 386: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 36
	i64 16945858842201062480, ; 387: Azure.Core => 0xeb2bc8d57f4e7c50 => 46
	i64 16998075588627545693, ; 388: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 108
	i64 17006954551347072385, ; 389: System.ClientModel => 0xec04d70ec8414d81 => 83
	i64 17008137082415910100, ; 390: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 127
	i64 17031351772568316411, ; 391: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 107
	i64 17062143951396181894, ; 392: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 131
	i64 17089008752050867324, ; 393: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xed285aeb25888c7c => 43
	i64 17118171214553292978, ; 394: System.Threading.Channels => 0xed8ff6060fc420b2 => 197
	i64 17137864900836977098, ; 395: Microsoft.IdentityModel.Tokens => 0xedd5ed53b705e9ca => 68
	i64 17151170952569239713, ; 396: RestSharp => 0xee05331c4de338a1 => 76
	i64 17197986060146327831, ; 397: Microsoft.Identity.Client.Extensions.Msal => 0xeeab8533ef244117 => 62
	i64 17201328579425343169, ; 398: System.ComponentModel.EventBasedAsync => 0xeeb76534d96c16c1 => 130
	i64 17202182880784296190, ; 399: System.Security.Cryptography.Encoding.dll => 0xeeba6e30627428fe => 187
	i64 17230721278011714856, ; 400: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 168
	i64 17234219099804750107, ; 401: System.Transactions.Local.dll => 0xef2c3ef5e11d511b => 202
	i64 17260702271250283638, ; 402: System.Data.Common => 0xef8a5543bba6bc76 => 135
	i64 17333249706306540043, ; 403: System.Diagnostics.Tracing.dll => 0xf08c12c5bb8b920b => 141
	i64 17342750010158924305, ; 404: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 21
	i64 17371436720558481852, ; 405: System.Runtime.Caching => 0xf113bda8d710a1bc => 88
	i64 17438153253682247751, ; 406: sk/Microsoft.Maui.Controls.resources.dll => 0xf200c3fe308d7847 => 36
	i64 17514990004910432069, ; 407: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 19
	i64 17523946658117960076, ; 408: System.Security.Cryptography.ProtectedData.dll => 0xf33190a3c403c18c => 89
	i64 17558788868712318792, ; 409: es\Microsoft.Data.SqlClient.resources => 0xf3ad597215ae4748 => 2
	i64 17623389608345532001, ; 410: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 31
	i64 17702523067201099846, ; 411: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xf5abfef008ae1846 => 42
	i64 17704177640604968747, ; 412: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 106
	i64 17710060891934109755, ; 413: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 104
	i64 17712670374920797664, ; 414: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 174
	i64 17777860260071588075, ; 415: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 176
	i64 17790600151040787804, ; 416: Microsoft.IdentityModel.Logging => 0xf6e4e89427cc055c => 65
	i64 17838668724098252521, ; 417: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 124
	i64 18025913125965088385, ; 418: System.Threading => 0xfa28e87b91334681 => 201
	i64 18099568558057551825, ; 419: nl/Microsoft.Maui.Controls.resources.dll => 0xfb2e95b53ad977d1 => 30
	i64 18121036031235206392, ; 420: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 107
	i64 18146411883821974900, ; 421: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 144
	i64 18146811631844267958, ; 422: System.ComponentModel.EventBasedAsync.dll => 0xfbd66d08820117b6 => 130
	i64 18225059387460068507, ; 423: System.Threading.ThreadPool.dll => 0xfcec6af3cff4a49b => 200
	i64 18245806341561545090, ; 424: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 125
	i64 18305135509493619199, ; 425: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 109
	i64 18324163916253801303, ; 426: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 25
	i64 18370042311372477656 ; 427: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 80
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [428 x i32] [
	i32 60, ; 0
	i32 213, ; 1
	i32 72, ; 2
	i32 150, ; 3
	i32 95, ; 4
	i32 112, ; 5
	i32 18, ; 6
	i32 172, ; 7
	i32 61, ; 8
	i32 199, ; 9
	i32 5, ; 10
	i32 133, ; 11
	i32 21, ; 12
	i32 80, ; 13
	i32 100, ; 14
	i32 74, ; 15
	i32 172, ; 16
	i32 46, ; 17
	i32 116, ; 18
	i32 29, ; 19
	i32 8, ; 20
	i32 143, ; 21
	i32 79, ; 22
	i32 108, ; 23
	i32 148, ; 24
	i32 157, ; 25
	i32 69, ; 26
	i32 212, ; 27
	i32 81, ; 28
	i32 199, ; 29
	i32 27, ; 30
	i32 92, ; 31
	i32 105, ; 32
	i32 52, ; 33
	i32 75, ; 34
	i32 154, ; 35
	i32 152, ; 36
	i32 167, ; 37
	i32 91, ; 38
	i32 173, ; 39
	i32 17, ; 40
	i32 112, ; 41
	i32 50, ; 42
	i32 142, ; 43
	i32 39, ; 44
	i32 70, ; 45
	i32 39, ; 46
	i32 184, ; 47
	i32 104, ; 48
	i32 13, ; 49
	i32 31, ; 50
	i32 198, ; 51
	i32 142, ; 52
	i32 75, ; 53
	i32 93, ; 54
	i32 100, ; 55
	i32 125, ; 56
	i32 35, ; 57
	i32 67, ; 58
	i32 103, ; 59
	i32 194, ; 60
	i32 96, ; 61
	i32 181, ; 62
	i32 90, ; 63
	i32 88, ; 64
	i32 38, ; 65
	i32 68, ; 66
	i32 155, ; 67
	i32 55, ; 68
	i32 13, ; 69
	i32 64, ; 70
	i32 182, ; 71
	i32 84, ; 72
	i32 18, ; 73
	i32 5, ; 74
	i32 116, ; 75
	i32 83, ; 76
	i32 180, ; 77
	i32 186, ; 78
	i32 102, ; 79
	i32 164, ; 80
	i32 176, ; 81
	i32 161, ; 82
	i32 118, ; 83
	i32 86, ; 84
	i32 72, ; 85
	i32 53, ; 86
	i32 113, ; 87
	i32 210, ; 88
	i32 33, ; 89
	i32 181, ; 90
	i32 82, ; 91
	i32 54, ; 92
	i32 205, ; 93
	i32 53, ; 94
	i32 209, ; 95
	i32 111, ; 96
	i32 57, ; 97
	i32 70, ; 98
	i32 187, ; 99
	i32 158, ; 100
	i32 152, ; 101
	i32 179, ; 102
	i32 169, ; 103
	i32 3, ; 104
	i32 44, ; 105
	i32 133, ; 106
	i32 200, ; 107
	i32 183, ; 108
	i32 150, ; 109
	i32 132, ; 110
	i32 85, ; 111
	i32 78, ; 112
	i32 9, ; 113
	i32 41, ; 114
	i32 149, ; 115
	i32 203, ; 116
	i32 148, ; 117
	i32 11, ; 118
	i32 207, ; 119
	i32 90, ; 120
	i32 113, ; 121
	i32 143, ; 122
	i32 155, ; 123
	i32 175, ; 124
	i32 128, ; 125
	i32 52, ; 126
	i32 128, ; 127
	i32 162, ; 128
	i32 175, ; 129
	i32 173, ; 130
	i32 37, ; 131
	i32 40, ; 132
	i32 145, ; 133
	i32 190, ; 134
	i32 184, ; 135
	i32 115, ; 136
	i32 144, ; 137
	i32 188, ; 138
	i32 34, ; 139
	i32 78, ; 140
	i32 34, ; 141
	i32 195, ; 142
	i32 202, ; 143
	i32 166, ; 144
	i32 170, ; 145
	i32 45, ; 146
	i32 103, ; 147
	i32 22, ; 148
	i32 93, ; 149
	i32 99, ; 150
	i32 59, ; 151
	i32 192, ; 152
	i32 8, ; 153
	i32 30, ; 154
	i32 119, ; 155
	i32 33, ; 156
	i32 140, ; 157
	i32 206, ; 158
	i32 204, ; 159
	i32 164, ; 160
	i32 7, ; 161
	i32 168, ; 162
	i32 121, ; 163
	i32 37, ; 164
	i32 151, ; 165
	i32 123, ; 166
	i32 87, ; 167
	i32 121, ; 168
	i32 132, ; 169
	i32 204, ; 170
	i32 165, ; 171
	i32 86, ; 172
	i32 137, ; 173
	i32 153, ; 174
	i32 154, ; 175
	i32 28, ; 176
	i32 210, ; 177
	i32 122, ; 178
	i32 117, ; 179
	i32 147, ; 180
	i32 92, ; 181
	i32 129, ; 182
	i32 102, ; 183
	i32 136, ; 184
	i32 211, ; 185
	i32 129, ; 186
	i32 62, ; 187
	i32 73, ; 188
	i32 137, ; 189
	i32 190, ; 190
	i32 110, ; 191
	i32 171, ; 192
	i32 74, ; 193
	i32 126, ; 194
	i32 167, ; 195
	i32 48, ; 196
	i32 32, ; 197
	i32 211, ; 198
	i32 122, ; 199
	i32 109, ; 200
	i32 32, ; 201
	i32 136, ; 202
	i32 1, ; 203
	i32 206, ; 204
	i32 178, ; 205
	i32 61, ; 206
	i32 42, ; 207
	i32 66, ; 208
	i32 186, ; 209
	i32 0, ; 210
	i32 77, ; 211
	i32 115, ; 212
	i32 91, ; 213
	i32 4, ; 214
	i32 65, ; 215
	i32 9, ; 216
	i32 120, ; 217
	i32 196, ; 218
	i32 138, ; 219
	i32 96, ; 220
	i32 127, ; 221
	i32 120, ; 222
	i32 213, ; 223
	i32 66, ; 224
	i32 71, ; 225
	i32 17, ; 226
	i32 153, ; 227
	i32 169, ; 228
	i32 147, ; 229
	i32 69, ; 230
	i32 14, ; 231
	i32 99, ; 232
	i32 160, ; 233
	i32 171, ; 234
	i32 170, ; 235
	i32 118, ; 236
	i32 97, ; 237
	i32 50, ; 238
	i32 12, ; 239
	i32 178, ; 240
	i32 123, ; 241
	i32 157, ; 242
	i32 48, ; 243
	i32 51, ; 244
	i32 141, ; 245
	i32 58, ; 246
	i32 71, ; 247
	i32 10, ; 248
	i32 23, ; 249
	i32 114, ; 250
	i32 6, ; 251
	i32 26, ; 252
	i32 59, ; 253
	i32 98, ; 254
	i32 84, ; 255
	i32 207, ; 256
	i32 1, ; 257
	i32 139, ; 258
	i32 174, ; 259
	i32 63, ; 260
	i32 24, ; 261
	i32 114, ; 262
	i32 57, ; 263
	i32 209, ; 264
	i32 20, ; 265
	i32 82, ; 266
	i32 89, ; 267
	i32 160, ; 268
	i32 4, ; 269
	i32 124, ; 270
	i32 195, ; 271
	i32 67, ; 272
	i32 179, ; 273
	i32 126, ; 274
	i32 81, ; 275
	i32 49, ; 276
	i32 64, ; 277
	i32 101, ; 278
	i32 106, ; 279
	i32 45, ; 280
	i32 51, ; 281
	i32 140, ; 282
	i32 94, ; 283
	i32 146, ; 284
	i32 25, ; 285
	i32 138, ; 286
	i32 95, ; 287
	i32 193, ; 288
	i32 180, ; 289
	i32 38, ; 290
	i32 149, ; 291
	i32 60, ; 292
	i32 163, ; 293
	i32 0, ; 294
	i32 177, ; 295
	i32 12, ; 296
	i32 26, ; 297
	i32 212, ; 298
	i32 20, ; 299
	i32 162, ; 300
	i32 166, ; 301
	i32 117, ; 302
	i32 40, ; 303
	i32 41, ; 304
	i32 24, ; 305
	i32 111, ; 306
	i32 77, ; 307
	i32 182, ; 308
	i32 131, ; 309
	i32 47, ; 310
	i32 19, ; 311
	i32 22, ; 312
	i32 134, ; 313
	i32 101, ; 314
	i32 14, ; 315
	i32 94, ; 316
	i32 201, ; 317
	i32 185, ; 318
	i32 193, ; 319
	i32 189, ; 320
	i32 76, ; 321
	i32 158, ; 322
	i32 35, ; 323
	i32 16, ; 324
	i32 10, ; 325
	i32 194, ; 326
	i32 49, ; 327
	i32 188, ; 328
	i32 177, ; 329
	i32 47, ; 330
	i32 55, ; 331
	i32 203, ; 332
	i32 27, ; 333
	i32 43, ; 334
	i32 183, ; 335
	i32 98, ; 336
	i32 44, ; 337
	i32 11, ; 338
	i32 191, ; 339
	i32 6, ; 340
	i32 192, ; 341
	i32 56, ; 342
	i32 163, ; 343
	i32 146, ; 344
	i32 159, ; 345
	i32 165, ; 346
	i32 28, ; 347
	i32 145, ; 348
	i32 151, ; 349
	i32 63, ; 350
	i32 54, ; 351
	i32 97, ; 352
	i32 87, ; 353
	i32 56, ; 354
	i32 7, ; 355
	i32 85, ; 356
	i32 134, ; 357
	i32 15, ; 358
	i32 189, ; 359
	i32 161, ; 360
	i32 105, ; 361
	i32 208, ; 362
	i32 205, ; 363
	i32 15, ; 364
	i32 2, ; 365
	i32 23, ; 366
	i32 16, ; 367
	i32 197, ; 368
	i32 185, ; 369
	i32 198, ; 370
	i32 156, ; 371
	i32 208, ; 372
	i32 159, ; 373
	i32 29, ; 374
	i32 58, ; 375
	i32 191, ; 376
	i32 156, ; 377
	i32 3, ; 378
	i32 119, ; 379
	i32 73, ; 380
	i32 110, ; 381
	i32 79, ; 382
	i32 139, ; 383
	i32 135, ; 384
	i32 196, ; 385
	i32 36, ; 386
	i32 46, ; 387
	i32 108, ; 388
	i32 83, ; 389
	i32 127, ; 390
	i32 107, ; 391
	i32 131, ; 392
	i32 43, ; 393
	i32 197, ; 394
	i32 68, ; 395
	i32 76, ; 396
	i32 62, ; 397
	i32 130, ; 398
	i32 187, ; 399
	i32 168, ; 400
	i32 202, ; 401
	i32 135, ; 402
	i32 141, ; 403
	i32 21, ; 404
	i32 88, ; 405
	i32 36, ; 406
	i32 19, ; 407
	i32 89, ; 408
	i32 2, ; 409
	i32 31, ; 410
	i32 42, ; 411
	i32 106, ; 412
	i32 104, ; 413
	i32 174, ; 414
	i32 176, ; 415
	i32 65, ; 416
	i32 124, ; 417
	i32 201, ; 418
	i32 30, ; 419
	i32 107, ; 420
	i32 144, ; 421
	i32 130, ; 422
	i32 200, ; 423
	i32 125, ; 424
	i32 109, ; 425
	i32 25, ; 426
	i32 80 ; 427
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

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
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ df9aaf29a52042a4fbf800daf2f3a38964b9e958"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
