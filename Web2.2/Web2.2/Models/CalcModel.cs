using Web2._2.Services;

namespace Web2._2.Models
{
    public class CalcModel
    {
        public int a { get; set; }
        public int b { get; set; }
        public Operation? Operation { get; set; }
        public string? GetValue() { return CalcService.DoCalculation(a,b,Operation); }
    }
}
