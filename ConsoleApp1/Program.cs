// See https://aka.ms/new-console-template for more information
using StoresLand_API.Stores;

Console.WriteLine("Hello, World!");






await clsStore.AddStore(new StoreDTO(10, "fd", "ff", 1, "f", "f", 1, 1, 4, 4, 1, 12, "ff", 1));


await clsStore.UpdateStore( 2 , new StoreDTO(2, "fd", "ff", 1, "f", "f", 1, 1, 4, 4, 1, 12, "ff", 1003));