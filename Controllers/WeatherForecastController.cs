using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using testni_zadatak.Parser;
using testni_zadatak.EfCore;
using testni_zadatak.Model;


namespace testni_zadatak.Controllers
{
    
    [ApiController]
    public class WeatherForecast : ControllerBase
    {
        private readonly DbHelper _db;
        public WeatherForecast(EF_DataContext eF_DataContext) 
        {
            _db = new DbHelper(eF_DataContext);
        }
        // GET: api/<GmlAPIController>
        [HttpGet]
        [Route("api/[controller]/GetFeatures")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try 
            {
                IEnumerable<GmlFeatureModel> data = _db.GetGmlFeatures();
                
                if (!data.Any()) 
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            } 
            catch(Exception ex) 
            {
                
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/SortFeatures")]
        public IActionResult Get(string criteria)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<GmlFeatureModel> data = _db.GetGmlFeatures();
                if (criteria != null) 
                {
                    if (criteria == "Id")
                    {
                        data.OrderBy(c => c.Id);
                    }
                    else
                    {
                        data.OrderBy(c => c.FeatureType);

                    }

                }
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<GmlAPIController>/5
        [HttpGet]
        [Route("api/[controller]/GetFeatureById/{id}")]
        public IActionResult Get(int id)
        {
            
            try
            {
                ResponseType type = ResponseType.Success;
                GmlFeatureModel data = _db.GetGmlFeatureById(id);
                data.Coordinates = _db.GetGmlCoordinates().Where(obj => obj.GmlFeatureId == id).ToList();
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<GmlAPIController>
        [HttpPost]
        [Route("api/[controller]/SaveGmlFeature")]
        public IActionResult Post([FromBody] string gmlContent)
        {
            try
            {
                GmlFeatureModel feature = GmlParser.ParseGml(gmlContent);

                _db.SaveGmlFeature(feature);

                    foreach (GmlCoordinateModel coordinate in feature.Coordinates)
                    {
                        _db.SaveGmlCoordinate(coordinate);
                    }

                    
                

                ResponseType type = ResponseType.Success;
                return Ok(ResponseHandler.GetAppResponse(type, feature));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<GmlAPIController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateGmlFeature")]
        public IActionResult Put([FromBody] string gmlContent)
        {
            try
            {
                GmlFeatureModel feature = GmlParser.ParseGml(gmlContent);

                
                    foreach (GmlCoordinateModel coordinate in feature.Coordinates)
                    {
                        _db.SaveGmlCoordinate(coordinate);
                    }

                    _db.SaveGmlFeature(feature);
                

                ResponseType type = ResponseType.Success;
                return Ok(ResponseHandler.GetAppResponse(type, feature));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<GmlAPIController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteGmlFeature/{id}")]
        public IActionResult Delete(int id)
        {
            try 
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteGmlFeatureCoordinates(id);
                _db.DeleteGmlFeature(id);
                return Ok(ResponseHandler.GetAppResponse(type, null));
            } 
            catch (Exception ex) 
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
