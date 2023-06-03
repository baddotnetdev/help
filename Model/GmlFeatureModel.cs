namespace testni_zadatak.Model
{
    public class GmlFeatureModel
    {
        public int? Id { get; set; }

        public string? FeatureType { get; set; }

        public string? Description { get; set; }

        public virtual List<GmlCoordinateModel>? Coordinates { get; set; }
    }
}
