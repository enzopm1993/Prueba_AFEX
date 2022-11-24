using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;
using System;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public VideoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                string query = @"
                            select VideoId, VideoURL, FechaHora, Titulo, Descripcion, ImagenAlbum, FechaVideo, 
                            Duracion, Estado from
                            dbo.videos
                            where Estado = 'A'
                            order by FechaHora desc
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("AlbumAppCon");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult(table);
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Post(Video video)
        {
            try
            {
                string query = @"
                           insert into dbo.videos
                           values (@VideoURL,'" + DateTime.Now + "', @Titulo, @Descripcion, @ImagenAlbum, @FechaVideo, @Duracion, 'A')";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("AlbumAppCon");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@VideoURL", video.VideoURL);
                        myCommand.Parameters.AddWithValue("@Titulo", video.Titulo);
                        myCommand.Parameters.AddWithValue("@Descripcion", video.Descripcion);
                        myCommand.Parameters.AddWithValue("@ImagenAlbum", video.ImagenAlbum);
                        myCommand.Parameters.AddWithValue("@FechaVideo", video.FechaVideo);
                        myCommand.Parameters.AddWithValue("@Duracion", video.Duracion);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult("Agregado Correctamente");
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPut]
        public JsonResult Put(Video video)
        {
            try
            {
                string query = @"
                           update dbo.videos
                           set Estado= 'I'
                            where VideoId=@VideoId
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("AlbumAppCon");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@VideoId", video.VideoId);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult("Video Eliminado!");
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
