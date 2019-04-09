using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLab
{
    [Serializable]
    public class Processor
    {
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Series { get; set; }
        [Required(ErrorMessage = "Отсутвует модель")]
        public string Model { get; set; }
        [Required]
        public int Cores { get; set; }
        [Required]
        public int Friequency { get; set; }
        [Required]
        public int Architecture { get; set; }
        [Required]
        public int CacheL1 { get; set; }
        [Required]
        public int CacheL2 { get; set; }
        [Required]
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
            return Manufacturer + " " + Series + " " + Model + " " + Friequency + "Mhz";
        }
    }
    [Serializable]
    public class VideoAdapter
    {
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Series { get; set; }
        [Required(ErrorMessage = "Отсутвует модель")]
        public string Model { get; set; }
        [Required]
        public int Friequency { get; set; }
        public bool DirectX11 { get; set; }
        [Required]
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
        [Required]
        public string Type { get; set; }
        public Processor processor { get; set; }
        public VideoAdapter videoAdapter { get; set; }
        [Required]
        public int RamSize { get; set; }
        [Required]
        public string RamType { get; set; }
        [Required]
        public int HDDSize { get; set; }
        [Required]
        public string HDDType { get; set; }
        [Required]
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
