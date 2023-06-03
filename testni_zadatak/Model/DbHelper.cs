using testni_zadatak.EfCore;
using static System.Net.Mime.MediaTypeNames;

namespace testni_zadatak.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;

        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }
        public List<GmlFeatureModel> GetGmlFeatures()
        {
            List<GmlFeatureModel> response = new List<GmlFeatureModel>();
            var dataList = _context.GmlFeatures.ToList();
            dataList.ForEach(row => response.Add(new GmlFeatureModel()
            {
                Id = row.Id,
                FeatureType = row.FeatureType,
                Description = row.Description
    }));
            return response;
        }

        public List<GmlCoordinateModel> GetGmlCoordinates()
        {
            List<GmlCoordinateModel> response = new List<GmlCoordinateModel>();
            var dataList = _context.GmlCoordinates.ToList();
            dataList.ForEach(row => response.Add(new GmlCoordinateModel()
            {
            Id = row.Id,
            X = row.X,
            Y = row.Y,
            GmlFeatureId = row.GmlFeatureId
            }));
            return response;
        }

        public GmlFeatureModel GetGmlFeatureById(int Id)
        {
            
            var row = _context.GmlFeatures.FirstOrDefault(x => x.Id == Id);

            return new GmlFeatureModel()
            {
                Id = row.Id,
                FeatureType = row.FeatureType,
                Description = row.Description
            };
            
        }

        public void SaveGmlFeature(GmlFeatureModel featureModel) 
        {
            try {
                GmlFeature dbTable = new GmlFeature();
                if (featureModel.Id > 0)
                {
                    dbTable = _context.GmlFeatures.Where(d => d.Id.Equals(featureModel.Id)).FirstOrDefault() ?? new GmlFeature();
                    if (dbTable != null)
                    {
                        // PUT (ka update ali ne znan sta bi updatea pa san samo navea random parametre)
                        // update jedino koordinata zajedno sa nekin last modified parametron koja je lista datuma
                        dbTable.FeatureType = featureModel.FeatureType;
                        dbTable.Description = featureModel.Description;


                    }
                    else
                    {
                        // POST

                        GmlFeature NewEntry = new GmlFeature();

                        NewEntry.Id = featureModel.Id;
                        NewEntry.FeatureType = featureModel.FeatureType;
                        NewEntry.Description = featureModel.Description;
                        NewEntry.Coordinates = featureModel.Coordinates;
                        _context.GmlFeatures.Add(NewEntry);

                    }
                    _context.SaveChangesAsync();


                }
                

            }
                
            catch (Exception ex)
            {
                Exception innerException = ex.InnerException;
                // Log or handle the inner exception accordingly
            }
            
        }

        public void DeleteGmlFeature(int id) 
        {
            var feature = _context.GmlFeatures.Where(d=>d.Id.Equals(id)).FirstOrDefault();
            if (feature != null)
            {
                _context.GmlFeatures.Remove(feature);
                _context.SaveChanges();
            }
        }

        public void SaveGmlCoordinate(GmlCoordinateModel coordinate)
        {
            try {

                GmlCoordinate dbTable = new GmlCoordinate();
                if (coordinate.GmlFeatureId > 0)
                {
                    dbTable = _context.GmlCoordinates.Where(d => d.GmlFeatureId.Equals(coordinate.GmlFeatureId)).FirstOrDefault() ?? new GmlCoordinate();
                    if (dbTable != null)
                    {
                        // PUT (ka update ali ne znan sta bi updatea pa san samo navea random parametre)
                        // update jedino koordinata zajedno sa nekin last modified parametron koja je lista datuma
                        dbTable.X = coordinate.X;
                        dbTable.Y = coordinate.Y;
                        dbTable.modified = DateTime.Now;

                   }
                    else
                    {
                        GmlCoordinate NewEntry = new GmlCoordinate();
                        // POST
                        NewEntry.GmlFeatureId = coordinate.GmlFeatureId;
                        NewEntry.X = coordinate.X;
                        NewEntry.Y = coordinate.Y;
                        NewEntry.modified = DateTime.Now;
                        _context.GmlCoordinates.Add(NewEntry);

                    }
                    _context.SaveChangesAsync();


                }
                


            }
            catch (Exception ex)
            {
                Exception innerException = ex.InnerException;
                // Log or handle the inner exception accordingly
            }


        }
                
        

        public void DeleteGmlFeatureCoordinates(int id)
        {
            List<GmlCoordinateModel> coordinatesToDelete = _context.GmlCoordinates
                .Where(d => d.GmlFeatureId.Equals(id))
                .Select(d => new GmlCoordinateModel
                {
                    Id = d.Id,
                    GmlFeatureId = d.GmlFeatureId,
                    X = d.X,
                    Y = d.Y
                })
                .ToList();

            foreach (GmlCoordinateModel coordinate in coordinatesToDelete)
            {
                var coordinateToRemove = _context.GmlCoordinates.Find(coordinate.GmlFeatureId);
                if (coordinateToRemove != null)
                {
                    _context.GmlCoordinates.Remove(coordinateToRemove);
                }
            }

            _context.SaveChanges();
        }


    }
}
