// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!\n\ns");



Cloud cloud = new Cloud();
Device device = new Device(cloud);

device.CloudData();

//cloud.CheckData();