using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using testni_zadatak.Model;

[Table("GmlFeatures")]
public class GmlFeature
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }


    public string? FeatureType { get; set; }

    public string? Description { get; set; }

    public virtual List<GmlCoordinateModel>? Coordinates { get; set; }

}