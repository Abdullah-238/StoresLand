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

@assembly_image_cache = dso_local local_unnamed_addr global [151 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [302 x i64] [
	i64 98382396393917666, ; 0: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 46
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 150
	i64 131669012237370309, ; 2: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 50
	i64 196720943101637631, ; 3: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 109
	i64 210515253464952879, ; 4: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 64
	i64 232391251801502327, ; 5: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 81
	i64 545109961164950392, ; 6: fi/Microsoft.Maui.Controls.resources.dll => 0x7909e9f1ec38b78 => 8
	i64 750875890346172408, ; 7: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 141
	i64 799765834175365804, ; 8: System.ComponentModel.dll => 0xb1956c9f18442ac => 99
	i64 849051935479314978, ; 9: hi/Microsoft.Maui.Controls.resources.dll => 0xbc8703ca21a3a22 => 11
	i64 870603111519317375, ; 10: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 56
	i64 872800313462103108, ; 11: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 69
	i64 1120440138749646132, ; 12: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 85
	i64 1121665720830085036, ; 13: nb/Microsoft.Maui.Controls.resources.dll => 0xf90f507becf47ac => 19
	i64 1268860745194512059, ; 14: System.Drawing.dll => 0x119be62002c19ebb => 105
	i64 1301485588176585670, ; 15: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 55
	i64 1369545283391376210, ; 16: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 77
	i64 1476839205573959279, ; 17: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 117
	i64 1486715745332614827, ; 18: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 47
	i64 1513467482682125403, ; 19: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 149
	i64 1518315023656898250, ; 20: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 57
	i64 1537168428375924959, ; 21: System.Threading.Thread.dll => 0x15551e8a954ae0df => 141
	i64 1556147632182429976, ; 22: ko/Microsoft.Maui.Controls.resources.dll => 0x15988c06d24c8918 => 17
	i64 1624659445732251991, ; 23: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 61
	i64 1628611045998245443, ; 24: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 74
	i64 1672383392659050004, ; 25: Microsoft.Data.Sqlite.dll => 0x17357fd5bfb48e14 => 38
	i64 1731380447121279447, ; 26: Newtonsoft.Json => 0x18071957e9b889d7 => 52
	i64 1735388228521408345, ; 27: System.Net.Mail.dll => 0x181556663c69b759 => 114
	i64 1743969030606105336, ; 28: System.Memory.dll => 0x1833d297e88f2af8 => 111
	i64 1767386781656293639, ; 29: System.Private.Uri.dll => 0x188704e9f5582107 => 126
	i64 1795316252682057001, ; 30: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 60
	i64 1825687700144851180, ; 31: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 129
	i64 1835311033149317475, ; 32: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 7
	i64 1836611346387731153, ; 33: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 81
	i64 1875417405349196092, ; 34: System.Drawing.Primitives => 0x1a06d2319b6c713c => 104
	i64 1881198190668717030, ; 35: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 29
	i64 1920760634179481754, ; 36: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 48
	i64 1959996714666907089, ; 37: tr/Microsoft.Maui.Controls.resources.dll => 0x1b334ea0a2a755d1 => 29
	i64 1981742497975770890, ; 38: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 73
	i64 1983698669889758782, ; 39: cs/Microsoft.Maui.Controls.resources.dll => 0x1b87836e2031a63e => 3
	i64 2019660174692588140, ; 40: pl/Microsoft.Maui.Controls.resources.dll => 0x1c07463a6f8e1a6c => 21
	i64 2102659300918482391, ; 41: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 104
	i64 2133195048986300728, ; 42: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 52
	i64 2165725771938924357, ; 43: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 62
	i64 2262844636196693701, ; 44: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 69
	i64 2287834202362508563, ; 45: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 91
	i64 2302323944321350744, ; 46: ru/Microsoft.Maui.Controls.resources.dll => 0x1ff37f6ddb267c58 => 25
	i64 2329709569556905518, ; 47: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 72
	i64 2335503487726329082, ; 48: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 137
	i64 2470498323731680442, ; 49: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 65
	i64 2497223385847772520, ; 50: System.Runtime => 0x22a7eb7046413568 => 135
	i64 2547086958574651984, ; 51: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 59
	i64 2602673633151553063, ; 52: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 28
	i64 2632269733008246987, ; 53: System.Net.NameResolution => 0x2487b36034f808cb => 115
	i64 2656907746661064104, ; 54: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 41
	i64 2662981627730767622, ; 55: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 3
	i64 2895129759130297543, ; 56: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 8
	i64 3017704767998173186, ; 57: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 85
	i64 3289520064315143713, ; 58: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 71
	i64 3311221304742556517, ; 59: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 124
	i64 3325875462027654285, ; 60: System.Runtime.Numerics => 0x2e27e21c8958b48d => 132
	i64 3328853167529574890, ; 61: System.Net.Sockets.dll => 0x2e327651a008c1ea => 121
	i64 3344514922410554693, ; 62: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 87
	i64 3429672777697402584, ; 63: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 50
	i64 3494946837667399002, ; 64: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 39
	i64 3522470458906976663, ; 65: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 82
	i64 3551103847008531295, ; 66: System.Private.CoreLib.dll => 0x31480e226177735f => 147
	i64 3567343442040498961, ; 67: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 23
	i64 3571415421602489686, ; 68: System.Runtime.dll => 0x319037675df7e556 => 135
	i64 3610052191230710096, ; 69: StarkbankEcdsa => 0x32197b574eed5150 => 58
	i64 3638003163729360188, ; 70: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 40
	i64 3647754201059316852, ; 71: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 144
	i64 3655542548057982301, ; 72: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 39
	i64 3716579019761409177, ; 73: netstandard.dll => 0x3393f0ed5c8c5c99 => 146
	i64 3727469159507183293, ; 74: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 80
	i64 3869221888984012293, ; 75: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 43
	i64 3890352374528606784, ; 76: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 48
	i64 3933965368022646939, ; 77: System.Net.Requests => 0x369840a8bfadc09b => 118
	i64 3966267475168208030, ; 78: System.Memory => 0x370b03412596249e => 111
	i64 4009997192427317104, ; 79: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 134
	i64 4073500526318903918, ; 80: System.Private.Xml.dll => 0x3887fb25779ae26e => 128
	i64 4120493066591692148, ; 81: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 34
	i64 4154383907710350974, ; 82: System.ComponentModel => 0x39a7562737acb67e => 99
	i64 4187479170553454871, ; 83: System.Linq.Expressions => 0x3a1cea1e912fa117 => 109
	i64 4205801962323029395, ; 84: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 98
	i64 4337444564132831293, ; 85: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 54
	i64 4356591372459378815, ; 86: vi/Microsoft.Maui.Controls.resources.dll => 0x3c75b8c562f9087f => 31
	i64 4679594760078841447, ; 87: ar/Microsoft.Maui.Controls.resources.dll => 0x40f142a407475667 => 1
	i64 4794310189461587505, ; 88: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 59
	i64 4795410492532947900, ; 89: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 82
	i64 4809057822547766521, ; 90: System.Drawing => 0x42bd349c3145ecf9 => 105
	i64 4814660307502931973, ; 91: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 115
	i64 4853321196694829351, ; 92: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 131
	i64 5103417709280584325, ; 93: System.Collections.Specialized => 0x46d2fb5e161b6285 => 94
	i64 5129462924058778861, ; 94: Microsoft.Data.Sqlite => 0x472f835a350f5ced => 38
	i64 5182934613077526976, ; 95: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 94
	i64 5278787618751394462, ; 96: System.Net.WebClient.dll => 0x4942055efc68329e => 122
	i64 5290786973231294105, ; 97: System.Runtime.Loader => 0x496ca6b869b72699 => 131
	i64 5423376490970181369, ; 98: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 129
	i64 5471532531798518949, ; 99: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 27
	i64 5522859530602327440, ; 100: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 30
	i64 5570799893513421663, ; 101: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 107
	i64 5573260873512690141, ; 102: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 136
	i64 5622817151934697161, ; 103: StoresLand-API.dll => 0x4e084268a20a8ec9 => 88
	i64 5692067934154308417, ; 104: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 84
	i64 5979151488806146654, ; 105: System.Formats.Asn1 => 0x52fa3699a489d25e => 106
	i64 6068057819846744445, ; 106: ro/Microsoft.Maui.Controls.resources.dll => 0x5436126fec7f197d => 24
	i64 6183170893902868313, ; 107: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 54
	i64 6200764641006662125, ; 108: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 24
	i64 6222399776351216807, ; 109: System.Text.Json.dll => 0x565a67a0ffe264a7 => 138
	i64 6357457916754632952, ; 110: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 35
	i64 6401687960814735282, ; 111: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 72
	i64 6478287442656530074, ; 112: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 12
	i64 6504860066809920875, ; 113: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 62
	i64 6548213210057960872, ; 114: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 68
	i64 6560151584539558821, ; 115: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 45
	i64 6743165466166707109, ; 116: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 20
	i64 6777482997383978746, ; 117: pt/Microsoft.Maui.Controls.resources.dll => 0x5e0e74e0a2525efa => 23
	i64 6786606130239981554, ; 118: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 103
	i64 6876862101832370452, ; 119: System.Xml.Linq => 0x5f6f85a57d108914 => 143
	i64 6894844156784520562, ; 120: System.Numerics.Vectors => 0x5faf683aead1ad72 => 124
	i64 7083547580668757502, ; 121: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 127
	i64 7104805312999509849, ; 122: StoresPlace-Front.dll => 0x629956ca0fa4cf59 => 89
	i64 7220009545223068405, ; 123: sv/Microsoft.Maui.Controls.resources.dll => 0x6432a06d99f35af5 => 27
	i64 7270811800166795866, ; 124: System.Linq => 0x64e71ccf51a90a5a => 110
	i64 7363333649714591606, ; 125: StoresPlace-Front => 0x662fd0f119eb3776 => 89
	i64 7377312882064240630, ; 126: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 98
	i64 7488575175965059935, ; 127: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 143
	i64 7489048572193775167, ; 128: System.ObjectModel => 0x67ee71ff6b419e3f => 125
	i64 7654504624184590948, ; 129: System.Net.Http => 0x6a3a4366801b8264 => 113
	i64 7694700312542370399, ; 130: System.Net.Mail => 0x6ac9112a7e2cda5f => 114
	i64 7708790323521193081, ; 131: ms/Microsoft.Maui.Controls.resources.dll => 0x6afb1ff4d1730479 => 18
	i64 7714652370974252055, ; 132: System.Private.CoreLib => 0x6b0ff375198b9c17 => 147
	i64 7735176074855944702, ; 133: Microsoft.CSharp => 0x6b58dda848e391fe => 90
	i64 7735352534559001595, ; 134: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 86
	i64 7836164640616011524, ; 135: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 61
	i64 8064050204834738623, ; 136: System.Collections.dll => 0x6fe942efa61731bf => 95
	i64 8083354569033831015, ; 137: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 71
	i64 8085230611270010360, ; 138: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 112
	i64 8087206902342787202, ; 139: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 102
	i64 8167236081217502503, ; 140: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 148
	i64 8185542183669246576, ; 141: System.Collections => 0x7198e33f4794aa70 => 95
	i64 8246048515196606205, ; 142: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 51
	i64 8368701292315763008, ; 143: System.Security.Cryptography => 0x7423997c6fd56140 => 136
	i64 8400357532724379117, ; 144: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 79
	i64 8518412311883997971, ; 145: System.Collections.Immutable => 0x76377add7c28e313 => 92
	i64 8563666267364444763, ; 146: System.Private.Uri => 0x76d841191140ca5b => 126
	i64 8599632406834268464, ; 147: CommunityToolkit.Maui => 0x7758081c784b4930 => 36
	i64 8614108721271900878, ; 148: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x778b763e14018ace => 22
	i64 8626175481042262068, ; 149: Java.Interop => 0x77b654e585b55834 => 148
	i64 8638972117149407195, ; 150: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 90
	i64 8639588376636138208, ; 151: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 78
	i64 8677882282824630478, ; 152: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 22
	i64 8725526185868997716, ; 153: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 102
	i64 9045785047181495996, ; 154: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 32
	i64 9142599542861431285, ; 155: ar\StoresPlace-Front.resources => 0x7ee109d83be781f5 => 0
	i64 9153910511549984549, ; 156: SendGrid.dll => 0x7f09391c5aa6af25 => 53
	i64 9312692141327339315, ; 157: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 84
	i64 9324707631942237306, ; 158: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 60
	i64 9659729154652888475, ; 159: System.Text.RegularExpressions => 0x860e407c9991dd9b => 139
	i64 9678050649315576968, ; 160: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 65
	i64 9702891218465930390, ; 161: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 93
	i64 9808709177481450983, ; 162: Mono.Android.dll => 0x881f890734e555e7 => 150
	i64 9956195530459977388, ; 163: Microsoft.Maui => 0x8a2b8315b36616ac => 49
	i64 9991543690424095600, ; 164: es/Microsoft.Maui.Controls.resources.dll => 0x8aa9180c89861370 => 7
	i64 10038780035334861115, ; 165: System.Net.Http.dll => 0x8b50e941206af13b => 113
	i64 10051358222726253779, ; 166: System.Private.Xml => 0x8b7d990c97ccccd3 => 128
	i64 10092835686693276772, ; 167: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 47
	i64 10143853363526200146, ; 168: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 4
	i64 10229024438826829339, ; 169: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 68
	i64 10236703004850800690, ; 170: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 120
	i64 10406448008575299332, ; 171: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 87
	i64 10430153318873392755, ; 172: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 66
	i64 10506226065143327199, ; 173: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 2
	i64 10785150219063592792, ; 174: System.Net.Primitives => 0x95ac8cfb68830758 => 117
	i64 10880838204485145808, ; 175: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 36
	i64 11002576679268595294, ; 176: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 44
	i64 11009005086950030778, ; 177: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 49
	i64 11103970607964515343, ; 178: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 13
	i64 11162124722117608902, ; 179: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 83
	i64 11220793807500858938, ; 180: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 16
	i64 11226290749488709958, ; 181: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 45
	i64 11340910727871153756, ; 182: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 67
	i64 11485890710487134646, ; 183: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 130
	i64 11518296021396496455, ; 184: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 14
	i64 11529969570048099689, ; 185: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 83
	i64 11530571088791430846, ; 186: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 43
	i64 11597940890313164233, ; 187: netstandard => 0xa0f429ca8d1805c9 => 146
	i64 11671273081730159081, ; 188: StoresLand-API => 0xa1f8b107e11ad1e9 => 88
	i64 11705530742807338875, ; 189: he/Microsoft.Maui.Controls.resources.dll => 0xa272663128721f7b => 10
	i64 11806871145320508000, ; 190: StarkbankEcdsa.dll => 0xa3da6ec04da36a60 => 58
	i64 12040886584167504988, ; 191: System.Net.ServicePoint => 0xa719d28d8e121c5c => 120
	i64 12145679461940342714, ; 192: System.Text.Json => 0xa88e1f1ebcb62fba => 138
	i64 12201331334810686224, ; 193: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 134
	i64 12269460666702402136, ; 194: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 92
	i64 12279246230491828964, ; 195: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 57
	i64 12341818387765915815, ; 196: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 37
	i64 12451044538927396471, ; 197: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 70
	i64 12466513435562512481, ; 198: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 75
	i64 12475113361194491050, ; 199: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 35
	i64 12517810545449516888, ; 200: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 103
	i64 12538491095302438457, ; 201: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 63
	i64 12550732019250633519, ; 202: System.IO.Compression => 0xae2d28465e8e1b2f => 108
	i64 12681088699309157496, ; 203: it/Microsoft.Maui.Controls.resources.dll => 0xaffc46fc178aec78 => 15
	i64 12700543734426720211, ; 204: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 64
	i64 12823819093633476069, ; 205: th/Microsoft.Maui.Controls.resources.dll => 0xb1f75b85abe525e5 => 28
	i64 12843321153144804894, ; 206: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 46
	i64 12859557719246324186, ; 207: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 123
	i64 12948205494791172641, ; 208: ar/StoresPlace-Front.resources.dll => 0xb3b1444b83c9f221 => 0
	i64 13068258254871114833, ; 209: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 133
	i64 13221551921002590604, ; 210: ca/Microsoft.Maui.Controls.resources.dll => 0xb77c636bdebe318c => 2
	i64 13222659110913276082, ; 211: ja/Microsoft.Maui.Controls.resources.dll => 0xb78052679c1178b2 => 16
	i64 13343850469010654401, ; 212: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 149
	i64 13381594904270902445, ; 213: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 10
	i64 13431476299110033919, ; 214: System.Net.WebClient => 0xba663087f18829ff => 122
	i64 13465488254036897740, ; 215: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 86
	i64 13467053111158216594, ; 216: uk/Microsoft.Maui.Controls.resources.dll => 0xbae49573fde79792 => 30
	i64 13540124433173649601, ; 217: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 31
	i64 13545416393490209236, ; 218: id/Microsoft.Maui.Controls.resources.dll => 0xbbfafc7174bc99d4 => 14
	i64 13572454107664307259, ; 219: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 80
	i64 13595456055014782591, ; 220: SendGrid => 0xbcacc3400e96f67f => 53
	i64 13717397318615465333, ; 221: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 97
	i64 13755568601956062840, ; 222: fr/Microsoft.Maui.Controls.resources.dll => 0xbee598c36b1b9678 => 9
	i64 13814445057219246765, ; 223: hr/Microsoft.Maui.Controls.resources.dll => 0xbfb6c49664b43aad => 12
	i64 13881769479078963060, ; 224: System.Console.dll => 0xc0a5f3cade5c6774 => 100
	i64 13959074834287824816, ; 225: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 70
	i64 14100563506285742564, ; 226: da/Microsoft.Maui.Controls.resources.dll => 0xc3af43cd0cff89e4 => 4
	i64 14124974489674258913, ; 227: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 63
	i64 14125464355221830302, ; 228: System.Threading.dll => 0xc407bafdbc707a9e => 142
	i64 14461014870687870182, ; 229: System.Net.Requests.dll => 0xc8afd8683afdece6 => 118
	i64 14464374589798375073, ; 230: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 25
	i64 14522721392235705434, ; 231: el/Microsoft.Maui.Controls.resources.dll => 0xc98b12295c2cf45a => 6
	i64 14551742072151931844, ; 232: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 137
	i64 14556034074661724008, ; 233: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 37
	i64 14622043554576106986, ; 234: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 133
	i64 14669215534098758659, ; 235: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 41
	i64 14705122255218365489, ; 236: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 17
	i64 14744092281598614090, ; 237: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 33
	i64 14852515768018889994, ; 238: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 67
	i64 14892012299694389861, ; 239: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xceab0e490a083a65 => 34
	i64 14904040806490515477, ; 240: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 1
	i64 14954917835170835695, ; 241: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 42
	i64 14984936317414011727, ; 242: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 123
	i64 14987728460634540364, ; 243: System.IO.Compression.dll => 0xcfff1ba06622494c => 108
	i64 15015154896917945444, ; 244: System.Net.Security.dll => 0xd0608bd33642dc64 => 119
	i64 15024878362326791334, ; 245: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 112
	i64 15076659072870671916, ; 246: System.ObjectModel.dll => 0xd13b0d8c1620662c => 125
	i64 15111608613780139878, ; 247: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 18
	i64 15115185479366240210, ; 248: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 107
	i64 15133485256822086103, ; 249: System.Linq.dll => 0xd204f0a9127dd9d7 => 110
	i64 15227001540531775957, ; 250: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 40
	i64 15370334346939861994, ; 251: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 66
	i64 15391712275433856905, ; 252: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 42
	i64 15527772828719725935, ; 253: System.Console => 0xd77dbb1e38cd3d6f => 100
	i64 15536481058354060254, ; 254: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 5
	i64 15557562860424774966, ; 255: System.Net.Sockets => 0xd7e790fe7a6dc536 => 121
	i64 15582737692548360875, ; 256: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 74
	i64 15609085926864131306, ; 257: System.dll => 0xd89e9cf3334914ea => 145
	i64 15661133872274321916, ; 258: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 144
	i64 15664356999916475676, ; 259: de/Microsoft.Maui.Controls.resources.dll => 0xd962f9b2b6ecd51c => 5
	i64 15743187114543869802, ; 260: hu/Microsoft.Maui.Controls.resources.dll => 0xda7b09450ae4ef6a => 13
	i64 15783653065526199428, ; 261: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 6
	i64 15847085070278954535, ; 262: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 140
	i64 16018552496348375205, ; 263: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 116
	i64 16154507427712707110, ; 264: System => 0xe03056ea4e39aa26 => 145
	i64 16219561732052121626, ; 265: System.Net.Security => 0xe1177575db7c781a => 119
	i64 16288847719894691167, ; 266: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 19
	i64 16321164108206115771, ; 267: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 44
	i64 16454459195343277943, ; 268: System.Net.NetworkInformation => 0xe459fb756d988f77 => 116
	i64 16649148416072044166, ; 269: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 51
	i64 16677317093839702854, ; 270: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 79
	i64 16755018182064898362, ; 271: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 55
	i64 16856067890322379635, ; 272: System.Data.Common.dll => 0xe9ecc87060889373 => 101
	i64 16890310621557459193, ; 273: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 139
	i64 16942731696432749159, ; 274: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 26
	i64 16998075588627545693, ; 275: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 77
	i64 17008137082415910100, ; 276: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 93
	i64 17031351772568316411, ; 277: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 76
	i64 17062143951396181894, ; 278: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 97
	i64 17089008752050867324, ; 279: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xed285aeb25888c7c => 33
	i64 17118171214553292978, ; 280: System.Threading.Channels => 0xed8ff6060fc420b2 => 140
	i64 17201328579425343169, ; 281: System.ComponentModel.EventBasedAsync => 0xeeb76534d96c16c1 => 96
	i64 17230721278011714856, ; 282: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 127
	i64 17260702271250283638, ; 283: System.Data.Common => 0xef8a5543bba6bc76 => 101
	i64 17342750010158924305, ; 284: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 11
	i64 17438153253682247751, ; 285: sk/Microsoft.Maui.Controls.resources.dll => 0xf200c3fe308d7847 => 26
	i64 17514990004910432069, ; 286: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 9
	i64 17623389608345532001, ; 287: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 21
	i64 17702523067201099846, ; 288: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xf5abfef008ae1846 => 32
	i64 17704177640604968747, ; 289: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 75
	i64 17710060891934109755, ; 290: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 73
	i64 17712670374920797664, ; 291: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 130
	i64 17777860260071588075, ; 292: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 132
	i64 18025913125965088385, ; 293: System.Threading => 0xfa28e87b91334681 => 142
	i64 18099568558057551825, ; 294: nl/Microsoft.Maui.Controls.resources.dll => 0xfb2e95b53ad977d1 => 20
	i64 18121036031235206392, ; 295: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 76
	i64 18146411883821974900, ; 296: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 106
	i64 18146811631844267958, ; 297: System.ComponentModel.EventBasedAsync.dll => 0xfbd66d08820117b6 => 96
	i64 18245806341561545090, ; 298: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 91
	i64 18305135509493619199, ; 299: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 78
	i64 18324163916253801303, ; 300: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 15
	i64 18370042311372477656 ; 301: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 56
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [302 x i32] [
	i32 46, ; 0
	i32 150, ; 1
	i32 50, ; 2
	i32 109, ; 3
	i32 64, ; 4
	i32 81, ; 5
	i32 8, ; 6
	i32 141, ; 7
	i32 99, ; 8
	i32 11, ; 9
	i32 56, ; 10
	i32 69, ; 11
	i32 85, ; 12
	i32 19, ; 13
	i32 105, ; 14
	i32 55, ; 15
	i32 77, ; 16
	i32 117, ; 17
	i32 47, ; 18
	i32 149, ; 19
	i32 57, ; 20
	i32 141, ; 21
	i32 17, ; 22
	i32 61, ; 23
	i32 74, ; 24
	i32 38, ; 25
	i32 52, ; 26
	i32 114, ; 27
	i32 111, ; 28
	i32 126, ; 29
	i32 60, ; 30
	i32 129, ; 31
	i32 7, ; 32
	i32 81, ; 33
	i32 104, ; 34
	i32 29, ; 35
	i32 48, ; 36
	i32 29, ; 37
	i32 73, ; 38
	i32 3, ; 39
	i32 21, ; 40
	i32 104, ; 41
	i32 52, ; 42
	i32 62, ; 43
	i32 69, ; 44
	i32 91, ; 45
	i32 25, ; 46
	i32 72, ; 47
	i32 137, ; 48
	i32 65, ; 49
	i32 135, ; 50
	i32 59, ; 51
	i32 28, ; 52
	i32 115, ; 53
	i32 41, ; 54
	i32 3, ; 55
	i32 8, ; 56
	i32 85, ; 57
	i32 71, ; 58
	i32 124, ; 59
	i32 132, ; 60
	i32 121, ; 61
	i32 87, ; 62
	i32 50, ; 63
	i32 39, ; 64
	i32 82, ; 65
	i32 147, ; 66
	i32 23, ; 67
	i32 135, ; 68
	i32 58, ; 69
	i32 40, ; 70
	i32 144, ; 71
	i32 39, ; 72
	i32 146, ; 73
	i32 80, ; 74
	i32 43, ; 75
	i32 48, ; 76
	i32 118, ; 77
	i32 111, ; 78
	i32 134, ; 79
	i32 128, ; 80
	i32 34, ; 81
	i32 99, ; 82
	i32 109, ; 83
	i32 98, ; 84
	i32 54, ; 85
	i32 31, ; 86
	i32 1, ; 87
	i32 59, ; 88
	i32 82, ; 89
	i32 105, ; 90
	i32 115, ; 91
	i32 131, ; 92
	i32 94, ; 93
	i32 38, ; 94
	i32 94, ; 95
	i32 122, ; 96
	i32 131, ; 97
	i32 129, ; 98
	i32 27, ; 99
	i32 30, ; 100
	i32 107, ; 101
	i32 136, ; 102
	i32 88, ; 103
	i32 84, ; 104
	i32 106, ; 105
	i32 24, ; 106
	i32 54, ; 107
	i32 24, ; 108
	i32 138, ; 109
	i32 35, ; 110
	i32 72, ; 111
	i32 12, ; 112
	i32 62, ; 113
	i32 68, ; 114
	i32 45, ; 115
	i32 20, ; 116
	i32 23, ; 117
	i32 103, ; 118
	i32 143, ; 119
	i32 124, ; 120
	i32 127, ; 121
	i32 89, ; 122
	i32 27, ; 123
	i32 110, ; 124
	i32 89, ; 125
	i32 98, ; 126
	i32 143, ; 127
	i32 125, ; 128
	i32 113, ; 129
	i32 114, ; 130
	i32 18, ; 131
	i32 147, ; 132
	i32 90, ; 133
	i32 86, ; 134
	i32 61, ; 135
	i32 95, ; 136
	i32 71, ; 137
	i32 112, ; 138
	i32 102, ; 139
	i32 148, ; 140
	i32 95, ; 141
	i32 51, ; 142
	i32 136, ; 143
	i32 79, ; 144
	i32 92, ; 145
	i32 126, ; 146
	i32 36, ; 147
	i32 22, ; 148
	i32 148, ; 149
	i32 90, ; 150
	i32 78, ; 151
	i32 22, ; 152
	i32 102, ; 153
	i32 32, ; 154
	i32 0, ; 155
	i32 53, ; 156
	i32 84, ; 157
	i32 60, ; 158
	i32 139, ; 159
	i32 65, ; 160
	i32 93, ; 161
	i32 150, ; 162
	i32 49, ; 163
	i32 7, ; 164
	i32 113, ; 165
	i32 128, ; 166
	i32 47, ; 167
	i32 4, ; 168
	i32 68, ; 169
	i32 120, ; 170
	i32 87, ; 171
	i32 66, ; 172
	i32 2, ; 173
	i32 117, ; 174
	i32 36, ; 175
	i32 44, ; 176
	i32 49, ; 177
	i32 13, ; 178
	i32 83, ; 179
	i32 16, ; 180
	i32 45, ; 181
	i32 67, ; 182
	i32 130, ; 183
	i32 14, ; 184
	i32 83, ; 185
	i32 43, ; 186
	i32 146, ; 187
	i32 88, ; 188
	i32 10, ; 189
	i32 58, ; 190
	i32 120, ; 191
	i32 138, ; 192
	i32 134, ; 193
	i32 92, ; 194
	i32 57, ; 195
	i32 37, ; 196
	i32 70, ; 197
	i32 75, ; 198
	i32 35, ; 199
	i32 103, ; 200
	i32 63, ; 201
	i32 108, ; 202
	i32 15, ; 203
	i32 64, ; 204
	i32 28, ; 205
	i32 46, ; 206
	i32 123, ; 207
	i32 0, ; 208
	i32 133, ; 209
	i32 2, ; 210
	i32 16, ; 211
	i32 149, ; 212
	i32 10, ; 213
	i32 122, ; 214
	i32 86, ; 215
	i32 30, ; 216
	i32 31, ; 217
	i32 14, ; 218
	i32 80, ; 219
	i32 53, ; 220
	i32 97, ; 221
	i32 9, ; 222
	i32 12, ; 223
	i32 100, ; 224
	i32 70, ; 225
	i32 4, ; 226
	i32 63, ; 227
	i32 142, ; 228
	i32 118, ; 229
	i32 25, ; 230
	i32 6, ; 231
	i32 137, ; 232
	i32 37, ; 233
	i32 133, ; 234
	i32 41, ; 235
	i32 17, ; 236
	i32 33, ; 237
	i32 67, ; 238
	i32 34, ; 239
	i32 1, ; 240
	i32 42, ; 241
	i32 123, ; 242
	i32 108, ; 243
	i32 119, ; 244
	i32 112, ; 245
	i32 125, ; 246
	i32 18, ; 247
	i32 107, ; 248
	i32 110, ; 249
	i32 40, ; 250
	i32 66, ; 251
	i32 42, ; 252
	i32 100, ; 253
	i32 5, ; 254
	i32 121, ; 255
	i32 74, ; 256
	i32 145, ; 257
	i32 144, ; 258
	i32 5, ; 259
	i32 13, ; 260
	i32 6, ; 261
	i32 140, ; 262
	i32 116, ; 263
	i32 145, ; 264
	i32 119, ; 265
	i32 19, ; 266
	i32 44, ; 267
	i32 116, ; 268
	i32 51, ; 269
	i32 79, ; 270
	i32 55, ; 271
	i32 101, ; 272
	i32 139, ; 273
	i32 26, ; 274
	i32 77, ; 275
	i32 93, ; 276
	i32 76, ; 277
	i32 97, ; 278
	i32 33, ; 279
	i32 140, ; 280
	i32 96, ; 281
	i32 127, ; 282
	i32 101, ; 283
	i32 11, ; 284
	i32 26, ; 285
	i32 9, ; 286
	i32 21, ; 287
	i32 32, ; 288
	i32 75, ; 289
	i32 73, ; 290
	i32 130, ; 291
	i32 132, ; 292
	i32 142, ; 293
	i32 20, ; 294
	i32 76, ; 295
	i32 106, ; 296
	i32 96, ; 297
	i32 91, ; 298
	i32 78, ; 299
	i32 15, ; 300
	i32 56 ; 301
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
