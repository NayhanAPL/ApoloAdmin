using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApoloAdmin
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Artista>().Wait();
            _database.CreateTableAsync<Proyecto>().Wait();
            _database.CreateTableAsync<VersionActual>().Wait();
        }


        //---------------------------------VersionActual-------------------------------------------


        //consulta por id de VersionActual---------------------------------------------------------
        public Task<VersionActual> GetIdVersionActual(int Id)
        {
            return _database.Table<VersionActual>().Where(a => a.Id == Id).FirstOrDefaultAsync();
        }
        //annadir el VersionActual en la db--------------------------------------------------------
        public Task<int> SaveVersionActual(VersionActual U)
        {
            if (U.Id == 0)
                return _database.InsertAsync(U);
            else return null;
        }
        //guardar la actualizacion de el VersionActual en la db------------------------------------
        public Task<int> SaveUpVersionActual(VersionActual U)
        {
            if (U.Id != 0)
                return _database.UpdateAsync(U);
            else return _database.InsertAsync(U);
        }



        //---------------------------------Artistas-------------------------------------------

        // devuelve el ultimo elemento guardado---------------------------------------------------
        public async Task<List<Artista>> GetLastItemArtistas()
        {
            return await _database.QueryAsync<Artista>($"Select * from Artista order by Id desc limit 1");
        }
        //consulta completa Artistas----------------------------------------------------------
        public Task<List<Artista>> GetArtistas()
        {
            return _database.Table<Artista>().ToListAsync();
        }
        //consulta por id de Artistas---------------------------------------------------------
        public Task<Artista> GetIdArtistas(int Id)
        {
            return _database.Table<Artista>().Where(a => a.Id == Id).FirstOrDefaultAsync();
        }
        //annadir el Artistas en la db--------------------------------------------------------
        public Task<int> SaveArtistas(Artista U)
        {
            if (U.Id == 0)
                return _database.InsertAsync(U);
            else return null;
        }
        //guardar la actualizacion de el Artistas en la db------------------------------------
        public Task<int> SaveUpArtistas(Artista U)
        {
            if (U.Id != 0)
                return _database.UpdateAsync(U);
            else return _database.InsertAsync(U);
        }
        // borrar una fila de la tabla Artistas-----------------------------------------------
        public Task<int> DeleteArtistas(Artista Artistas)
        {
            var x = _database.DeleteAsync(Artistas);
            return x;
        }


        //---------------------------------Proyectos-------------------------------------------


        //consulta completa Proyectos----------------------------------------------------------
        public Task<List<Proyecto>> GetProyectos()
        {
            return _database.Table<Proyecto>().ToListAsync();
        }
        //consulta por id de Favoritos---------------------------------------------------------
        public Task<Proyecto> GetIdProyectos(int Id)
        {
            return _database.Table<Proyecto>().Where(a => a.Id == Id).FirstOrDefaultAsync();
        }
        //annadir el Proyectos en la db--------------------------------------------------------
        public Task<int> SaveProyectos(Proyecto U)
        {
            if (U.Id == 0)
                return _database.InsertAsync(U);
            else return null;
        }
        //guardar la actualizacion de el Proyectos en la db------------------------------------
        public Task<int> SaveUpProyectos(Proyecto U)
        {
            if (U.Id != 0)
                return _database.UpdateAsync(U);
            else return _database.InsertAsync(U);
        }
        // borrar una fila de la tabla Proyectos-----------------------------------------------
        public Task<int> DeleteProyectos(Proyecto Proyectos)
        {
            var x = _database.DeleteAsync(Proyectos);
            return x;
        }
        // devuelve por IdArt en Proyectos------------------------------------------------------
        public async Task<List<Proyecto>> GetByNameArtProyectos(string name)
        {
            return await _database.QueryAsync<Proyecto>($"Select * from Proyecto where NameArt = '{name}'");
        }
    }
}