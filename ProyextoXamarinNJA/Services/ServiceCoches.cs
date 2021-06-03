using Newtonsoft.Json;
using ProyextoXamarinNJA.Helper;
using ProyextoXamarinNJA.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyextoXamarinNJA.Services
{
    public class ServiceCoche
    {
        private Uri url;
        private MediaTypeWithQualityHeaderValue header;
        private String api;
        public ServiceCoche()
        {

            this.api = "https://apiproyectonja.azurewebsites.net/";
            this.url = new Uri(api);
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }


        #region API
        private async Task<T> CallApi<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    String jsondata = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(jsondata);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        private async Task<T> PostApi<T>(String request, T objeto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                String json = JsonConvert.SerializeObject(objeto);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    String jsondata = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(jsondata);

                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        private async Task<T> PutApi<T>(String request, T objeto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                String json = JsonConvert.SerializeObject(objeto);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PutAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    String jsondata = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(jsondata);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        private async Task DeleteApi(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                await client.DeleteAsync(request);
            }
        }
        #endregion
        #region Usuario
        public async Task InsertarUsuarioAsync(int idusuario, String nombre, String apellidos, String username, String email, String password)
        {
            String request = "api/Home/Register";
            Usuario user = new Usuario();
            //user.IdUsuario = MaxIdUsuario();
            user.Nombre = nombre;
            user.Apellidos = apellidos;
            user.UserName = username;
            user.Email = email;
            String salt = CypherService.GetSalt();
            user.Salt = salt;
            byte[] res = CypherService.CifrarContenido(password, salt);
            user.Pass = res;
            await this.PostApi<Usuario>(request, user);
        }
        public async Task<Usuario> GetUsuarioByUsernameAsync(String username)
        {
            //getusuario
            String request = "api/Home/GetUsuarioByUsername/" + username;
            return await this.CallApi<Usuario>(request);

        }

        public async Task<Usuario> UserLogInAsync(String username, String password)
        {
            //getusuario
            String request = "api/Home/LogIn";
            Usuario user = await this.GetUsuarioByUsernameAsync(username);
            if (user == null)
            {
                return null;
            }
            else
            {
                Usuario userlogin = new Usuario();
                userlogin.UserName = username;
                userlogin.Pass = CypherService.CifrarContenido(password, user.Salt);
                return await this.PostApi<Usuario>(request, userlogin);
            }
        }
        #endregion
        #region Foro
        public async Task<List<Foro>> GetForoAsync()
        {
            String request = "api/Foro/GetForo";
            return await this.CallApi<List<Foro>>(request);
        }

        public async Task<List<Foro>> GetForoMarcaAsync(String filtro)
        {
            String request = "api/Foro/GetForoMarca/" + filtro;
            return await this.CallApi<List<Foro>>(request);
        }
        public async Task<Foro> BuscarForoAsync(int idforo)
        {
            String request = "api/Foro/BuscarForo/" + idforo;
            return await this.CallApi<Foro>(request);
        }
        public async Task EliminarForoAsync(int idforo)
        {
            String request = "api/Foro/" + idforo;
            await this.DeleteApi(request);
        }
        public async Task InsertarForoAsync(int idforo, string marca, string modelo, string asunto, string contenido)
        {
            String request = "api/Foro";
            Foro foro = new Foro();
            foro.Marca = marca;
            foro.Modelo = modelo;
            foro.Asunto = asunto;
            foro.Contenido = contenido;
            await this.PostApi<Foro>(request, foro);
        }
        public async Task ModificarForoAsync(int idforo, String marca, String modelo, String asunto, String contenido)
        {
            String request = "api/Foro";
            Foro foro = new Foro();
            foro.IdForo = idforo;
            foro.Marca = marca;
            foro.Modelo = modelo;
            foro.Asunto = asunto;
            foro.Contenido = contenido;
            await this.PutApi<Foro>(request, foro);
        }
        #endregion

        #region Coche
        public async Task<List<Coche>> GetCocheAsync(int idusuario)
        {
            String request = "api/Coches/GetCoches/" + idusuario;
            return await this.CallApi<List<Coche>>(request);
        }
        public async Task<Coche> BuscarCocheAsync(int idcoche)
        {
            String request = "api/Coches/BuscarCoche/" + idcoche;
            return await this.CallApi<Coche>(request);
        }
        public async Task EliminarCocheAsync(int idcoche)
        {
            String request = "api/Coches/EliminarCoche/" + idcoche;
            await this.DeleteApi(request);
        }
        public async Task InsertarCocheAsync(string marca, string modelo, int año, int kilometros, string motor, int idusuario)
        {
            //String request = "api/Coches/";
            Coche coche = new Coche()
            {
                Marca = marca,
                Modelo = modelo,
                Año = año,
                Kilometros = kilometros,
                Motor = motor,
                IdUsuario = 1
            };

            String json = JsonConvert.SerializeObject(coche);
            StringContent content =
                new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                String request = "api/Coches/";
                Uri uri = new Uri(this.url + request);
                await this.PostApi<Coche>(request, coche);
            }

            
        }
        public async Task ModificarCocheAsync(int idcoche, string marca, string modelo, int año, int kilometros, string motor)
        {
            String request = "api/Coches/ModificarCoche";
            Coche coche = new Coche();
            coche.IdCoche = idcoche;
            coche.Marca = marca;
            coche.Modelo = modelo;
            coche.Año = año;
            coche.Kilometros = kilometros;
            coche.Motor = motor;
            await this.PutApi<Coche>(request, coche);
        }
        #endregion
        #region Comentario
        public async Task<List<Comentario>> GetComentarioAsync(int idforo)
        {
            String request = "api/Foros/GetComentarios/" + idforo;
            return await this.CallApi<List<Comentario>>(request);
        }
        public async Task<Comentario> BuscarComentarioAsync(int idcomentario)
        {
            String request = "api/Foros/BuscarComentario/" + idcomentario;
            return await this.CallApi<Comentario>(request);
        }
        public async Task InsertarComentarioAsync(int idcomentario, int idusuario, string mensaje, int valoracion, DateTime fecha, int idforo)
        {
            String request = "api/Foros/InsertarComentario";
            Comentario comentario = new Comentario();
            comentario.IdUsuario = idusuario;
            comentario.Mensaje = mensaje;
            comentario.Valoracion = valoracion;
            comentario.FechaMensaje = fecha;
            comentario.IdForo = idforo;
            await this.PostApi<Comentario>(request, comentario);
        }
        public async Task ModificarComentarioAsync(int idcomentario, String mensaje, int valoracion, DateTime fecha)
        {
            String request = "api/Foros/ModificarComentario";
            Comentario comentario = new Comentario();
            comentario.IdComentario = idcomentario;
            comentario.Mensaje = mensaje;
            comentario.Valoracion = valoracion;
            comentario.FechaMensaje = DateTime.Now;
            await this.PutApi<Comentario>(request, comentario);
        }
        public async Task EliminarComentarioAsync(int idcomentario)
        {
            String request = "api/Foros/EliminarComentario/" + idcomentario;
            await this.DeleteApi(request);
        }
        #endregion
        #region MantenimientosAverias
        public async Task<List<MantenimientoAveria>> GetMantenimientoAveriaAsync(int idcoche)
        {
            String request = "api/Coches/GetMantenimientoAverias/" + idcoche;
            return await this.CallApi<List<MantenimientoAveria>>(request);
        }

        public async Task<MantenimientoAveria> BuscarMantenimientoAveriaAsync(int idmantenimientoaveria)
        {
            String request = "api/Coches/BuscarMantenimientoAveria/" + idmantenimientoaveria;
            return await this.CallApi<MantenimientoAveria>(request);
        }

        public async Task EliminarMantenimientoAveriaAsync(int idmantenimientoaveria)
        {
            String request = "api/Coches/EliminarMantenimientoAveria/" + idmantenimientoaveria;
            await this.DeleteApi(request);
        }

        public async Task InsertarMantenimientoAveriaAsync(int tipo, string zona, string logo, DateTime fechamantenimiento, int precio, string observaciones, int idcoche)
        {
            String request = "api/Coches/InsertarMantenimientoAveria";
            MantenimientoAveria MantenimientoAveria = new MantenimientoAveria();
            MantenimientoAveria.Tipo = tipo;
            MantenimientoAveria.Zona = zona;
            MantenimientoAveria.Logo = logo;
            MantenimientoAveria.FechaMantenimiento = fechamantenimiento;
            MantenimientoAveria.PrecioMantenimiento = precio;
            MantenimientoAveria.ObservacionesMantenimiento = observaciones;
            MantenimientoAveria.IdCoche = idcoche;
            await this.PostApi<MantenimientoAveria>(request, MantenimientoAveria);
        }

        public async Task ModificarMantenimientoAveriaAsync(int idmantenimientoaveria, int tipo, string zona, string logo, DateTime fechamantenimiento, int precio, string observaciones)
        {
            String request = "api/Coches/ModificarMantenimientoAveria";
            MantenimientoAveria MantenimientoAveria = new MantenimientoAveria();
            MantenimientoAveria.IdMantenimientoAveria = idmantenimientoaveria;
            MantenimientoAveria.Tipo = tipo;
            MantenimientoAveria.Zona = zona;
            MantenimientoAveria.Logo = logo;
            MantenimientoAveria.FechaMantenimiento = fechamantenimiento;
            MantenimientoAveria.PrecioMantenimiento = precio;
            MantenimientoAveria.ObservacionesMantenimiento = observaciones;
            await this.PutApi<MantenimientoAveria>(request, MantenimientoAveria);
        }
        #endregion

    }


}
