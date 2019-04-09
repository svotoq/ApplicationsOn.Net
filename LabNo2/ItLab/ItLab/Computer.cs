using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLab
{
    [Serializable]
    public class Processor
    {
        public string Manufacturer { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int Cores { get; set; }
        public int Friequency { get; set; }
        public int Architecture { get; set; }
        public int CacheL1 { get; set; }
        public int CacheL2 { get; set; }
        public int CacheL3 { get; set; }
        public Processor()
        {

        }
        public Processor(string _manufacturer, string _series, string _model, int _cores,
            int _friequency, int _architecture, int _cacheL1, int _cacheL2, int _cacheL3)
        {
            Manufacturer = _manufacturer;
            Series = _series;
            Model = _model;
            Cores = _cores;
            Friequency = _friequency;
            Architecture = _architecture;
            CacheL1 = _cacheL1;
            CacheL2 = _cacheL2;
            CacheL3 = _cacheL3;
        }
        public override string ToString()
        {
            return Manufacturer + " " + Series + Model + " " + Friequency + "Mhz";
        }
    }
    [Serializable]
    public class VideoAdapter
    {
        public string Manufacturer { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int Friequency { get; set; }
        public bool DirectX11 { get; set; }
        public int MemorySize { get; set; }
        public VideoAdapter()
        {

        }
        public VideoAdapter(string _manufacturer, string _series, string _model, int _friequency, bool _directX11, int _memorySize)
        {
            Manufacturer = _manufacturer;
            Series = _series;
            Model = _model;
            Friequency = _friequency;
            DirectX11 = _directX11;
            MemorySize = _memorySize;
        }
        public override string ToString()
        {
            return Manufacturer + " " + Series + Model + " " + MemorySize + "Mb";
        }
    }
    [Serializable]
    public class Computer
    {
        public string Type { get; set; }
        public Processor processor { get; set; }
        public VideoAdapter videoAdapter { get; set; }
        public int RamSize { get; set; }
        public string RamType { get; set; }
        public int HDDSize { get; set; }
        public string HDDType { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Computer()
        {

        }
        public Computer(string _type, Processor _processor, VideoAdapter _videoAdapter, int _ramsize,
            string _ramType, int _hDDSize, string _hDDType, DateTime _purchaseDate)
        {
            Type = _type;
            processor = _processor;
            videoAdapter = _videoAdapter;
            RamSize = _ramsize;
            RamType = _ramType;
            HDDSize = _hDDSize;
            HDDType = _hDDType;
            PurchaseDate = _purchaseDate;
        }
    }
}
