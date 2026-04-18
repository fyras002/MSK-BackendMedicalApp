namespace MedicalAppBackend.Models
{
    public class DiseaseList
    {
        public int IdDiseaseList { get; set; }
        public string? TitleEnDiseaseList { get; set; }
        public string? TitleFrDiseaseList { get; set; }
        public string? TitleArDiseaseList { get; set; }
        public string? DescDiseaseList { get; set; }
        public string? ImgDiseaseList { get; set; }
        public string? TypeCategDiseaseList { get; set; }
        public bool? Active { get; set; }
    }
}
