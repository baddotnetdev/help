using System.ComponentModel.DataAnnotations.Schema;

namespace testni_zadatak.Model
{
    public class GmlCoordinateModel
    {
        public int? Id { get; set; }

        [ForeignKey("GmlFeature")]
        public int? GmlFeatureId { get; set; }

        public double? X { get; set; }
        public double? Y { get; set; }

        public DateTime? modified { get; set; }

        public virtual GmlFeature? GmlFeature { get; set; }
    }
}
