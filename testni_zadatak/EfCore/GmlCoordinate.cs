using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("GmlCoordinates")]
public class GmlCoordinate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    [ForeignKey("GmlFeature")]
    public int? GmlFeatureId { get; set; }

    public double? X { get; set; }
    public double? Y { get; set; }

    public DateTime? modified { get; set; }

    public virtual GmlFeature? GmlFeature { get; set; }
}
