using System.Globalization;
using System.Xml.Linq;
using testni_zadatak.Model;

namespace testni_zadatak.Parser
{
    public class GmlParser
    {
        public static GmlFeatureModel ParseGml(string gmlContent)
        {

            XDocument document = XDocument.Parse(gmlContent);
            GmlFeatureModel test = new GmlFeatureModel();

            XElement featureElement = document.Root;
            XAttribute fidAttribute = featureElement.Attribute("fid");
            XAttribute featureTypeAttribute = featureElement.Attribute("featureType");
            XElement lineStringElement = featureElement.Descendants("LineString").FirstOrDefault();
            XElement cdataElement = lineStringElement?.Element("CData");


            if (fidAttribute != null)
            {

                test.Id = int.Parse(fidAttribute.Value);

            }

            if (featureTypeAttribute != null)
            {

                test.FeatureType = featureTypeAttribute.Value;

            }

            if (cdataElement != null)
            {
                string cdataValue = cdataElement.Value;

                string[] pairs = cdataValue.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                double[] coordinates = new double[pairs.Length * 2];

                for (int i = 0; i < pairs.Length; i++)
                {
                    string[] parts = pairs[i].Split(',');
                    double x = double.Parse(parts[0], CultureInfo.InvariantCulture);
                    double y = double.Parse(parts[1], CultureInfo.InvariantCulture);

                    coordinates[i * 2] = x;
                    coordinates[i * 2 + 1] = y;
                }
                if (test.Coordinates == null)
                {
                    test.Coordinates = new List<GmlCoordinateModel>();
                }
                for (int i = 0; i < pairs.Length; i++)
                {
                    double x = coordinates[i * 2];
                    double y = coordinates[i * 2 + 1];

                    GmlCoordinateModel coordinateModel = new GmlCoordinateModel
                    {
                        GmlFeatureId = int.Parse(fidAttribute.Value),
                        X = x,
                        Y = y,
                        modified = DateTime.Now
                    };

                    test.Coordinates.Add(coordinateModel);

                }

            }
            return test;
        }
    }
}
