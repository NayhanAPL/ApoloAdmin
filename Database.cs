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
            _database.CreateTableAsync<Artistas>().Wait();
            _database.CreateTableAsync<Proyectos>().Wait();
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


        //consulta completa Artistas----------------------------------------------------------
        public Task<List<Artistas>> GetArtistas()
        {
            return _database.Table<Artistas>().ToListAsync();
        }
        //consulta por id de Artistas---------------------------------------------------------
        public Task<Artistas> GetIdArtistas(int Id)
        {
            return _database.Table<Artistas>().Where(a => a.Id == Id).FirstOrDefaultAsync();
        }
        //annadir el Artistas en la db--------------------------------------------------------
        public Task<int> SaveArtistas(Artistas U)
        {
            if (U.Id == 0)
                return _database.InsertAsync(U);
            else return null;
        }
        //guardar la actualizacion de el Artistas en la db------------------------------------
        public Task<int> SaveUpArtistas(Artistas U)
        {
            if (U.Id != 0)
                return _database.UpdateAsync(U);
            else return _database.InsertAsync(U);
        }
        // borrar una fila de la tabla Artistas-----------------------------------------------
        public Task<int> DeleteArtistas(Artistas Artistas)
        {
            var x = _database.DeleteAsync(Artistas);
            return x;
        }


        //---------------------------------Proyectos-------------------------------------------


        //consulta completa Proyectos----------------------------------------------------------
        public Task<List<Proyectos>> GetProyectos()
        {
            return _database.Table<Proyectos>().ToListAsync();
        }
        //consulta por id de Favoritos---------------------------------------------------------
        public Task<Proyectos> GetIdProyectos(int Id)
        {
            return _database.Table<Proyectos>().Where(a => a.Id == Id).FirstOrDefaultAsync();
        }
        //annadir el Proyectos en la db--------------------------------------------------------
        public Task<int> SaveProyectos(Proyectos U)
        {
            if (U.Id == 0)
                return _database.InsertAsync(U);
            else return null;
        }
        //guardar la actualizacion de el Proyectos en la db------------------------------------
        public Task<int> SaveUpProyectos(Proyectos U)
        {
            if (U.Id != 0)
                return _database.UpdateAsync(U);
            else return _database.InsertAsync(U);
        }
        // borrar una fila de la tabla Proyectos-----------------------------------------------
        public Task<int> DeleteProyectos(Proyectos Proyectos)
        {
            var x = _database.DeleteAsync(Proyectos);
            return x;
        }
        // devuelve por IdArt en Proyectos------------------------------------------------------
        public async Task<List<Proyectos>> GetByIdArtProyectos(int id)
        {
            return await _database.QueryAsync<Proyectos>($"Select * from Proyectos where IdArt = '{id}'");
        }
    }
}